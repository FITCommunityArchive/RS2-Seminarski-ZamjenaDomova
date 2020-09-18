namespace ZamjenaDomova.WinUI.Listings
{
    partial class frmListings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.LblDo = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.LblOd = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListings = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lokacija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Territory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.LblDo);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.LblOd);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Location = new System.Drawing.Point(12, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 555);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Lokacija";
            // 
            // dateTo
            // 
            this.dateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(274, 71);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(146, 27);
            this.dateTo.TabIndex = 16;
            // 
            // LblDo
            // 
            this.LblDo.AutoSize = true;
            this.LblDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDo.Location = new System.Drawing.Point(233, 74);
            this.LblDo.Name = "LblDo";
            this.LblDo.Size = new System.Drawing.Size(35, 18);
            this.LblDo.TabIndex = 15;
            this.LblDo.Text = "Do:";
            // 
            // dateFrom
            // 
            this.dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(66, 71);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(146, 27);
            this.dateFrom.TabIndex = 14;
            // 
            // LblOd
            // 
            this.LblOd.AutoSize = true;
            this.LblOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOd.Location = new System.Drawing.Point(25, 74);
            this.LblOd.Name = "LblOd";
            this.LblOd.Size = new System.Drawing.Size(35, 18);
            this.LblOd.TabIndex = 13;
            this.LblOd.Text = "Od:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(103, 29);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(317, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListings);
            this.groupBox1.Location = new System.Drawing.Point(22, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(969, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Korisnici";
            // 
            // dgvListings
            // 
            this.dgvListings.AllowUserToAddRows = false;
            this.dgvListings.AllowUserToDeleteRows = false;
            this.dgvListings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Lokacija,
            this.Territory,
            this.User,
            this.DateCreated});
            this.dgvListings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListings.Location = new System.Drawing.Point(4, 19);
            this.dgvListings.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListings.Name = "dgvListings";
            this.dgvListings.ReadOnly = true;
            this.dgvListings.RowHeadersWidth = 51;
            this.dgvListings.RowTemplate.Height = 24;
            this.dgvListings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListings.Size = new System.Drawing.Size(961, 402);
            this.dgvListings.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(457, 71);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(119, 26);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Prikazi";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Name";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Lokacija
            // 
            this.Lokacija.DataPropertyName = "City";
            this.Lokacija.HeaderText = "Lokacija";
            this.Lokacija.MinimumWidth = 6;
            this.Lokacija.Name = "Lokacija";
            this.Lokacija.ReadOnly = true;
            // 
            // Territory
            // 
            this.Territory.DataPropertyName = "TerritoryName";
            this.Territory.HeaderText = "Kanton";
            this.Territory.MinimumWidth = 6;
            this.Territory.Name = "Territory";
            this.Territory.ReadOnly = true;
            // 
            // User
            // 
            this.User.DataPropertyName = "UserName";
            this.User.HeaderText = "Korisnik";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Datum objavljivanja";
            this.DateCreated.MinimumWidth = 6;
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            // 
            // frmListings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 551);
            this.Controls.Add(this.panel1);
            this.Name = "frmListings";
            this.Text = "frmListings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListings;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label LblDo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label LblOd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lokacija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Territory;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
    }
}