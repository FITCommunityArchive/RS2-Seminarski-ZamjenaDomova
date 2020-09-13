using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZamjenaDomova.WinUI.Amenities
{
    public partial class frmAmenityDetails : Form
    {
        private readonly APIService _amenityService = new APIService("Amenity");
        private readonly APIService _amenityCategoryService = new APIService("AmenitiesCategory");

        private int AmenityId;
        public frmAmenityDetails(int amenityId)
        {
            InitializeComponent();
            AmenityId = amenityId;
            
        }
        private async Task LoadAmenityCategories()
        {
            var result = await _amenityCategoryService.Get<List<Model.AmenitiesCategory>>(null);
            result.Insert(0, new Model.AmenitiesCategory { AmenitiesCategoryId = null, Name = null });

            cmbCategory.DataSource = result;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "AmenitiesCategoryId";
        }

        private async void frmAmenityDetails_Load(object sender, EventArgs e)
        {
            await LoadAmenityCategories();
            try
            {
                var amenity = await _amenityService.GetById<Model.Amenity>(AmenityId);

                txtName.Text = amenity.Name;
                cmbCategory.SelectedValue = amenity.AmenitiesCategoryId;
            }
            catch (Exception)
            {
                MessageBox.Show("Nemate pristup!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
    }
}
