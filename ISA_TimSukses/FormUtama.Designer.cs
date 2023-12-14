namespace ISA_TimSukses
{
    partial class FormUtama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUtama));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.topUpDllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riwayatPemesananToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahAdminStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topUpDllToolStripMenuItem,
            this.pesanToolStripMenuItem,
            this.riwayatPemesananToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.verifikasiToolStripMenuItem,
            this.orderanToolStripMenuItem,
            this.tambahAdminStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(988, 34);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // topUpDllToolStripMenuItem
            // 
            this.topUpDllToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topUpDllToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.topUpDllToolStripMenuItem.Name = "topUpDllToolStripMenuItem";
            this.topUpDllToolStripMenuItem.Size = new System.Drawing.Size(106, 30);
            this.topUpDllToolStripMenuItem.Text = "Top Up";
            this.topUpDllToolStripMenuItem.Click += new System.EventHandler(this.topUpDllToolStripMenuItem_Click);
            // 
            // pesanToolStripMenuItem
            // 
            this.pesanToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pesanToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pesanToolStripMenuItem.Name = "pesanToolStripMenuItem";
            this.pesanToolStripMenuItem.Size = new System.Drawing.Size(94, 30);
            this.pesanToolStripMenuItem.Text = "Pesan";
            this.pesanToolStripMenuItem.Click += new System.EventHandler(this.pesanToolStripMenuItem_Click);
            // 
            // riwayatPemesananToolStripMenuItem
            // 
            this.riwayatPemesananToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riwayatPemesananToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.riwayatPemesananToolStripMenuItem.Name = "riwayatPemesananToolStripMenuItem";
            this.riwayatPemesananToolStripMenuItem.Size = new System.Drawing.Size(244, 30);
            this.riwayatPemesananToolStripMenuItem.Text = "Riwayat Pemesanan";
            this.riwayatPemesananToolStripMenuItem.Click += new System.EventHandler(this.riwayatPemesananToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(98, 30);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // verifikasiToolStripMenuItem
            // 
            this.verifikasiToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifikasiToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.verifikasiToolStripMenuItem.Name = "verifikasiToolStripMenuItem";
            this.verifikasiToolStripMenuItem.Size = new System.Drawing.Size(129, 30);
            this.verifikasiToolStripMenuItem.Text = "Verifikasi";
            this.verifikasiToolStripMenuItem.Click += new System.EventHandler(this.verifikasiToolStripMenuItem_Click);
            // 
            // orderanToolStripMenuItem
            // 
            this.orderanToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderanToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.orderanToolStripMenuItem.Name = "orderanToolStripMenuItem";
            this.orderanToolStripMenuItem.Size = new System.Drawing.Size(118, 30);
            this.orderanToolStripMenuItem.Text = "Orderan";
            this.orderanToolStripMenuItem.Click += new System.EventHandler(this.orderanToolStripMenuItem_Click);
            // 
            // tambahAdminStripMenuItem
            // 
            this.tambahAdminStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tambahAdminStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tambahAdminStripMenuItem.Name = "tambahAdminStripMenuItem";
            this.tambahAdminStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.tambahAdminStripMenuItem.Text = "Tambah Admin";
            this.tambahAdminStripMenuItem.Click += new System.EventHandler(this.tambahAdminStripMenuItem_Click);
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSaldo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelSaldo.Location = new System.Drawing.Point(143, 119);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(93, 32);
            this.labelSaldo.TabIndex = 9;
            this.labelSaldo.Text = "Saldo";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelNama.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelNama.Location = new System.Drawing.Point(718, 57);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(94, 32);
            this.labelNama.TabIndex = 8;
            this.labelNama.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(541, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "WELCOME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(35, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saldo : ";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelStatus.Location = new System.Drawing.Point(35, 69);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(96, 32);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Posisi";
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(988, 518);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelSaldo);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FormUtama";
            this.Text = "TAKE-IT";
            this.Load += new System.EventHandler(this.FormUtama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem topUpDllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riwayatPemesananToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifikasiToolStripMenuItem;
        public System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem orderanToolStripMenuItem;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolStripMenuItem tambahAdminStripMenuItem;
    }
}