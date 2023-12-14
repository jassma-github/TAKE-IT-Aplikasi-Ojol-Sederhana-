namespace ISA_TimSukses
{
    partial class FormHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            this.buttonBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewRiwayatPemesanan = new System.Windows.Forms.DataGridView();
            this.labelStatusAktif = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonRiwayat = new System.Windows.Forms.RadioButton();
            this.radioButtonPesananAktif = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRiwayatPemesanan)).BeginInit();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonBack.Location = new System.Drawing.Point(28, 482);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(117, 64);
            this.buttonBack.TabIndex = 26;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(574, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(499, 55);
            this.label4.TabIndex = 25;
            this.label4.Text = "RIWAYAT PESANAN";
            // 
            // dataGridViewRiwayatPemesanan
            // 
            this.dataGridViewRiwayatPemesanan.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRiwayatPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRiwayatPemesanan.Location = new System.Drawing.Point(28, 126);
            this.dataGridViewRiwayatPemesanan.Name = "dataGridViewRiwayatPemesanan";
            this.dataGridViewRiwayatPemesanan.RowHeadersWidth = 62;
            this.dataGridViewRiwayatPemesanan.RowTemplate.Height = 28;
            this.dataGridViewRiwayatPemesanan.Size = new System.Drawing.Size(1035, 344);
            this.dataGridViewRiwayatPemesanan.TabIndex = 24;
            this.dataGridViewRiwayatPemesanan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRiwayatPemesanan_CellContentClick);
            this.dataGridViewRiwayatPemesanan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRiwayatPemesanan_CellFormatting);
            // 
            // labelStatusAktif
            // 
            this.labelStatusAktif.AutoSize = true;
            this.labelStatusAktif.BackColor = System.Drawing.Color.Transparent;
            this.labelStatusAktif.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusAktif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelStatusAktif.Location = new System.Drawing.Point(267, 86);
            this.labelStatusAktif.Name = "labelStatusAktif";
            this.labelStatusAktif.Size = new System.Drawing.Size(173, 37);
            this.labelStatusAktif.TabIndex = 30;
            this.labelStatusAktif.Text = "Tidak Ada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(30, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "Pesanan Aktif : ";
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxMode.Controls.Add(this.radioButtonRiwayat);
            this.groupBoxMode.Controls.Add(this.radioButtonPesananAktif);
            this.groupBoxMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMode.Location = new System.Drawing.Point(589, 92);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(490, 31);
            this.groupBoxMode.TabIndex = 28;
            this.groupBoxMode.TabStop = false;
            // 
            // radioButtonRiwayat
            // 
            this.radioButtonRiwayat.AutoSize = true;
            this.radioButtonRiwayat.Location = new System.Drawing.Point(205, 0);
            this.radioButtonRiwayat.Name = "radioButtonRiwayat";
            this.radioButtonRiwayat.Size = new System.Drawing.Size(273, 27);
            this.radioButtonRiwayat.TabIndex = 25;
            this.radioButtonRiwayat.Text = "Riwayat Semua Pesanan";
            this.radioButtonRiwayat.UseVisualStyleBackColor = true;
            this.radioButtonRiwayat.CheckedChanged += new System.EventHandler(this.radioButtonRiwayat_CheckedChanged);
            // 
            // radioButtonPesananAktif
            // 
            this.radioButtonPesananAktif.AutoSize = true;
            this.radioButtonPesananAktif.Checked = true;
            this.radioButtonPesananAktif.Location = new System.Drawing.Point(6, 0);
            this.radioButtonPesananAktif.Name = "radioButtonPesananAktif";
            this.radioButtonPesananAktif.Size = new System.Drawing.Size(168, 27);
            this.radioButtonPesananAktif.TabIndex = 24;
            this.radioButtonPesananAktif.TabStop = true;
            this.radioButtonPesananAktif.Text = "Pesanan Aktif";
            this.radioButtonPesananAktif.UseVisualStyleBackColor = true;
            this.radioButtonPesananAktif.CheckedChanged += new System.EventHandler(this.radioButtonPesananAktif_CheckedChanged);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1088, 556);
            this.Controls.Add(this.labelStatusAktif);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewRiwayatPemesanan);
            this.DoubleBuffered = true;
            this.Name = "FormHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riwayat Pesanan";
            this.Load += new System.EventHandler(this.FormHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRiwayatPemesanan)).EndInit();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewRiwayatPemesanan;
        private System.Windows.Forms.Label labelStatusAktif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButtonRiwayat;
        private System.Windows.Forms.RadioButton radioButtonPesananAktif;
    }
}