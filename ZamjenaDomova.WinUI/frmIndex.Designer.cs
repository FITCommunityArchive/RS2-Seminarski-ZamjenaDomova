﻿namespace ZamjenaDomova.WinUI
{
    partial class frmIndex
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sadržajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oglasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sviOglasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnReports = new System.Windows.Forms.RadioButton();
            this.btnApprove = new System.Windows.Forms.RadioButton();
            this.btnListings = new System.Windows.Forms.RadioButton();
            this.btnAmenities = new System.Windows.Forms.RadioButton();
            this.btnNewUser = new System.Windows.Forms.RadioButton();
            this.btnUsers = new System.Windows.Forms.RadioButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.sadržajiToolStripMenuItem,
            this.oglasiToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(843, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem1,
            this.noviKorisnikToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(177, 26);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaToolStripMenuItem1_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // sadržajiToolStripMenuItem
            // 
            this.sadržajiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem});
            this.sadržajiToolStripMenuItem.Name = "sadržajiToolStripMenuItem";
            this.sadržajiToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.sadržajiToolStripMenuItem.Text = "Sadržaji";
            this.sadržajiToolStripMenuItem.Click += new System.EventHandler(this.sadržajiToolStripMenuItem_Click);
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // oglasiToolStripMenuItem
            // 
            this.oglasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sviOglasiToolStripMenuItem,
            this.odoToolStripMenuItem});
            this.oglasiToolStripMenuItem.Name = "oglasiToolStripMenuItem";
            this.oglasiToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.oglasiToolStripMenuItem.Text = "Oglasi";
            // 
            // sviOglasiToolStripMenuItem
            // 
            this.sviOglasiToolStripMenuItem.Name = "sviOglasiToolStripMenuItem";
            this.sviOglasiToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.sviOglasiToolStripMenuItem.Text = "Aktivni oglasi";
            this.sviOglasiToolStripMenuItem.Click += new System.EventHandler(this.sviOglasiToolStripMenuItem_Click);
            // 
            // odoToolStripMenuItem
            // 
            this.odoToolStripMenuItem.Name = "odoToolStripMenuItem";
            this.odoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.odoToolStripMenuItem.Text = "Odobravanje";
            this.odoToolStripMenuItem.Click += new System.EventHandler(this.odoToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // btnReports
            // 
            this.btnReports.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnReports.AutoSize = true;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReports.Location = new System.Drawing.Point(3, 426);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnReports.Size = new System.Drawing.Size(191, 64);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Izvještaji";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnApprove
            // 
            this.btnApprove.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnApprove.AutoSize = true;
            this.btnApprove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnApprove.Location = new System.Drawing.Point(3, 334);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnApprove.Size = new System.Drawing.Size(191, 64);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Odobravanje";
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnListings
            // 
            this.btnListings.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnListings.AutoSize = true;
            this.btnListings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnListings.Location = new System.Drawing.Point(3, 264);
            this.btnListings.Name = "btnListings";
            this.btnListings.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnListings.Size = new System.Drawing.Size(191, 64);
            this.btnListings.TabIndex = 1;
            this.btnListings.Text = "Oglasi";
            this.btnListings.UseVisualStyleBackColor = true;
            // 
            // btnAmenities
            // 
            this.btnAmenities.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnAmenities.AutoSize = true;
            this.btnAmenities.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAmenities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmenities.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAmenities.Location = new System.Drawing.Point(3, 172);
            this.btnAmenities.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.btnAmenities.Name = "btnAmenities";
            this.btnAmenities.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnAmenities.Size = new System.Drawing.Size(191, 64);
            this.btnAmenities.TabIndex = 4;
            this.btnAmenities.Text = "Sadržaji";
            this.btnAmenities.UseVisualStyleBackColor = true;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnNewUser.AutoSize = true;
            this.btnNewUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNewUser.Location = new System.Drawing.Point(3, 80);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnNewUser.Size = new System.Drawing.Size(191, 64);
            this.btnNewUser.TabIndex = 3;
            this.btnNewUser.Text = "Novi korisnik";
            this.btnNewUser.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsers.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUsers.AutoSize = true;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.Location = new System.Drawing.Point(3, 3);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnUsers.Size = new System.Drawing.Size(191, 64);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Korisnici";
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelMain.Size = new System.Drawing.Size(674, 504);
            this.panelMain.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelMain);
            this.splitContainer1.Size = new System.Drawing.Size(843, 504);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SeaGreen;
            this.flowLayoutPanel1.Controls.Add(this.btnUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnNewUser);
            this.flowLayoutPanel1.Controls.Add(this.btnAmenities);
            this.flowLayoutPanel1.Controls.Add(this.btnListings);
            this.flowLayoutPanel1.Controls.Add(this.btnApprove);
            this.flowLayoutPanel1.Controls.Add(this.btnReports);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(165, 504);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 558);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIndex";
            this.Text = "Ključ za ključ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem sadržajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oglasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sviOglasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odoToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton btnAmenities;
        private System.Windows.Forms.RadioButton btnNewUser;
        private System.Windows.Forms.RadioButton btnUsers;
        private System.Windows.Forms.RadioButton btnReports;
        private System.Windows.Forms.RadioButton btnApprove;
        private System.Windows.Forms.RadioButton btnListings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}



