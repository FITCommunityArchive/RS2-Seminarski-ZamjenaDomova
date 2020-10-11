using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZamjenaDomova.WinUI.Reports
{
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
        }

        private void btnListingsCount_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(pnlReports);
            PanelHelper.AddPanel(pnlReports, new ucListingsCount());
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(pnlReports);
            PanelHelper.AddPanel(pnlReports, new ucListingDetails());
        }

        private void btnTopRated_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(pnlReports);
            PanelHelper.AddPanel(pnlReports, new ucHighestRatedListings());
        }
    }
}
