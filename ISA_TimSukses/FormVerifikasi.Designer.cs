namespace ISA_TimSukses
{
    partial class FormVerifikasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerifikasi));
            this.buttonBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewDaftarPemesanan = new System.Windows.Forms.DataGridView();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomer = new System.Windows.Forms.RadioButton();
            this.radioButtonDriver = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaftarPemesanan)).BeginInit();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonBack.Location = new System.Drawing.Point(27, 498);
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
            this.label4.Location = new System.Drawing.Point(617, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 55);
            this.label4.TabIndex = 25;
            this.label4.Text = "VERIFIKASI";
            // 
            // dataGridViewDaftarPemesanan
            // 
            this.dataGridViewDaftarPemesanan.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDaftarPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDaftarPemesanan.Location = new System.Drawing.Point(27, 143);
            this.dataGridViewDaftarPemesanan.Name = "dataGridViewDaftarPemesanan";
            this.dataGridViewDaftarPemesanan.RowHeadersWidth = 62;
            this.dataGridViewDaftarPemesanan.RowTemplate.Height = 28;
            this.dataGridViewDaftarPemesanan.Size = new System.Drawing.Size(879, 344);
            this.dataGridViewDaftarPemesanan.TabIndex = 24;
            this.dataGridViewDaftarPemesanan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDaftarPemesanan_CellContentClick);
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxMode.Controls.Add(this.radioButtonCustomer);
            this.groupBoxMode.Controls.Add(this.radioButtonDriver);
            this.groupBoxMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMode.Location = new System.Drawing.Point(601, 107);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(305, 31);
            this.groupBoxMode.TabIndex = 27;
            this.groupBoxMode.TabStop = false;
            // 
            // radioButtonCustomer
            // 
            this.radioButtonCustomer.AutoSize = true;
            this.radioButtonCustomer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCustomer.Location = new System.Drawing.Point(158, 0);
            this.radioButtonCustomer.Name = "radioButtonCustomer";
            this.radioButtonCustomer.Size = new System.Drawing.Size(150, 32);
            this.radioButtonCustomer.TabIndex = 25;
            this.radioButtonCustomer.Text = "Customer";
            this.radioButtonCustomer.UseVisualStyleBackColor = true;
            this.radioButtonCustomer.CheckedChanged += new System.EventHandler(this.radioButtonCustomer_CheckedChanged);
            // 
            // radioButtonDriver
            // 
            this.radioButtonDriver.AutoSize = true;
            this.radioButtonDriver.Checked = true;
            this.radioButtonDriver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDriver.Location = new System.Drawing.Point(6, 0);
            this.radioButtonDriver.Name = "radioButtonDriver";
            this.radioButtonDriver.Size = new System.Drawing.Size(111, 32);
            this.radioButtonDriver.TabIndex = 24;
            this.radioButtonDriver.TabStop = true;
            this.radioButtonDriver.Text = "Driver";
            this.radioButtonDriver.UseVisualStyleBackColor = true;
            this.radioButtonDriver.CheckedChanged += new System.EventHandler(this.radioButtonDriver_CheckedChanged);
            // 
            // FormVerifikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(934, 574);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewDaftarPemesanan);
            this.DoubleBuffered = true;
            this.Name = "FormVerifikasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VERIFIKASI";
            this.Load += new System.EventHandler(this.FormVerifikasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaftarPemesanan)).EndInit();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewDaftarPemesanan;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButtonCustomer;
        private System.Windows.Forms.RadioButton radioButtonDriver;
    }
}