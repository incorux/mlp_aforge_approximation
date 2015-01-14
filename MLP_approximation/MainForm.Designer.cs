namespace MLP_approximation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PruningChk = new System.Windows.Forms.CheckBox();
            this.AddingChk = new System.Windows.Forms.CheckBox();
            this.gammaNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.epsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.sigmaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.outputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.iterationsBox = new System.Windows.Forms.NumericUpDown();
            this.momentumBox = new System.Windows.Forms.NumericUpDown();
            this.learningRateBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.neuronsBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.openFileDialogTrain = new System.Windows.Forms.OpenFileDialog();
            this.loadTestDataButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.openFileDialogTest = new System.Windows.Forms.OpenFileDialog();
            this.loadTrainDataButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioBtnWines = new System.Windows.Forms.RadioButton();
            this.radioBtnMnist = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gammaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigmaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.gammaNumeric);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.epsNumeric);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.sigmaNumericUpDown);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.outputNumericUpDown);
            this.groupBox3.Controls.Add(this.iterationsBox);
            this.groupBox3.Controls.Add(this.momentumBox);
            this.groupBox3.Controls.Add(this.learningRateBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.neuronsBox);
            this.groupBox3.Location = new System.Drawing.Point(198, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 227);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PruningChk);
            this.groupBox1.Controls.Add(this.AddingChk);
            this.groupBox1.Location = new System.Drawing.Point(7, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 50);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dynamic";
            // 
            // PruningChk
            // 
            this.PruningChk.AutoSize = true;
            this.PruningChk.Location = new System.Drawing.Point(11, 32);
            this.PruningChk.Name = "PruningChk";
            this.PruningChk.Size = new System.Drawing.Size(62, 17);
            this.PruningChk.TabIndex = 23;
            this.PruningChk.Text = "Pruning";
            this.PruningChk.UseVisualStyleBackColor = true;
            this.PruningChk.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
            // 
            // AddingChk
            // 
            this.AddingChk.AutoSize = true;
            this.AddingChk.Location = new System.Drawing.Point(11, 12);
            this.AddingChk.Name = "AddingChk";
            this.AddingChk.Size = new System.Drawing.Size(59, 17);
            this.AddingChk.TabIndex = 22;
            this.AddingChk.Text = "Adding";
            this.AddingChk.UseVisualStyleBackColor = true;
            this.AddingChk.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // gammaNumeric
            // 
            this.gammaNumeric.Location = new System.Drawing.Point(146, 205);
            this.gammaNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.gammaNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gammaNumeric.Name = "gammaNumeric";
            this.gammaNumeric.Size = new System.Drawing.Size(60, 20);
            this.gammaNumeric.TabIndex = 26;
            this.gammaNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Gamma";
            // 
            // epsNumeric
            // 
            this.epsNumeric.DecimalPlaces = 5;
            this.epsNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.epsNumeric.Location = new System.Drawing.Point(146, 179);
            this.epsNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.epsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.epsNumeric.Name = "epsNumeric";
            this.epsNumeric.Size = new System.Drawing.Size(60, 20);
            this.epsNumeric.TabIndex = 24;
            this.epsNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Epsilon";
            // 
            // sigmaNumericUpDown
            // 
            this.sigmaNumericUpDown.DecimalPlaces = 2;
            this.sigmaNumericUpDown.Location = new System.Drawing.Point(146, 152);
            this.sigmaNumericUpDown.Name = "sigmaNumericUpDown";
            this.sigmaNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.sigmaNumericUpDown.TabIndex = 20;
            this.sigmaNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sigma";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Output neurons:";
            // 
            // outputNumericUpDown
            // 
            this.outputNumericUpDown.Location = new System.Drawing.Point(146, 128);
            this.outputNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.outputNumericUpDown.Name = "outputNumericUpDown";
            this.outputNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.outputNumericUpDown.TabIndex = 17;
            this.outputNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // iterationsBox
            // 
            this.iterationsBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.iterationsBox.Location = new System.Drawing.Point(146, 98);
            this.iterationsBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.iterationsBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationsBox.Name = "iterationsBox";
            this.iterationsBox.Size = new System.Drawing.Size(60, 20);
            this.iterationsBox.TabIndex = 12;
            this.iterationsBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // momentumBox
            // 
            this.momentumBox.DecimalPlaces = 2;
            this.momentumBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.momentumBox.Location = new System.Drawing.Point(146, 46);
            this.momentumBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.momentumBox.Name = "momentumBox";
            this.momentumBox.Size = new System.Drawing.Size(60, 20);
            this.momentumBox.TabIndex = 4;
            // 
            // learningRateBox
            // 
            this.learningRateBox.DecimalPlaces = 2;
            this.learningRateBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.learningRateBox.Location = new System.Drawing.Point(146, 19);
            this.learningRateBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.learningRateBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.learningRateBox.Name = "learningRateBox";
            this.learningRateBox.Size = new System.Drawing.Size(60, 20);
            this.learningRateBox.TabIndex = 10;
            this.learningRateBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Iterations:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Neurons in hidden layers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Momentum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Learning rate";
            // 
            // neuronsBox
            // 
            this.neuronsBox.Location = new System.Drawing.Point(146, 72);
            this.neuronsBox.Name = "neuronsBox";
            this.neuronsBox.Size = new System.Drawing.Size(60, 20);
            this.neuronsBox.TabIndex = 2;
            this.neuronsBox.Text = "1";
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(198, 245);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(214, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Train";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // loadTestDataButton
            // 
            this.loadTestDataButton.Enabled = false;
            this.loadTestDataButton.Location = new System.Drawing.Point(198, 274);
            this.loadTestDataButton.Name = "loadTestDataButton";
            this.loadTestDataButton.Size = new System.Drawing.Size(214, 23);
            this.loadTestDataButton.TabIndex = 4;
            this.loadTestDataButton.Text = "Load test data";
            this.loadTestDataButton.UseVisualStyleBackColor = true;
            this.loadTestDataButton.Click += new System.EventHandler(this.loadTestDataButton_Click);
            // 
            // testButton
            // 
            this.testButton.Enabled = false;
            this.testButton.Location = new System.Drawing.Point(198, 303);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(214, 23);
            this.testButton.TabIndex = 6;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // openFileDialogTest
            // 
            this.openFileDialogTest.FileName = "openFileDialog1";
            // 
            // loadTrainDataButton
            // 
            this.loadTrainDataButton.Location = new System.Drawing.Point(54, 140);
            this.loadTrainDataButton.Name = "loadTrainDataButton";
            this.loadTrainDataButton.Size = new System.Drawing.Size(75, 40);
            this.loadTrainDataButton.TabIndex = 1;
            this.loadTrainDataButton.Text = "Load training data";
            this.loadTrainDataButton.UseVisualStyleBackColor = true;
            this.loadTrainDataButton.Click += new System.EventHandler(this.loadTrainingDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBtnMnist);
            this.groupBox2.Controls.Add(this.radioBtnWines);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 87);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Problem";
            // 
            // radioBtnWines
            // 
            this.radioBtnWines.AutoSize = true;
            this.radioBtnWines.Checked = true;
            this.radioBtnWines.Location = new System.Drawing.Point(6, 21);
            this.radioBtnWines.Name = "radioBtnWines";
            this.radioBtnWines.Size = new System.Drawing.Size(55, 17);
            this.radioBtnWines.TabIndex = 0;
            this.radioBtnWines.TabStop = true;
            this.radioBtnWines.Text = "Wines";
            this.radioBtnWines.UseVisualStyleBackColor = true;
            // 
            // radioBtnMnist
            // 
            this.radioBtnMnist.AutoSize = true;
            this.radioBtnMnist.Location = new System.Drawing.Point(6, 47);
            this.radioBtnMnist.Name = "radioBtnMnist";
            this.radioBtnMnist.Size = new System.Drawing.Size(59, 17);
            this.radioBtnMnist.TabIndex = 1;
            this.radioBtnMnist.Text = "MNIST";
            this.radioBtnMnist.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(417, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.loadTrainDataButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.loadTestDataButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(730, 376);
            this.Name = "MainForm";
            this.Text = "MLP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gammaNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigmaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox neuronsBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.NumericUpDown learningRateBox;
        private System.Windows.Forms.NumericUpDown momentumBox;
        private System.Windows.Forms.NumericUpDown iterationsBox;
        private System.Windows.Forms.OpenFileDialog openFileDialogTrain;
        private System.Windows.Forms.Button loadTestDataButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown outputNumericUpDown;
        private System.Windows.Forms.Button loadTrainDataButton;
        private System.Windows.Forms.NumericUpDown sigmaNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox AddingChk;
        private System.Windows.Forms.NumericUpDown epsNumeric;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown gammaNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox PruningChk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioBtnMnist;
        private System.Windows.Forms.RadioButton radioBtnWines;
        private System.Windows.Forms.Button button1;
    }
}

