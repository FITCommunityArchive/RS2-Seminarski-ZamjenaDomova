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
    public partial class frmAmenityDetails : Form
    {
        private readonly APIService _amenityService = new APIService("Amenity");
        private readonly APIService _amenityCategoryService = new APIService("AmenitiesCategory");

        public frmAmenityDetails()
        {
            InitializeComponent();
        }
        private async void frmAmenityDetails_Load(object sender, EventArgs e)
        {
            await LoadAmenityCategories();
        }
        private async Task LoadAmenityCategories()
        {
            var result = await _amenityCategoryService.Get<List<Model.AmenitiesCategory>>(null);
            result.Insert(0, new Model.AmenitiesCategory());
            cmbCategory.DataSource = result;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "AmenitiesCategoryId";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            AmenityUpsertRequest request = new AmenityUpsertRequest();

            request.Name = txtName.Text;
            var idObj = cmbCategory.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                request.AmenitiesCategoryId = id;
            }



            await _amenityService.Insert<Model.Amenity>(request);
            MessageBox.Show("Uspjesno!");
            txtName.Text = "";
            cmbCategory.Text = "";
        }
    }
}
