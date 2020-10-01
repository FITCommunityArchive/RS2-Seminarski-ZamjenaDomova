namespace ZamjenaDomova.WinUI.Reports
{
    partial class ucReports
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
            this.btnListingsCount = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnTopRated = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListingsCount
            // 
            this.btnListingsCount.AutoSize = true;
            this.btnListingsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListingsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListingsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnListingsCount.Location = new System.Drawing.Point(3, 3);
            this.btnListingsCount.Name = "btnListingsCount";
            this.btnListingsCount.Size = new System.Drawing.Size(241, 45);
            this.btnListingsCount.TabIndex = 0;
            this.btnListingsCount.Text = "Broj oglasa po gradovima";
            this.btnListingsCount.UseVisualStyleBackColor = true;
            this.btnListingsCount.Click += new System.EventHandler(this.btnListingsCount_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.AutoSize = true;
            this.btnDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDetails.Location = new System.Drawing.Point(497, 3);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(277, 45);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "Detalji svih oglasa";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // btnTopRated
            // 
            this.btnTopRated.AutoSize = true;
            this.btnTopRated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTopRated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopRated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTopRated.Location = new System.Drawing.Point(250, 3);
            this.btnTopRated.Name = "btnTopRated";
            this.btnTopRated.Size = new System.Drawing.Size(241, 45);
            this.btnTopRated.TabIndex = 2;
            this.btnTopRated.Text = "Najbolje ocijenjeni domovi";
            this.btnTopRated.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.85513F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.85513F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.28974F));
            this.tableLayoutPanel1.Controls.Add(this.btnDetails, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTopRated, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnListingsCount, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 41);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 51);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pnlReports
            // 
            this.pnlReports.Location = new System.Drawing.Point(11, 115);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(815, 312);
            this.pnlReports.TabIndex = 5;
            // 
            // ucReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlReports);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucReports";
            this.Size = new System.Drawing.Size(836, 430);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListingsCount;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnTopRated;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlReports;
    }
}
