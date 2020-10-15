using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WinUI.Listings
{
    public partial class ucApproveListings : UserControl
    {
        private readonly APIService _listingService = new APIService("Listing");
        public ucApproveListings()
        {
            InitializeComponent();
            dgvListings.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvListings.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private async void ucApproveListings_Load(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest { Approved = false };

            var result = await _listingService.Get<List<Listing>>(request);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;

            var count = result.Count;
            txtCount.Text = count.ToString();
        }

        private void dgvListings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvListings.SelectedRows[0].Cells[0].Value;
            frmListingDetails frm = new frmListingDetails(int.Parse(id.ToString()), false);
            frm.Show();
        }
    }
}
