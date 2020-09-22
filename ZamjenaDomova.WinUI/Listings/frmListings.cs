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
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WinUI.Listings
{
    public partial class frmListings : Form
    {
        private readonly APIService _listingService = new APIService("Listing");

        public frmListings()
        {
            InitializeComponent();
        }

        private void dgvListings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvListings.SelectedRows[0].Cells[0].Value;
            frmListingDetails frm = new frmListingDetails(int.Parse(id.ToString()), true);
            frm.Show();
        }

        private async void frmListings_Load(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest { Approved = true };

            var result = await _listingService.Get<List<Listing>>(request);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;

        }
    }
}
