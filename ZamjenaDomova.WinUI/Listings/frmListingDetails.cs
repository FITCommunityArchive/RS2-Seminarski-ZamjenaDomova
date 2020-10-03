using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WinUI.Listings
{
    public partial class frmListingDetails : Form
    {
        private readonly APIService _listingService = new APIService("Listing");
        private readonly APIService _listingAmenityService = new APIService("ListingAmenity");

        private static int _id;
        private bool _approved;
        public frmListingDetails(int listingId, bool approved)
        {
            InitializeComponent();
            _id = listingId;
            _approved = approved;
        }

        private async void frmListingDetails_Load(object sender, EventArgs e)
        {
            if (_approved)
            {
                btnApprove.Hide();
                btnReject.Hide();
            }
            var listingAmenities = await _listingAmenityService
                .Get<List<Model.AmenityModel>>(new ListingAmenitySearchRequest { ListingId = _id });
            clbAmenities.DataSource = listingAmenities;
            clbAmenities.DisplayMember = "Name";
            clbAmenities.ValueMember = "AmenityId";

            for (int i = 0; i < clbAmenities.Items.Count; i++)
                clbAmenities.SetItemChecked(i, true);

            try
            {
                var listing = await _listingService.GetById<Model.Listing>(_id);

                txtName.Text = listing.Name;
                txtAddress.Text = listing.Address;
                txtCity.Text = listing.City;
                txtTerritory.Text = listing.TerritoryName;
                txtHomeDesc.Text = listing.ListingDescription;
                txtAreaDesc.Text = listing.AreaDescription;
                txtPersons.Text = listing.Persons.ToString();
                txtBeds.Text = listing.Beds.ToString();
                txtBathrooms.Text = listing.Bathrooms.ToString();
                txtUser.Text = listing.UserName;
                txtDateCreated.Text = listing.DateCreated.ToString();

                //MemoryStream ms = new MemoryStream(user.Image);
                //Image image = Image.FromStream(ms);
                //pbAvatar.Image = image;
            }
            catch (Exception)
            {
                MessageBox.Show("Nemate pristup!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            ListingUpdateRequest request = new ListingUpdateRequest
            {
                Approved = true,
                ApprovalTime = DateTime.Now
            };
            await _listingService.Update<Model.Listing>(_id, request);
            MessageBox.Show("Oglas odobren!");
            this.Close();
            var frm = new ucApproveListings();
            var frmIndex = Application.OpenForms["frmIndex"];
            var panelContainer = frmIndex.Controls.Find("panelMain", true).FirstOrDefault() as Panel;
            PanelHelper.RemovePanels(panelContainer);
            PanelHelper.AddPanel(panelContainer, frm);
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            ListingUpdateRequest request = new ListingUpdateRequest
            {
                Approved = false
            };
            await _listingService.Update<Model.Listing>(_id, request);
            MessageBox.Show("Oglas odbijen!");
            this.Close();
            var frm = new ucApproveListings();
            var frmIndex = Application.OpenForms["frmIndex"];
            var panelContainer = frmIndex.Controls.Find("panelMain", true).FirstOrDefault() as Panel;
            PanelHelper.RemovePanels(panelContainer);
            PanelHelper.AddPanel(panelContainer, frm);
        }
    }
}
