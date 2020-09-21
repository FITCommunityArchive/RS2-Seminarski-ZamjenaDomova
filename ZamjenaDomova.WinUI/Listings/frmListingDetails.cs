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
        public frmListingDetails(int listingId)
        {
            InitializeComponent();
            _id = listingId;
        }

        private async void frmListingDetails_Load(object sender, EventArgs e)
        {
            var listingAmenities = await _listingAmenityService
                .Get<List<Model.AmenityModel>>(new ListingAmenitySearchRequest { ListingId = _id }); ;
            clbAmenities.DataSource = listingAmenities;
            clbAmenities.DisplayMember = "Name";
            clbAmenities.ValueMember = "AmenityId";
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



                //var listingAmenities = await _roleService.Get<List<Model.Role>>(request);
                //var rolesInt = userRoles.Select(x => x.RoleId);
                //for (int i = 0; i < clbRoles.Items.Count; i++)
                //{
                //    var item = (clbRoles.Items[i] as Model.Role).RoleId;
                //    if (rolesInt.Contains(item))
                //        clbRoles.SetItemChecked(i, true);
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("Nemate pristup!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

        }
    }
}
