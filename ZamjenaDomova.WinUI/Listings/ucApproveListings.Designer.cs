namespace ZamjenaDomova.WinUI.Listings
{
    partial class ucApproveListings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListings = new System.Windows.Forms.DataGridView();
            this.ListingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lokacija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Territory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(198, 24);
            this.txtCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(32, 22);
            this.txtCount.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Neodobreni oglasi:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.dgvListings);
            this.groupBox1.Location = new System.Drawing.Point(32, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(815, 342);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dgvListings
            // 
            this.dgvListings.AllowUserToAddRows = false;
            this.dgvListings.AllowUserToDeleteRows = false;
            this.dgvListings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListings.ColumnHeadersHeight = 29;
            this.dgvListings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ListingId,
            this.Naziv,
            this.Lokacija,
            this.Territory,
            this.User,
            this.DateCreated});
            this.dgvListings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListings.Location = new System.Drawing.Point(5, 20);
            this.dgvListings.Margin = new System.Windows.Forms.Padding(5);
            this.dgvListings.Name = "dgvListings";
            this.dgvListings.ReadOnly = true;
            this.dgvListings.RowHeadersWidth = 51;
            this.dgvListings.RowTemplate.Height = 24;
            this.dgvListings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListings.Size = new System.Drawing.Size(805, 317);
            this.dgvListings.TabIndex = 0;
            this.dgvListings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvListings_MouseDoubleClick);
            // 
            // ListingId
            // 
            this.ListingId.DataPropertyName = "ListingId";
            this.ListingId.HeaderText = "ListingId";
            this.ListingId.MinimumWidth = 6;
            this.ListingId.Name = "ListingId";
            this.ListingId.ReadOnly = true;
            this.ListingId.Visible = false;
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
            // ucApproveListings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label1);
            this.Name = "ucApproveListings";
            this.Size = new System.Drawing.Size(868, 449);
            this.Load += new System.EventHandler(this.ucApproveListings_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lokacija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Territory;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
    }
}
