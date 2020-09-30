using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.WinUI.Amenities;
using ZamjenaDomova.WinUI.Listings;
using ZamjenaDomova.WinUI.Users;

namespace ZamjenaDomova.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        private void frmIndex_Load(object sender, EventArgs e)
        {
            //buttons styling
            //btnAmenities
            btnAmenities.FlatAppearance.BorderSize = 0;
            btnAmenities.BackColor = System.Drawing.Color.Transparent;
            btnAmenities.FlatAppearance.MouseOverBackColor= System.Drawing.Color.FromArgb(50, 255, 255, 255);
            btnAmenities.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255);
            
            //btnUsers
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.BackColor = System.Drawing.Color.Transparent;
            btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            btnUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255);

            //btnNewUser
            btnNewUser.FlatAppearance.BorderSize = 0;
            btnNewUser.BackColor = System.Drawing.Color.Transparent;
            btnNewUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            btnNewUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255);

            //btnListings
            btnListings.FlatAppearance.BorderSize = 0;
            btnListings.BackColor = System.Drawing.Color.Transparent;
            btnListings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            btnListings.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255);

            //btnApprove
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.BackColor = System.Drawing.Color.Transparent;
            btnApprove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            btnApprove.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255);

            //btnReports
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.BackColor = System.Drawing.Color.Transparent;
            btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            btnReports.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255);

        }



        private void btnUsers_CheckedChanged(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(panelMain);
            PanelHelper.AddPanel(panelMain, new ucUsers());
        }

        private void btnNewUser_CheckedChanged(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails();
            frm.Show();
        }

        private void btnAmenities_CheckedChanged(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(panelMain);
            PanelHelper.AddPanel(panelMain, new ucAmenities());
        }

        private void btnListings_CheckedChanged(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(panelMain);
            PanelHelper.AddPanel(panelMain, new ucListings());
        }

        private void btnApprove_CheckedChanged(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(panelMain);
            PanelHelper.AddPanel(panelMain, new ucApproveListings());
        }

    }
}
