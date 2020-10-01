using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WinUI.Reports
{
    public partial class ucListingsCount : UserControl
    {
        private readonly APIService _listingService = new APIService("Listing");
        public ucListingsCount()
        {
            InitializeComponent();
        }

        private async void ucListingsCount_Load(object sender, EventArgs e)
        {
            var result = await _listingService.GetListingsCount<ListingCountModel>(null);
            dgvCount.AutoGenerateColumns = false;
            dgvCount.DataSource = result;
            
    }
    }
}
