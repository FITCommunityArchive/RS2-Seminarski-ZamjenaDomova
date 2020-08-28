using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WinUI.Users
{
    public partial class frmUsers : Form
    {
        private readonly APIService _apiService = new APIService("User");
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            //pozivamo api
            var search = new UserSearchRequest { Name = txtSearch.Text};

            var result = await _apiService.Get<List<Model.User>>(search);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;

        }
    }
}
