namespace ZamjenaDomova.WinUI.Amenities
{
    partial class frmAmenities
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAmenities = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmenities)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAmenities);
            this.groupBox1.Location = new System.Drawing.Point(13, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amenities";
            // 
            // dgvAmenities
            // 
            this.dgvAmenities.AllowUserToAddRows = false;
            this.dgvAmenities.AllowUserToDeleteRows = false;
            this.dgvAmenities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmenities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAmenities.Location = new System.Drawing.Point(3, 18);
            this.dgvAmenities.Name = "dgvAmenities";
            this.dgvAmenities.ReadOnly = true;
            this.dgvAmenities.RowHeadersWidth = 51;
            this.dgvAmenities.RowTemplate.Height = 24;
            this.dgvAmenities.Size = new System.Drawing.Size(769, 328);
            this.dgvAmenities.TabIndex = 0;
            // 
            // frmAmenities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAmenities";
            this.Text = "frmAmenities";
            this.Load += new System.EventHandler(this.frmAmenities_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmenities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAmenities;
    }
}