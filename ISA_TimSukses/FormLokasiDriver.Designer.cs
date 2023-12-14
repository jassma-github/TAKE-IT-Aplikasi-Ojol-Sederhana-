namespace ISA_TimSukses
{
    partial class FormLokasiDriver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLokasiDriver));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonKirim = new System.Windows.Forms.Button();
            this.textBoxLokasi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(37, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Masukkan Lokasi Anda Saat ini";
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonBack.Location = new System.Drawing.Point(40, 222);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(117, 64);
            this.buttonBack.TabIndex = 32;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonKirim
            // 
            this.buttonKirim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonKirim.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKirim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonKirim.Location = new System.Drawing.Point(243, 222);
            this.buttonKirim.Name = "buttonKirim";
            this.buttonKirim.Size = new System.Drawing.Size(117, 64);
            this.buttonKirim.TabIndex = 31;
            this.buttonKirim.Text = "Kirim";
            this.buttonKirim.UseVisualStyleBackColor = true;
            this.buttonKirim.Click += new System.EventHandler(this.buttonKirim_Click);
            // 
            // textBoxLokasi
            // 
            this.textBoxLokasi.Location = new System.Drawing.Point(40, 156);
            this.textBoxLokasi.Multiline = true;
            this.textBoxLokasi.Name = "textBoxLokasi";
            this.textBoxLokasi.Size = new System.Drawing.Size(320, 35);
            this.textBoxLokasi.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(93, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 55);
            this.label4.TabIndex = 29;
            this.label4.Text = "LOKASI";
            // 
            // FormLokasiDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 318);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonKirim);
            this.Controls.Add(this.textBoxLokasi);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Name = "FormLokasiDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lokasi Driver";
            this.Load += new System.EventHandler(this.FormLokasiDriver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonKirim;
        private System.Windows.Forms.TextBox textBoxLokasi;
        private System.Windows.Forms.Label label4;
    }
}