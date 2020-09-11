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

namespace ZamjenaDomova.WinUI.Amenities
{
    public partial class frmAmenities : Form
    {
        private readonly APIService _amenityService = new APIService("Amenity");
        private readonly APIService _amenityCategoryService = new APIService("AmenitiesCategory");
        public frmAmenities()
        {
            InitializeComponent();
        }

        private async void frmAmenities_Load(object sender, EventArgs e)
        {
            await LoadAmenityCategories();

            var result = await _amenityService.Get<List<Model.Amenity>>(null);
            dgvAmenities.AutoGenerateColumns = false;
            dgvAmenities.DataSource = result;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new AmenitySearchRequest { Name = txtSearch.Text };
            var idObj = cmbCategory.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                search.AmenitiesCategoryId = id;
            }
            var result = await _amenityService.Get<List<Model.Amenity>>(search);
            dgvAmenities.AutoGenerateColumns = false;
            dgvAmenities.DataSource = result;
        }

        private async Task LoadAmenityCategories()
        {
            var result= await _amenityCategoryService.Get<List<Model.AmenitiesCategory>>(null);
            result.Insert(0, new Model.AmenitiesCategory { AmenitiesCategoryId = -1, Name = null });
            cmbCategory.DataSource = result;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "AmenitiesCategoryId";
        }
    }
}
