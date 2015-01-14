using System.Runtime.Serialization.Formatters.Binary;
using AForge.Neuro;
using AForge.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MLP_approximation
{
    public partial class MainForm : Form
    {
        private double learningRate;
        private double momentum;
        private double sigmoidAlphaValue = 2.0;
        private int iterations;
        private double[,] trainData;
        private double[,] testData;
        private float[] mins;
        private float[] maxes;
        private double[] factors;
        private ActivationNetwork network;
        private List<int> neuronsInLayers;
        private List<double> trainingSetError;
        private string transferFunction;
        private BackPropagationLearning teacher;
        private Thread workerThread;
        private bool needToStop;
        private readonly string _dir = Directory.GetCurrentDirectory();
        private NumberStyles style = NumberStyles.Number;
        private CultureInfo culture = CultureInfo.InvariantCulture;
        private int numberOfInputs, numberOfOutputs, gamma, elapsedIterations;
        private bool dynamicAdding, dynamicPruning;
        private float eps;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check if worker thread is running
            if ((workerThread == null) || (!workerThread.IsAlive)) return;
            needToStop = true;
            workerThread.Join();
        }

        private void loadTrainingDataButton_Click(object sender, EventArgs e)
        {
            if (openFileDialogTrain.ShowDialog() != DialogResult.OK) return;
            StreamReader reader = null;

            try
            {
                reader = File.OpenText(openFileDialogTrain.FileName);
                string str;
                var row = 0;
                numberOfInputs = reader.ReadLine().Split(',').Length - 1;
                factors = new double[numberOfInputs + 1];
                reader.BaseStream.Position = 0;
                reader.DiscardBufferedData();

                // read maximum 60000 points
                var maxPoints = 60000;
                var tempData = new float[maxPoints, numberOfInputs + 1];
                // prepare mins and maxes
                mins = new float[numberOfInputs + 1];
                mins.Populate(float.MaxValue);
                maxes = new float[numberOfInputs + 1];
                maxes.Populate(float.MinValue);

                // read the data
                while ((row < maxPoints) && ((str = reader.ReadLine()) != null))
                {
                    var strs = str.Split(',');

                    // parse first input
                    if (!float.TryParse(strs[0], style, culture, out tempData[row, 0])) continue;
                    // parse the rest of inputs and output
                    for (int input = 1; input <= numberOfInputs; input++)
                    {
                        tempData[row, input] = float.Parse(strs[input], culture);
                    }

                    // search for mins and maxes
                    for (int input = 0; input <= numberOfInputs; input++)
                    {
                        if (tempData[row, input] < mins[input])
                            mins[input] = tempData[row, input];
                        if (tempData[row, input] > maxes[input])
                            maxes[input] = tempData[row, input];
                    }
                    row++;
                }

                // allocate and set data
                trainData = new double[row, numberOfInputs + 1];
                Array.Copy(tempData, 0, trainData, 0, row * (numberOfInputs + 1));
                MessageBox.Show("Training data loaded");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed reading the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            startButton.Enabled = true;
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            learningRate = (double)learningRateBox.Value;
            momentum = (double)momentumBox.Value;
            // add hidden layers
            var neuronsStrings = neuronsBox.Text.Split(' ');
            neuronsInLayers = new List<int>(neuronsStrings.Length);
            foreach (String neuronString in neuronsStrings)
            {
                neuronsInLayers.Add(Int32.Parse(neuronString));
            }
            // add output neurons
            numberOfOutputs = (int)outputNumericUpDown.Value;
            neuronsInLayers.Add(numberOfOutputs);
            iterations = (int)iterationsBox.Value;
            sigmoidAlphaValue = (double)sigmaNumericUpDown.Value;
            eps = (float)epsNumeric.Value;
            gamma = (int)gammaNumeric.Value;
            // run worker thread
            needToStop = false;
            workerThread = new Thread(SearchSolution);
            workerThread.Start();
            workerThread.Join();
            MessageBox.Show("Network trained, iterations:" + elapsedIterations);
            loadTestDataButton.Enabled = true;
        }

        // Worker thread
        void SearchSolution()
        {
            // number of learning samples
            var samples = trainData.GetLength(0);
            // data normalization factors
            const int numerator = 2;
            for (var i = 0; i <= numberOfInputs; i++)
            {
                factors[i] = numerator / (maxes[i] - mins[i]);
            }

            var input = new double[samples][];
            var output = new double[samples][];

            for (var sample = 0; sample < samples; sample++)
            {
                input[sample] = new double[numberOfInputs];
                output[sample] = new double[numberOfOutputs];
                for (var i = 0; i < numberOfInputs; i++)
                {
                    input[sample][i] = normalizeInput(trainData[sample, i], i);
                }
                output[sample] = normalizeOutput(sample);
            }

            network = new ActivationNetwork(
                new BipolarSigmoidFunction(sigmoidAlphaValue),
                numberOfInputs,
                dynamicAdding ? new[] { 1, neuronsInLayers[1] } : neuronsInLayers.ToArray());

            teacher = new BackPropagationLearning(network) { LearningRate = learningRate, Momentum = momentum };

            var iteration = 1;

            trainingSetError = new List<double>();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            var periods = PeriodicAdd(gamma);
            while (!needToStop)
            {
                if (dynamicAdding && periods.Contains(iteration))
                    ((ActivationLayer)network.Layers[0]).AddNeuron(network);
                var error = teacher.RunEpoch(input, output) / samples;
                trainingSetError.Add(error);
                iteration++;
                if (((iterations == 0) || (iteration <= iterations)) && !(error < eps)) continue;
                elapsedIterations = iteration - 1;
                break;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (dynamicPruning) Pruning(input, output);

            TextWriter twError = new StreamWriter(_dir + "\\classification_error.csv");
            var nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
            for (var i = 0; i < trainingSetError.Count; i++)
            {
                twError.WriteLine(i + "," + trainingSetError[i].ToString(nfi));
            }
            twError.Close();
        }

        private double denormalize(double[] output)
        {
            if (output.Length > 1)
            {
                return output.ToList().IndexOf(output.Max()) + 1;
            }
            else
            {
                int add = (transferFunction == "bipolar") ? 1 : 0;
                return (output[0] + add) / factors[factors.Length - 1] + mins[mins.Length - 1];
            }
        }

        private double[] normalizeOutput(int sample)
        {
            if (numberOfOutputs == 1)
            {
                return new double[] { normalizeInput(trainData[sample, numberOfInputs], numberOfInputs) };
            }
            else
            {
                double[] result = new double[numberOfOutputs];
                int low = (transferFunction == "bipolar") ? -1 : 0;
                Populator.Populate<double>(result, low);
                int cls = (int)trainData[sample, numberOfInputs];
                result[cls - 1] = 1;
                return result;
            }
        }

        private double normalizeInput(double value, int inputIndex)
        {
            if (transferFunction == "bipolar")
            {
                return (value - mins[inputIndex]) * factors[inputIndex] - 1.0;
            }
            else
            {
                return (value - mins[inputIndex]) * factors[inputIndex];
            }
        }

        private void loadTestDataButton_Click(object sender, EventArgs e)
        {
            if (openFileDialogTest.ShowDialog() != DialogResult.OK) return;
            StreamReader reader = null;
            // read maximum 20000 points
            float[,] tempData = new float[20000, numberOfInputs];

            try
            {
                reader = File.OpenText(openFileDialogTest.FileName);
                string str;
                int samples = 0;

                // read the data
                while ((samples < 20000) && ((str = reader.ReadLine()) != null))
                {
                    var strs = str.Split(',');
                    // parse 1st input and skip header if necessary
                    if (!float.TryParse(strs[0], style, culture, out tempData[samples, 0])) continue;
                    for (int input = 1; input < numberOfInputs; input++)
                    {
                        tempData[samples, input] = float.Parse(strs[input], culture);
                    }
                    samples++;
                }

                // allocate and set data
                testData = new double[samples, numberOfInputs];
                Array.Copy(tempData, 0, testData, 0, samples * numberOfInputs);
                MessageBox.Show("Test data loaded");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed reading the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            testButton.Enabled = true;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            // number of learning samples
            int samples = testData.GetLength(0);

            var input = new double[samples][];

            for (int sample = 0; sample < samples; sample++)
            {
                input[sample] = new double[numberOfInputs];
                for (int i = 0; i < numberOfInputs; i++)
                {
                    input[sample][i] = normalizeInput(testData[sample, i], i);
                }
            }

            var solution = new double[samples, numberOfInputs + 1];

            // calculate solution
            for (int sample = 0; sample < samples; sample++)
            {
                // copy inputs
                for (int i = 0; i < numberOfInputs; i++)
                {
                    solution[sample, i] = testData[sample, i];
                }

                // denormalize
                solution[sample, numberOfInputs] = denormalize(network.Compute(input[sample]));
            }

            // create a writer and open the file
            TextWriter twSolution = new StreamWriter(_dir + "\\classification_output.csv");
            var nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
            for (int sample = 0; sample < samples; sample++)
            {
                for (int i = 0; i < numberOfInputs; i++)
                {
                    twSolution.Write(solution[sample, i].ToString(nfi) + ",");
                }
                twSolution.Write(solution[sample, numberOfInputs].ToString(nfi));
                twSolution.WriteLine();
            }
            twSolution.Close();
            network.Save(_dir + "\\network");
            MessageBox.Show("Tested");
        }

        private List<int> PeriodicAdd(int gamma)
        {
            var periods = new List<int> { 0 };
            for (var i = 1; periods.Last() < iterations; i++)
            {
                periods.Add((int)Math.Pow(gamma + 1, i - 1));
            }
            return periods;
        }

        private void CheckBox2CheckedChanged(object sender, EventArgs e)
        {
            dynamicPruning = ((CheckBox)sender).Checked;
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            dynamicAdding = ((CheckBox)sender).Checked;
        }

        private void Pruning(double[][] input, double[][] output)
        {
            var samples = input.Length;
            var keepPruning = true;
            Network checkpoint = null;
            var pruned = 0;
            while (keepPruning)
            {
                var trainError = trainingSetError.Last();
                using (var clonestream = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(clonestream, network);
                    clonestream.Position = 0;
                    checkpoint = (Network)formatter.Deserialize(clonestream);

                    var min = network.Layers.SelectMany(x => x.neurons).SelectMany(x => x.weights).Select(Math.Abs).Max();
                    var minpos = new[] { 0, 0, 0 };
                    for (var i = 0; i < network.Layers.Length; i++)
                    {
                        var layer = network.Layers[i];
                        for (var j = 0; j < layer.neurons.Length; j++)
                        {
                            var neuron = layer.neurons[j];
                            for (var k = 0; k < neuron.weights.Length; k++)
                            {
                                var weight = neuron.weights[k];
                                if (neuron.freezes[k] == 0 || Math.Abs(min) < Math.Abs(weight)) continue;
                                min = weight;
                                minpos = new[] { i, j, k };
                            }
                        }
                    }
                    var minneuron = network.Layers[minpos[0]].neurons[minpos[1]];
                    minneuron.Freeze(minpos[2]);
                    var iteration = 1;
                    var trainingSetErrorPrune = new List<double>();
                    while (!needToStop)
                    {
                        var error = teacher.RunEpoch(input, output)/samples;
                        trainingSetErrorPrune.Add(error);
                        iteration++;
                        if ((iteration < iterations/10) && (error > trainError)) continue;
                        if (iteration >= iterations/10 && error > trainError)
                            keepPruning = false;
                        else
                        {
                            trainingSetError.AddRange(trainingSetErrorPrune);
                            pruned++;
                        }
                    break;
                    }
                }
            }
            MessageBox.Show("Pruned " + pruned + " connections");
            network = (ActivationNetwork)checkpoint;
        }

        public static DigitImage[] LoadMnistData(string pixelFile, string labelFile)
        {
            byte[][] pixels = new byte[28][];
            for (int i = 0; i < pixels.Length; ++i)
                pixels[i] = new byte[28];
            FileStream ifsPixels = new FileStream(pixelFile, FileMode.Open);
            FileStream ifsLabels = new FileStream(labelFile, FileMode.Open);
            BinaryReader brImages = new BinaryReader(ifsPixels);
            BinaryReader brLabels = new BinaryReader(ifsLabels);
            int magic1 = brImages.ReadInt32(); // stored as big endian
            int imageCount = brImages.ReadInt32();
            imageCount = ReverseBytes(imageCount);
            DigitImage[] result = new DigitImage[imageCount];
            int numRows = brImages.ReadInt32();
            numRows = ReverseBytes(numRows);
            int numCols = brImages.ReadInt32();
            numCols = ReverseBytes(numCols);
            int magic2 = brLabels.ReadInt32();
            magic2 = ReverseBytes(magic2);
            int numLabels = brLabels.ReadInt32();
            numLabels = ReverseBytes(numLabels);
            for (int di = 0; di < imageCount; ++di)
            {
                for (int i = 0; i < 28; ++i) // get 28x28 pixel values
                {
                    for (int j = 0; j < 28; ++j)
                    {
                        byte b = brImages.ReadByte();
                        pixels[i][j] = b;
                    }
                }
                byte lbl = brLabels.ReadByte(); // get the label
                DigitImage dImage = new DigitImage(28, 28, pixels, lbl);
                result[di] = dImage;
            } // Each image
            ifsPixels.Close();
            brImages.Close();
            ifsLabels.Close();
            brLabels.Close();
            return result;
        }

        public static int ReverseBytes(int v)
        {
            byte[] intAsBytes = BitConverter.GetBytes(v);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt32(intAsBytes, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pixelFile = @"C:\Users\Pawel\Documents\code\train-images.idx3-ubyte";
            string labelFile = @"C:\Users\Pawel\Documents\code\train-labels.idx1-ubyte";
            DigitImage[] trainImages = null;
            trainImages = LoadMnistData(pixelFile, labelFile);
        }
    }
}