using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WinUI.Listings
{
    public partial class frmApproveListings : Form
    {
        private readonly APIService _listingService = new APIService("Listing");
        public frmApproveListings()
        {
            InitializeComponent();
        }
        private async void frmApproveListings_Load(object sender, EventArgs e)
        {
            var result = await _listingService.Get<List<Listing>>(null);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;
        }

        private void dgvListings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
