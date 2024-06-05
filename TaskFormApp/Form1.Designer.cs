namespace TaskFormApp
{
    partial class Form1
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
            btnReadFile = new Button();
            richTextBoxDosya = new RichTextBox();
            btnCounter = new Button();
            textBoxCounter = new TextBox();
            richTextBox2 = new RichTextBox();
            groupOrnek1 = new GroupBox();
            groupOrnek2 = new GroupBox();
            btnCounter2 = new Button();
            btnStart = new Button();
            progressBar2 = new ProgressBar();
            progressBar1 = new ProgressBar();
            groupOrnek1.SuspendLayout();
            groupOrnek2.SuspendLayout();
            SuspendLayout();
            // 
            // btnReadFile
            // 
            btnReadFile.Location = new Point(42, 39);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(185, 23);
            btnReadFile.TabIndex = 0;
            btnReadFile.Text = "Dosya Oku";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // richTextBoxDosya
            // 
            richTextBoxDosya.Location = new Point(42, 80);
            richTextBoxDosya.Name = "richTextBoxDosya";
            richTextBoxDosya.Size = new Size(185, 136);
            richTextBoxDosya.TabIndex = 1;
            richTextBoxDosya.Text = "";
            // 
            // btnCounter
            // 
            btnCounter.Location = new Point(272, 39);
            btnCounter.Name = "btnCounter";
            btnCounter.Size = new Size(100, 23);
            btnCounter.TabIndex = 2;
            btnCounter.Text = "Sayaç Artır";
            btnCounter.UseVisualStyleBackColor = true;
            btnCounter.Click += btnCounter_Click;
            // 
            // textBoxCounter
            // 
            textBoxCounter.Location = new Point(272, 80);
            textBoxCounter.Name = "textBoxCounter";
            textBoxCounter.Size = new Size(100, 23);
            textBoxCounter.TabIndex = 3;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(420, 80);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(185, 136);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "";
            // 
            // groupOrnek1
            // 
            groupOrnek1.Controls.Add(btnReadFile);
            groupOrnek1.Controls.Add(richTextBox2);
            groupOrnek1.Controls.Add(richTextBoxDosya);
            groupOrnek1.Controls.Add(textBoxCounter);
            groupOrnek1.Controls.Add(btnCounter);
            groupOrnek1.Location = new Point(30, 25);
            groupOrnek1.Name = "groupOrnek1";
            groupOrnek1.Size = new Size(647, 248);
            groupOrnek1.TabIndex = 5;
            groupOrnek1.TabStop = false;
            groupOrnek1.Text = "Örnek 1";
            // 
            // groupOrnek2
            // 
            groupOrnek2.Controls.Add(btnCounter2);
            groupOrnek2.Controls.Add(btnStart);
            groupOrnek2.Controls.Add(progressBar2);
            groupOrnek2.Controls.Add(progressBar1);
            groupOrnek2.Location = new Point(30, 300);
            groupOrnek2.Name = "groupOrnek2";
            groupOrnek2.Size = new Size(647, 269);
            groupOrnek2.TabIndex = 6;
            groupOrnek2.TabStop = false;
            groupOrnek2.Text = "Örnek 2";
            // 
            // btnCounter2
            // 
            btnCounter2.Location = new Point(139, 54);
            btnCounter2.Name = "btnCounter2";
            btnCounter2.Size = new Size(75, 23);
            btnCounter2.TabIndex = 3;
            btnCounter2.Text = "Sayaç";
            btnCounter2.UseVisualStyleBackColor = true;
            btnCounter2.Click += btnCounter2_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(42, 54);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Başlat";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(42, 164);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(563, 23);
            progressBar2.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(42, 103);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(563, 23);
            progressBar1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 589);
            Controls.Add(groupOrnek2);
            Controls.Add(groupOrnek1);
            Name = "Form1";
            Text = "Form1";
            groupOrnek1.ResumeLayout(false);
            groupOrnek1.PerformLayout();
            groupOrnek2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnReadFile;
        private RichTextBox richTextBoxDosya;
        private Button btnCounter;
        private TextBox textBoxCounter;
        private RichTextBox richTextBox2;
        private GroupBox groupOrnek1;
        private GroupBox groupOrnek2;
        private Button btnCounter2;
        private Button btnStart;
        private ProgressBar progressBar2;
        private ProgressBar progressBar1;
    }
}
