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
        bool IsStartDateNull = true;
        bool IsEndDateNull = true;
        public frmListings()
        {
            InitializeComponent();
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = " ";
            dtpStart.CustomFormat = " ";
            dgvListings.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest
            {
                Approved = true,
                City = txtCity.Text,
            };

            if (IsStartDateNull) 
                request.StartDate = null;
            else request.StartDate = dtpStart.Value; 
            
            if (IsEndDateNull) 
                request.EndDate = null;
            else request.EndDate = dtpEnd.Value;

            var result = await _listingService.Get<List<Listing>>(request);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;
        }

        private void lblClear_MouseClick(object sender, MouseEventArgs e)
        {
            dtpEnd.CustomFormat = " ";
            dtpStart.CustomFormat = " ";
            IsStartDateNull = true;
            IsEndDateNull = true;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpStart.CustomFormat = "dd/MM/yyyy";
            IsStartDateNull = false;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            IsEndDateNull = false;
        }
    }
}
