namespace ISA_TimSukses
{
    partial class FormPemesananDriver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPemesananDriver));
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewDaftarPemesanan = new System.Windows.Forms.DataGridView();
            this.radioButtonOrderanMasuk = new System.Windows.Forms.RadioButton();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonRiwayatOrderan = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatusAktif = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaftarPemesanan)).BeginInit();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(919, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(271, 55);
            this.label4.TabIndex = 22;
            this.label4.Text = "ORDERAN";
            // 
            // dataGridViewDaftarPemesanan
            // 
            this.dataGridViewDaftarPemesanan.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDaftarPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDaftarPemesanan.Location = new System.Drawing.Point(36, 128);
            this.dataGridViewDaftarPemesanan.Name = "dataGridViewDaftarPemesanan";
            this.dataGridViewDaftarPemesanan.RowHeadersWidth = 62;
            this.dataGridViewDaftarPemesanan.RowTemplate.Height = 28;
            this.dataGridViewDaftarPemesanan.Size = new System.Drawing.Size(1167, 351);
            this.dataGridViewDaftarPemesanan.TabIndex = 21;
            this.dataGridViewDaftarPemesanan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDaftarPemesanan_CellContentClick);
            // 
            // radioButtonOrderanMasuk
            // 
            this.radioButtonOrderanMasuk.AutoSize = true;
            this.radioButtonOrderanMasuk.Checked = true;
            this.radioButtonOrderanMasuk.Location = new System.Drawing.Point(6, 0);
            this.radioButtonOrderanMasuk.Name = "radioButtonOrderanMasuk";
            this.radioButtonOrderanMasuk.Size = new System.Drawing.Size(186, 27);
            this.radioButtonOrderanMasuk.TabIndex = 24;
            this.radioButtonOrderanMasuk.TabStop = true;
            this.radioButtonOrderanMasuk.Text = "Orderan Masuk";
            this.radioButtonOrderanMasuk.UseVisualStyleBackColor = true;
            this.radioButtonOrderanMasuk.CheckedChanged += new System.EventHandler(this.radioButtonOrderanMasuk_CheckedChanged);
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxMode.Controls.Add(this.radioButtonRiwayatOrderan);
            this.groupBoxMode.Controls.Add(this.radioButtonOrderanMasuk);
            this.groupBoxMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMode.Location = new System.Drawing.Point(713, 93);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(490, 31);
            this.groupBoxMode.TabIndex = 25;
            this.groupBoxMode.TabStop = false;
            // 
            // radioButtonRiwayatOrderan
            // 
            this.radioButtonRiwayatOrderan.AutoSize = true;
            this.radioButtonRiwayatOrderan.Location = new System.Drawing.Point(205, 0);
            this.radioButtonRiwayatOrderan.Name = "radioButtonRiwayatOrderan";
            this.radioButtonRiwayatOrderan.Size = new System.Drawing.Size(272, 27);
            this.radioButtonRiwayatOrderan.TabIndex = 25;
            this.radioButtonRiwayatOrderan.Text = "Riwayat Semua Orderan";
            this.radioButtonRiwayatOrderan.UseVisualStyleBackColor = true;
            this.radioButtonRiwayatOrderan.CheckedChanged += new System.EventHandler(this.radioButtonRiwayatOrderan_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(36, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 37);
            this.label1.TabIndex = 26;
            this.label1.Text = "Orderan Aktif : ";
            // 
            // labelStatusAktif
            // 
            this.labelStatusAktif.AutoSize = true;
            this.labelStatusAktif.BackColor = System.Drawing.Color.Transparent;
            this.labelStatusAktif.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusAktif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelStatusAktif.Location = new System.Drawing.Point(273, 88);
            this.labelStatusAktif.Name = "labelStatusAktif";
            this.labelStatusAktif.Size = new System.Drawing.Size(173, 37);
            this.labelStatusAktif.TabIndex = 27;
            this.labelStatusAktif.Text = "Tidak Ada";
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonBack.Location = new System.Drawing.Point(36, 487);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(117, 64);
            this.buttonBack.TabIndex = 33;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click_1);
            // 
            // FormPemesananDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1215, 563);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelStatusAktif);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewDaftarPemesanan);
            this.DoubleBuffered = true;
            this.Name = "FormPemesananDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ORDERAN";
            this.Load += new System.EventHandler(this.FormPemesananDriver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaftarPemesanan)).EndInit();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewDaftarPemesanan;
        private System.Windows.Forms.RadioButton radioButtonOrderanMasuk;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButtonRiwayatOrderan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatusAktif;
        private System.Windows.Forms.Button buttonBack;
    }
}