namespace FordBellman
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pb_Bang = new System.Windows.Forms.PictureBox();
            this.bt_Reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_DSDinh = new System.Windows.Forms.ListBox();
            this.lb_DSCanh = new System.Windows.Forms.ListBox();
            this.bt_XoaDinh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_DinhDau = new System.Windows.Forms.TextBox();
            this.tb_DinhCuoi = new System.Windows.Forms.TextBox();
            this.tb_TrongSo = new System.Windows.Forms.TextBox();
            this.bt_Set_DoiTrongSo = new System.Windows.Forms.Button();
            this.bt_XoaCanh = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_MaTran = new System.Windows.Forms.TextBox();
            this.bt_DocMaTran = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Bang)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Bang
            // 
            this.pb_Bang.BackColor = System.Drawing.Color.White;
            this.pb_Bang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_Bang.Location = new System.Drawing.Point(418, 0);
            this.pb_Bang.Name = "pb_Bang";
            this.pb_Bang.Size = new System.Drawing.Size(644, 560);
            this.pb_Bang.TabIndex = 0;
            this.pb_Bang.TabStop = false;
            this.pb_Bang.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Bang_Paint);
            this.pb_Bang.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_Bang_MouseClick);
            // 
            // bt_Reset
            // 
            this.bt_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Reset.Location = new System.Drawing.Point(356, 31);
            this.bt_Reset.Name = "bt_Reset";
            this.bt_Reset.Size = new System.Drawing.Size(57, 25);
            this.bt_Reset.TabIndex = 1;
            this.bt_Reset.Text = "Reset";
            this.bt_Reset.UseVisualStyleBackColor = true;
            this.bt_Reset.Click += new System.EventHandler(this.bt_Reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "DS cạnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "DS đỉnh";
            // 
            // lb_DSDinh
            // 
            this.lb_DSDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DSDinh.FormattingEnabled = true;
            this.lb_DSDinh.ItemHeight = 16;
            this.lb_DSDinh.Location = new System.Drawing.Point(13, 59);
            this.lb_DSDinh.Name = "lb_DSDinh";
            this.lb_DSDinh.Size = new System.Drawing.Size(80, 84);
            this.lb_DSDinh.TabIndex = 4;
            // 
            // lb_DSCanh
            // 
            this.lb_DSCanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DSCanh.FormattingEnabled = true;
            this.lb_DSCanh.ItemHeight = 16;
            this.lb_DSCanh.Location = new System.Drawing.Point(99, 59);
            this.lb_DSCanh.Name = "lb_DSCanh";
            this.lb_DSCanh.Size = new System.Drawing.Size(80, 84);
            this.lb_DSCanh.TabIndex = 5;
            // 
            // bt_XoaDinh
            // 
            this.bt_XoaDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_XoaDinh.Location = new System.Drawing.Point(13, 149);
            this.bt_XoaDinh.Name = "bt_XoaDinh";
            this.bt_XoaDinh.Size = new System.Drawing.Size(80, 32);
            this.bt_XoaDinh.TabIndex = 6;
            this.bt_XoaDinh.Text = "Xóa đỉnh";
            this.bt_XoaDinh.UseVisualStyleBackColor = true;
            this.bt_XoaDinh.Click += new System.EventHandler(this.bt_XoaDinh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đỉnh đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Đỉnh cuối";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Trọng số";
            // 
            // tb_DinhDau
            // 
            this.tb_DinhDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DinhDau.Location = new System.Drawing.Point(262, 56);
            this.tb_DinhDau.Name = "tb_DinhDau";
            this.tb_DinhDau.Size = new System.Drawing.Size(63, 26);
            this.tb_DinhDau.TabIndex = 10;
            // 
            // tb_DinhCuoi
            // 
            this.tb_DinhCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DinhCuoi.Location = new System.Drawing.Point(262, 88);
            this.tb_DinhCuoi.Name = "tb_DinhCuoi";
            this.tb_DinhCuoi.Size = new System.Drawing.Size(63, 26);
            this.tb_DinhCuoi.TabIndex = 11;
            // 
            // tb_TrongSo
            // 
            this.tb_TrongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TrongSo.Location = new System.Drawing.Point(262, 120);
            this.tb_TrongSo.Name = "tb_TrongSo";
            this.tb_TrongSo.Size = new System.Drawing.Size(63, 26);
            this.tb_TrongSo.TabIndex = 12;
            // 
            // bt_Set_DoiTrongSo
            // 
            this.bt_Set_DoiTrongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Set_DoiTrongSo.Location = new System.Drawing.Point(185, 149);
            this.bt_Set_DoiTrongSo.Name = "bt_Set_DoiTrongSo";
            this.bt_Set_DoiTrongSo.Size = new System.Drawing.Size(140, 32);
            this.bt_Set_DoiTrongSo.TabIndex = 13;
            this.bt_Set_DoiTrongSo.Text = "Set / Đổi trọng số";
            this.bt_Set_DoiTrongSo.UseVisualStyleBackColor = true;
            this.bt_Set_DoiTrongSo.Click += new System.EventHandler(this.bt_Set_DoiTrongSo_Click);
            // 
            // bt_XoaCanh
            // 
            this.bt_XoaCanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_XoaCanh.Location = new System.Drawing.Point(99, 149);
            this.bt_XoaCanh.Name = "bt_XoaCanh";
            this.bt_XoaCanh.Size = new System.Drawing.Size(80, 32);
            this.bt_XoaCanh.TabIndex = 14;
            this.bt_XoaCanh.Text = "Xóa cạnh";
            this.bt_XoaCanh.UseVisualStyleBackColor = true;
            this.bt_XoaCanh.Click += new System.EventHandler(this.bt_XoaCanh_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1061, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.save,
            this.saveAs});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(138, 24);
            this.open.Text = "Open...";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(138, 24);
            this.save.Text = "Save...";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // saveAs
            // 
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(138, 24);
            this.saveAs.Text = "Save As...";
            this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
            // 
            // tb_MaTran
            // 
            this.tb_MaTran.Enabled = false;
            this.tb_MaTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaTran.Location = new System.Drawing.Point(13, 187);
            this.tb_MaTran.Multiline = true;
            this.tb_MaTran.Name = "tb_MaTran";
            this.tb_MaTran.ReadOnly = true;
            this.tb_MaTran.Size = new System.Drawing.Size(166, 166);
            this.tb_MaTran.TabIndex = 16;
            // 
            // bt_DocMaTran
            // 
            this.bt_DocMaTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DocMaTran.Location = new System.Drawing.Point(185, 187);
            this.bt_DocMaTran.Name = "bt_DocMaTran";
            this.bt_DocMaTran.Size = new System.Drawing.Size(75, 46);
            this.bt_DocMaTran.TabIndex = 17;
            this.bt_DocMaTran.Text = "Đọc ma trận";
            this.bt_DocMaTran.UseVisualStyleBackColor = true;
            this.bt_DocMaTran.Click += new System.EventHandler(this.bt_DocMaTran_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 538);
            this.Controls.Add(this.bt_DocMaTran);
            this.Controls.Add(this.tb_MaTran);
            this.Controls.Add(this.bt_XoaCanh);
            this.Controls.Add(this.bt_Set_DoiTrongSo);
            this.Controls.Add(this.tb_TrongSo);
            this.Controls.Add(this.tb_DinhCuoi);
            this.Controls.Add(this.tb_DinhDau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_XoaDinh);
            this.Controls.Add(this.lb_DSCanh);
            this.Controls.Add(this.lb_DSDinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Reset);
            this.Controls.Add(this.pb_Bang);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1081, 581);
            this.MinimumSize = new System.Drawing.Size(1081, 581);
            this.Name = "Form1";
            this.Text = "Graph Theory";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Bang)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Bang;
        private System.Windows.Forms.Button bt_Reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_DSDinh;
        private System.Windows.Forms.ListBox lb_DSCanh;
        private System.Windows.Forms.Button bt_XoaDinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_DinhDau;
        private System.Windows.Forms.TextBox tb_DinhCuoi;
        private System.Windows.Forms.TextBox tb_TrongSo;
        private System.Windows.Forms.Button bt_Set_DoiTrongSo;
        private System.Windows.Forms.Button bt_XoaCanh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem saveAs;
        private System.Windows.Forms.TextBox tb_MaTran;
        private System.Windows.Forms.Button bt_DocMaTran;
    }
}

