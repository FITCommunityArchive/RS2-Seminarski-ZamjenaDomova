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
    public partial class frmAmenities : Form
    {
        private readonly APIService _amenityService = new APIService("Amenity");
        private readonly APIService _amenityCategoryService = new APIService("AmenityCategory");
        public frmAmenities()
        {
            InitializeComponent();
        }

        private async void frmAmenities_Load(object sender, EventArgs e)
        {
            var result = await _amenityService.Get<List<Model.Amenity>>(null);
            dgvAmenities.DataSource = result;
        }
    }
}
