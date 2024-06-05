namespace TaskCancellationFormApp
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
            btnBaslat = new Button();
            btnDurdur = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnBaslat
            // 
            btnBaslat.Location = new Point(34, 27);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(75, 23);
            btnBaslat.TabIndex = 0;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // btnDurdur
            // 
            btnDurdur.Location = new Point(141, 27);
            btnDurdur.Name = "btnDurdur";
            btnDurdur.Size = new Size(75, 23);
            btnDurdur.TabIndex = 1;
            btnDurdur.Text = "Durdur";
            btnDurdur.UseVisualStyleBackColor = true;
            btnDurdur.Click += btnDurdur_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(34, 72);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(182, 173);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(btnDurdur);
            Controls.Add(btnBaslat);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBaslat;
        private Button btnDurdur;
        private RichTextBox richTextBox1;
    }
}
