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
using ZamjenaDomova.WinUI.Reports;
using ZamjenaDomova.WinUI.Users;

namespace ZamjenaDomova.WinUI
{
    public partial class frmIndex : Form
    {
        public frmIndex()
        {
            InitializeComponent();
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
            if (btnNewUser.Checked)
            {
                btnNewUser.Checked = false;
                frmUserDetails frm = new frmUserDetails();
                frm.Show();
            }
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

        private void btnReports_CheckedChanged(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(panelMain);
            PanelHelper.AddPanel(panelMain, new ucReports());
        }
    }
}
