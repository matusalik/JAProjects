namespace MotionBlurFilterGUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            SourcePicture = new PictureBox();
            panel2 = new Panel();
            OutcomePicture = new PictureBox();
            SourceLabel = new Label();
            OutcomeLabel = new Label();
            ArrowPicture = new PictureBox();
            NewSourceButton = new Button();
            ApplyFilterButton = new Button();
            NumberOfThreads = new NumericUpDown();
            ThreadsNumberLabel = new Label();
            TimeLabel = new Label();
            panel3 = new Panel();
            TimeValueLabel = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SourcePicture).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OutcomePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ArrowPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumberOfThreads).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(SourcePicture);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 220);
            panel1.TabIndex = 0;
            // 
            // SourcePicture
            // 
            SourcePicture.Location = new Point(-2, -2);
            SourcePicture.Name = "SourcePicture";
            SourcePicture.Size = new Size(355, 220);
            SourcePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            SourcePicture.TabIndex = 0;
            SourcePicture.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(OutcomePicture);
            panel2.Location = new Point(435, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(355, 220);
            panel2.TabIndex = 1;
            // 
            // OutcomePicture
            // 
            OutcomePicture.Location = new Point(-2, -2);
            OutcomePicture.Name = "OutcomePicture";
            OutcomePicture.Size = new Size(355, 220);
            OutcomePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            OutcomePicture.TabIndex = 2;
            OutcomePicture.TabStop = false;
            // 
            // SourceLabel
            // 
            SourceLabel.AutoSize = true;
            SourceLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            SourceLabel.Location = new Point(111, 235);
            SourceLabel.Name = "SourceLabel";
            SourceLabel.Size = new Size(134, 50);
            SourceLabel.TabIndex = 2;
            SourceLabel.Text = "Source";
            // 
            // OutcomeLabel
            // 
            OutcomeLabel.AutoSize = true;
            OutcomeLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            OutcomeLabel.Location = new Point(542, 235);
            OutcomeLabel.Name = "OutcomeLabel";
            OutcomeLabel.Size = new Size(174, 50);
            OutcomeLabel.TabIndex = 3;
            OutcomeLabel.Text = "Outcome";
            // 
            // ArrowPicture
            // 
            ArrowPicture.Location = new Point(368, 101);
            ArrowPicture.Name = "ArrowPicture";
            ArrowPicture.Size = new Size(65, 48);
            ArrowPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            ArrowPicture.TabIndex = 4;
            ArrowPicture.TabStop = false;
            // 
            // NewSourceButton
            // 
            NewSourceButton.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            NewSourceButton.Location = new Point(12, 363);
            NewSourceButton.Name = "NewSourceButton";
            NewSourceButton.Size = new Size(355, 75);
            NewSourceButton.TabIndex = 5;
            NewSourceButton.Text = "Change Source Image";
            NewSourceButton.UseVisualStyleBackColor = true;
            NewSourceButton.Click += NewSourceButton_Click;
            // 
            // ApplyFilterButton
            // 
            ApplyFilterButton.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ApplyFilterButton.Location = new Point(435, 363);
            ApplyFilterButton.Name = "ApplyFilterButton";
            ApplyFilterButton.Size = new Size(355, 75);
            ApplyFilterButton.TabIndex = 6;
            ApplyFilterButton.Text = "Apply Filter";
            ApplyFilterButton.UseVisualStyleBackColor = true;
            ApplyFilterButton.Click += ApplyFilterButton_Click;
            // 
            // NumberOfThreads
            // 
            NumberOfThreads.Location = new Point(568, 334);
            NumberOfThreads.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            NumberOfThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumberOfThreads.Name = "NumberOfThreads";
            NumberOfThreads.Size = new Size(120, 23);
            NumberOfThreads.TabIndex = 7;
            NumberOfThreads.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ThreadsNumberLabel
            // 
            ThreadsNumberLabel.AutoSize = true;
            ThreadsNumberLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ThreadsNumberLabel.Location = new Point(563, 314);
            ThreadsNumberLabel.Name = "ThreadsNumberLabel";
            ThreadsNumberLabel.Size = new Size(125, 17);
            ThreadsNumberLabel.TabIndex = 8;
            ThreadsNumberLabel.Text = "Number Of Threads";
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TimeLabel.Location = new Point(305, 299);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(72, 32);
            TimeLabel.TabIndex = 11;
            TimeLabel.Text = "Time:";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(TimeValueLabel);
            panel3.Location = new Point(383, 299);
            panel3.Name = "panel3";
            panel3.Size = new Size(129, 41);
            panel3.TabIndex = 12;
            // 
            // TimeValueLabel
            // 
            TimeValueLabel.AutoSize = true;
            TimeValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TimeValueLabel.Location = new Point(1, 2);
            TimeValueLabel.Name = "TimeValueLabel";
            TimeValueLabel.Size = new Size(0, 32);
            TimeValueLabel.TabIndex = 11;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(111, 334);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(124, 306);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 14;
            label1.Text = "Choose dll";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(panel3);
            Controls.Add(TimeLabel);
            Controls.Add(ThreadsNumberLabel);
            Controls.Add(NumberOfThreads);
            Controls.Add(ApplyFilterButton);
            Controls.Add(NewSourceButton);
            Controls.Add(ArrowPicture);
            Controls.Add(OutcomeLabel);
            Controls.Add(SourceLabel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "MotionBlurFilter";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SourcePicture).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OutcomePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)ArrowPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumberOfThreads).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private bool newSourceChosen;
        private String sourcePath;
        private Panel panel1;
        private PictureBox SourcePicture;
        private Panel panel2;
        private PictureBox OutcomePicture;
        private Label SourceLabel;
        private Label OutcomeLabel;
        private PictureBox ArrowPicture;
        private Button NewSourceButton;
        private Button ApplyFilterButton;
        private NumericUpDown NumberOfThreads;
        private Label ThreadsNumberLabel;
        private Label TimeLabel;
        private Panel panel3;
        private Label TimeValueLabel;
        private ComboBox comboBox1;
        private Label label1;
    }
}
