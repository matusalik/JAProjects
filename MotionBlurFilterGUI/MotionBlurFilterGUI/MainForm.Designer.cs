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
            RadiusNumber = new NumericUpDown();
            RadiusLabel = new Label();
            TimeLabel = new Label();
            panel3 = new Panel();
            TimeValueLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SourcePicture).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OutcomePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ArrowPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumberOfThreads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RadiusNumber).BeginInit();
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
            SourcePicture.TabIndex = 0;
            SourcePicture.TabStop = false;
            SourcePicture.SizeMode = PictureBoxSizeMode.StretchImage;
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
            OutcomePicture.TabIndex = 2;
            OutcomePicture.TabStop = false;
            OutcomePicture.SizeMode = PictureBoxSizeMode.StretchImage;
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
            ArrowPicture.TabIndex = 4;
            ArrowPicture.TabStop = false;
            ArrowPicture.SizeMode = PictureBoxSizeMode.StretchImage;
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
            // RadiusNumber
            // 
            RadiusNumber.Location = new Point(125, 334);
            RadiusNumber.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            RadiusNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RadiusNumber.Name = "RadiusNumber";
            RadiusNumber.Size = new Size(120, 23);
            RadiusNumber.TabIndex = 9;
            RadiusNumber.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // RadiusLabel
            // 
            RadiusLabel.AutoSize = true;
            RadiusLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            RadiusLabel.Location = new Point(157, 314);
            RadiusLabel.Name = "RadiusLabel";
            RadiusLabel.Size = new Size(47, 17);
            RadiusLabel.TabIndex = 10;
            RadiusLabel.Text = "Radius";
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
            TimeValueLabel.Size = new Size(72, 32);
            TimeValueLabel.TabIndex = 11;
            TimeValueLabel.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(TimeLabel);
            Controls.Add(RadiusLabel);
            Controls.Add(RadiusNumber);
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
            ((System.ComponentModel.ISupportInitialize)RadiusNumber).EndInit();
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
        private NumericUpDown RadiusNumber;
        private Label RadiusLabel;
        private Label TimeLabel;
        private Panel panel3;
        private Label TimeValueLabel;
    }
}
