namespace ParallelForEachFormApp
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
            listBox1 = new ListBox();
            btnGetir = new Button();
            btnArttir = new Button();
            btnIptal = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(58, 65);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(351, 319);
            listBox1.TabIndex = 0;
            // 
            // btnGetir
            // 
            btnGetir.Location = new Point(58, 26);
            btnGetir.Name = "btnGetir";
            btnGetir.Size = new Size(100, 23);
            btnGetir.TabIndex = 1;
            btnGetir.Text = "Getir";
            btnGetir.UseVisualStyleBackColor = true;
            btnGetir.Click += btnGetir_Click;
            // 
            // btnArttir
            // 
            btnArttir.Location = new Point(309, 26);
            btnArttir.Name = "btnArttir";
            btnArttir.Size = new Size(100, 23);
            btnArttir.TabIndex = 2;
            btnArttir.Text = "Arttır";
            btnArttir.UseVisualStyleBackColor = true;
            btnArttir.Click += btnArttir_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(182, 26);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(100, 23);
            btnIptal.TabIndex = 3;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIptal);
            Controls.Add(btnArttir);
            Controls.Add(btnGetir);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button btnGetir;
        private Button btnArttir;
        private Button btnIptal;
    }
}
