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
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WinUI.Reports
{
    public partial class ucListingsCount : UserControl
    {
        private readonly APIService _listingService = new APIService("Listing");
        private readonly APIService _territoryService = new APIService("Territory");
        public ucListingsCount()
        {
            InitializeComponent();
        }

        private async void ucListingsCount_Load(object sender, EventArgs e)
        {
            var result = await _listingService.GetListingsCount<ListingCountModel>(null);
            dgvCount.AutoGenerateColumns = false;
            dgvCount.DataSource = result;

            LoadTerritories();
            
    }
        private async void LoadTerritories()
        {
            var result = await _territoryService.Get<List<Model.Territory>>(null);
            result.Insert(0, new Model.Territory { TerritoryId = null, Name = null });

            cmbTerritory.DataSource = result;
            cmbTerritory.DisplayMember = "Name";
            cmbTerritory.ValueMember = "TerritoryId";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ListingsCountSearchRequest request = null;

            var idObj = cmbTerritory.SelectedValue;
            if (idObj!= null && int.TryParse(idObj.ToString(), out int id))
            {
                request = new ListingsCountSearchRequest();
                request.TerritoryId = id;
            }
            var result = await _listingService.GetListingsCount<ListingCountModel>(request);
            dgvCount.AutoGenerateColumns = false;
            dgvCount.DataSource = result;
        }
    }
}
