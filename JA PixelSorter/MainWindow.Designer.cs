namespace JA_PixelSorter
{
    partial class SorterWindow
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
			this.imagePanel = new System.Windows.Forms.Panel();
			this.botPictureBox = new System.Windows.Forms.PictureBox();
			this.topPictureBox = new System.Windows.Forms.PictureBox();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.libCSelect = new System.Windows.Forms.RadioButton();
			this.libAsmSelect = new System.Windows.Forms.RadioButton();
			this.radioPanel1 = new System.Windows.Forms.Panel();
			this.radioTextbox1 = new System.Windows.Forms.TextBox();
			this.imgChoseButton = new System.Windows.Forms.Button();
			this.threadSlider = new System.Windows.Forms.TrackBar();
			this.sliderPanel = new System.Windows.Forms.Panel();
			this.threadButton = new System.Windows.Forms.Button();
			this.threadCountTextBox = new System.Windows.Forms.TextBox();
			this.sliderTextBox1 = new System.Windows.Forms.TextBox();
			this.testCheckBox = new System.Windows.Forms.CheckBox();
			this.saveImgBtn = new System.Windows.Forms.Button();
			this.executeButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lightnessSelect = new System.Windows.Forms.RadioButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.saturationSelect = new System.Windows.Forms.RadioButton();
			this.hueSelect = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.maxValueText = new System.Windows.Forms.TextBox();
			this.maxValueBar = new System.Windows.Forms.TrackBar();
			this.minValueText = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.minValueBar = new System.Windows.Forms.TrackBar();
			this.timeTextbox = new System.Windows.Forms.TextBox();
			this.fullTimeTextbox = new System.Windows.Forms.TextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.progressText = new System.Windows.Forms.TextBox();
			this.imagePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.botPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.topPictureBox)).BeginInit();
			this.radioPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.threadSlider)).BeginInit();
			this.sliderPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxValueBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minValueBar)).BeginInit();
			this.SuspendLayout();
			// 
			// imagePanel
			// 
			this.imagePanel.Controls.Add(this.botPictureBox);
			this.imagePanel.Controls.Add(this.topPictureBox);
			this.imagePanel.Location = new System.Drawing.Point(12, 4);
			this.imagePanel.Name = "imagePanel";
			this.imagePanel.Size = new System.Drawing.Size(806, 914);
			this.imagePanel.TabIndex = 0;
			// 
			// botPictureBox
			// 
			this.botPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.botPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.botPictureBox.Location = new System.Drawing.Point(3, 459);
			this.botPictureBox.Name = "botPictureBox";
			this.botPictureBox.Padding = new System.Windows.Forms.Padding(5);
			this.botPictureBox.Size = new System.Drawing.Size(800, 450);
			this.botPictureBox.TabIndex = 1;
			this.botPictureBox.TabStop = false;
			// 
			// topPictureBox
			// 
			this.topPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.topPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.topPictureBox.Location = new System.Drawing.Point(3, 3);
			this.topPictureBox.Name = "topPictureBox";
			this.topPictureBox.Padding = new System.Windows.Forms.Padding(5);
			this.topPictureBox.Size = new System.Drawing.Size(800, 450);
			this.topPictureBox.TabIndex = 0;
			this.topPictureBox.TabStop = false;
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// libCSelect
			// 
			this.libCSelect.AutoSize = true;
			this.libCSelect.Checked = true;
			this.libCSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.libCSelect.Location = new System.Drawing.Point(109, 31);
			this.libCSelect.Name = "libCSelect";
			this.libCSelect.Size = new System.Drawing.Size(59, 29);
			this.libCSelect.TabIndex = 0;
			this.libCSelect.TabStop = true;
			this.libCSelect.Text = "C#";
			this.libCSelect.UseVisualStyleBackColor = true;
			// 
			// libAsmSelect
			// 
			this.libAsmSelect.AutoSize = true;
			this.libAsmSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.libAsmSelect.Location = new System.Drawing.Point(237, 31);
			this.libAsmSelect.Name = "libAsmSelect";
			this.libAsmSelect.Size = new System.Drawing.Size(126, 29);
			this.libAsmSelect.TabIndex = 1;
			this.libAsmSelect.TabStop = true;
			this.libAsmSelect.Text = "Assembler";
			this.libAsmSelect.UseVisualStyleBackColor = true;
			// 
			// radioPanel1
			// 
			this.radioPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.radioPanel1.Controls.Add(this.radioTextbox1);
			this.radioPanel1.Controls.Add(this.libAsmSelect);
			this.radioPanel1.Controls.Add(this.libCSelect);
			this.radioPanel1.Location = new System.Drawing.Point(868, 93);
			this.radioPanel1.Name = "radioPanel1";
			this.radioPanel1.Size = new System.Drawing.Size(465, 67);
			this.radioPanel1.TabIndex = 4;
			// 
			// radioTextbox1
			// 
			this.radioTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.radioTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.radioTextbox1.Location = new System.Drawing.Point(109, 2);
			this.radioTextbox1.Name = "radioTextbox1";
			this.radioTextbox1.ReadOnly = true;
			this.radioTextbox1.Size = new System.Drawing.Size(254, 23);
			this.radioTextbox1.TabIndex = 2;
			this.radioTextbox1.Text = "Biblioteka";
			this.radioTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// imgChoseButton
			// 
			this.imgChoseButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgChoseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.imgChoseButton.Location = new System.Drawing.Point(978, 31);
			this.imgChoseButton.Name = "imgChoseButton";
			this.imgChoseButton.Size = new System.Drawing.Size(254, 41);
			this.imgChoseButton.TabIndex = 5;
			this.imgChoseButton.Text = "Wybierz Obraz";
			this.imgChoseButton.UseVisualStyleBackColor = true;
			this.imgChoseButton.Click += new System.EventHandler(this.imgChoseButton_Click);
			// 
			// threadSlider
			// 
			this.threadSlider.Location = new System.Drawing.Point(53, 32);
			this.threadSlider.Maximum = 64;
			this.threadSlider.Minimum = 1;
			this.threadSlider.Name = "threadSlider";
			this.threadSlider.Size = new System.Drawing.Size(377, 56);
			this.threadSlider.TabIndex = 6;
			this.threadSlider.Value = 1;
			this.threadSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// sliderPanel
			// 
			this.sliderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sliderPanel.Controls.Add(this.threadButton);
			this.sliderPanel.Controls.Add(this.threadCountTextBox);
			this.sliderPanel.Controls.Add(this.sliderTextBox1);
			this.sliderPanel.Controls.Add(this.threadSlider);
			this.sliderPanel.Location = new System.Drawing.Point(868, 186);
			this.sliderPanel.Name = "sliderPanel";
			this.sliderPanel.Size = new System.Drawing.Size(465, 118);
			this.sliderPanel.TabIndex = 5;
			// 
			// threadButton
			// 
			this.threadButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.threadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.threadButton.Location = new System.Drawing.Point(109, 72);
			this.threadButton.Name = "threadButton";
			this.threadButton.Size = new System.Drawing.Size(254, 31);
			this.threadButton.TabIndex = 6;
			this.threadButton.Text = "Ustaw domyślnie";
			this.threadButton.UseVisualStyleBackColor = true;
			this.threadButton.Click += new System.EventHandler(this.threadButton_Click);
			// 
			// threadCountTextBox
			// 
			this.threadCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.threadCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.threadCountTextBox.Location = new System.Drawing.Point(16, 32);
			this.threadCountTextBox.Name = "threadCountTextBox";
			this.threadCountTextBox.ReadOnly = true;
			this.threadCountTextBox.Size = new System.Drawing.Size(40, 23);
			this.threadCountTextBox.TabIndex = 7;
			this.threadCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// sliderTextBox1
			// 
			this.sliderTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.sliderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.sliderTextBox1.Location = new System.Drawing.Point(109, 3);
			this.sliderTextBox1.Name = "sliderTextBox1";
			this.sliderTextBox1.ReadOnly = true;
			this.sliderTextBox1.Size = new System.Drawing.Size(254, 23);
			this.sliderTextBox1.TabIndex = 3;
			this.sliderTextBox1.Text = "Ilość wątków";
			this.sliderTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// testCheckBox
			// 
			this.testCheckBox.AutoSize = true;
			this.testCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.testCheckBox.Location = new System.Drawing.Point(978, 319);
			this.testCheckBox.Name = "testCheckBox";
			this.testCheckBox.Size = new System.Drawing.Size(242, 29);
			this.testCheckBox.TabIndex = 6;
			this.testCheckBox.Text = "Tryb testowania wątków";
			this.testCheckBox.UseVisualStyleBackColor = true;
			// 
			// saveImgBtn
			// 
			this.saveImgBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.saveImgBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.saveImgBtn.Location = new System.Drawing.Point(833, 872);
			this.saveImgBtn.Name = "saveImgBtn";
			this.saveImgBtn.Size = new System.Drawing.Size(171, 41);
			this.saveImgBtn.TabIndex = 7;
			this.saveImgBtn.Text = "Zapisz Obraz";
			this.saveImgBtn.UseVisualStyleBackColor = true;
			this.saveImgBtn.Click += new System.EventHandler(this.saveImgBtn_Click);
			// 
			// executeButton
			// 
			this.executeButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.executeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.executeButton.Location = new System.Drawing.Point(978, 678);
			this.executeButton.Name = "executeButton";
			this.executeButton.Size = new System.Drawing.Size(254, 41);
			this.executeButton.TabIndex = 8;
			this.executeButton.Text = "Wykonaj";
			this.executeButton.UseVisualStyleBackColor = true;
			this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lightnessSelect);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.saturationSelect);
			this.panel1.Controls.Add(this.hueSelect);
			this.panel1.Location = new System.Drawing.Point(868, 402);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(465, 67);
			this.panel1.TabIndex = 9;
			// 
			// lightnessSelect
			// 
			this.lightnessSelect.AutoSize = true;
			this.lightnessSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lightnessSelect.Location = new System.Drawing.Point(314, 31);
			this.lightnessSelect.Name = "lightnessSelect";
			this.lightnessSelect.Size = new System.Drawing.Size(107, 29);
			this.lightnessSelect.TabIndex = 3;
			this.lightnessSelect.TabStop = true;
			this.lightnessSelect.Text = "Jasność";
			this.lightnessSelect.UseVisualStyleBackColor = true;
			this.lightnessSelect.CheckedChanged += new System.EventHandler(this.lightnessSelect_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBox1.Location = new System.Drawing.Point(109, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(254, 23);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "Parametr Sortowania";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// saturationSelect
			// 
			this.saturationSelect.AutoSize = true;
			this.saturationSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.saturationSelect.Location = new System.Drawing.Point(171, 31);
			this.saturationSelect.Name = "saturationSelect";
			this.saturationSelect.Size = new System.Drawing.Size(116, 29);
			this.saturationSelect.TabIndex = 1;
			this.saturationSelect.TabStop = true;
			this.saturationSelect.Text = "Saturacja";
			this.saturationSelect.UseVisualStyleBackColor = true;
			this.saturationSelect.CheckedChanged += new System.EventHandler(this.saturationSelect_CheckedChanged);
			// 
			// hueSelect
			// 
			this.hueSelect.AutoSize = true;
			this.hueSelect.Checked = true;
			this.hueSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.hueSelect.Location = new System.Drawing.Point(39, 31);
			this.hueSelect.Name = "hueSelect";
			this.hueSelect.Size = new System.Drawing.Size(96, 29);
			this.hueSelect.TabIndex = 0;
			this.hueSelect.TabStop = true;
			this.hueSelect.Text = "Odcień";
			this.hueSelect.UseVisualStyleBackColor = true;
			this.hueSelect.CheckedChanged += new System.EventHandler(this.hueSelect_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.maxValueText);
			this.panel2.Controls.Add(this.maxValueBar);
			this.panel2.Controls.Add(this.minValueText);
			this.panel2.Controls.Add(this.textBox3);
			this.panel2.Controls.Add(this.minValueBar);
			this.panel2.Location = new System.Drawing.Point(868, 501);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(465, 141);
			this.panel2.TabIndex = 10;
			// 
			// maxValueText
			// 
			this.maxValueText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.maxValueText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.maxValueText.Location = new System.Drawing.Point(3, 94);
			this.maxValueText.Name = "maxValueText";
			this.maxValueText.ReadOnly = true;
			this.maxValueText.Size = new System.Drawing.Size(103, 23);
			this.maxValueText.TabIndex = 12;
			this.maxValueText.Text = "Max:";
			this.maxValueText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// maxValueBar
			// 
			this.maxValueBar.Location = new System.Drawing.Point(112, 94);
			this.maxValueBar.Maximum = 360;
			this.maxValueBar.Name = "maxValueBar";
			this.maxValueBar.Size = new System.Drawing.Size(318, 56);
			this.maxValueBar.TabIndex = 11;
			this.maxValueBar.Value = 180;
			this.maxValueBar.Scroll += new System.EventHandler(this.maxValueBar_Scroll);
			// 
			// minValueText
			// 
			this.minValueText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.minValueText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.minValueText.Location = new System.Drawing.Point(3, 32);
			this.minValueText.Name = "minValueText";
			this.minValueText.ReadOnly = true;
			this.minValueText.Size = new System.Drawing.Size(103, 23);
			this.minValueText.TabIndex = 7;
			this.minValueText.Text = "Min:";
			this.minValueText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBox3.Location = new System.Drawing.Point(109, 3);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(254, 23);
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "Przedział sortowania";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// minValueBar
			// 
			this.minValueBar.Location = new System.Drawing.Point(109, 32);
			this.minValueBar.Maximum = 360;
			this.minValueBar.Name = "minValueBar";
			this.minValueBar.Size = new System.Drawing.Size(321, 56);
			this.minValueBar.TabIndex = 6;
			this.minValueBar.Value = 120;
			this.minValueBar.Scroll += new System.EventHandler(this.minValueBar_Scroll);
			// 
			// timeTextbox
			// 
			this.timeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.timeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.timeTextbox.Location = new System.Drawing.Point(833, 814);
			this.timeTextbox.Name = "timeTextbox";
			this.timeTextbox.ReadOnly = true;
			this.timeTextbox.Size = new System.Drawing.Size(520, 23);
			this.timeTextbox.TabIndex = 11;
			// 
			// fullTimeTextbox
			// 
			this.fullTimeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fullTimeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.fullTimeTextbox.Location = new System.Drawing.Point(833, 843);
			this.fullTimeTextbox.Name = "fullTimeTextbox";
			this.fullTimeTextbox.ReadOnly = true;
			this.fullTimeTextbox.Size = new System.Drawing.Size(520, 23);
			this.fullTimeTextbox.TabIndex = 12;
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(872, 737);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(461, 23);
			this.progressBar.TabIndex = 13;
			// 
			// progressText
			// 
			this.progressText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.progressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.progressText.Location = new System.Drawing.Point(872, 766);
			this.progressText.Name = "progressText";
			this.progressText.ReadOnly = true;
			this.progressText.Size = new System.Drawing.Size(461, 23);
			this.progressText.TabIndex = 14;
			this.progressText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SorterWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1379, 1055);
			this.Controls.Add(this.progressText);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.fullTimeTextbox);
			this.Controls.Add(this.timeTextbox);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.executeButton);
			this.Controls.Add(this.saveImgBtn);
			this.Controls.Add(this.testCheckBox);
			this.Controls.Add(this.sliderPanel);
			this.Controls.Add(this.imgChoseButton);
			this.Controls.Add(this.radioPanel1);
			this.Controls.Add(this.imagePanel);
			this.MaximizeBox = false;
			this.Name = "SorterWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pixel Sorter - projekt JA";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.imagePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.botPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.topPictureBox)).EndInit();
			this.radioPanel1.ResumeLayout(false);
			this.radioPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.threadSlider)).EndInit();
			this.sliderPanel.ResumeLayout(false);
			this.sliderPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxValueBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minValueBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.PictureBox topPictureBox;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.PictureBox botPictureBox;
        private System.Windows.Forms.RadioButton libCSelect;
        private System.Windows.Forms.RadioButton libAsmSelect;
        private System.Windows.Forms.Panel radioPanel1;
        private System.Windows.Forms.TextBox radioTextbox1;
        private System.Windows.Forms.Button imgChoseButton;
        private System.Windows.Forms.TrackBar threadSlider;
        private System.Windows.Forms.Panel sliderPanel;
        private System.Windows.Forms.TextBox sliderTextBox1;
        private System.Windows.Forms.TextBox threadCountTextBox;
        private System.Windows.Forms.Button threadButton;
        private System.Windows.Forms.CheckBox testCheckBox;
        private System.Windows.Forms.Button saveImgBtn;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton saturationSelect;
        private System.Windows.Forms.RadioButton hueSelect;
        private System.Windows.Forms.RadioButton lightnessSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox minValueText;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TrackBar minValueBar;
        private System.Windows.Forms.TrackBar maxValueBar;
        private System.Windows.Forms.TextBox maxValueText;
		private System.Windows.Forms.TextBox timeTextbox;
		private System.Windows.Forms.TextBox fullTimeTextbox;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox progressText;
	}
}

