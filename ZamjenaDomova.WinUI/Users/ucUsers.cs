﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WinUI.Users
{
    public partial class ucUsers : UserControl
    {
        public ucUsers()
        {
            InitializeComponent();
        }
        private readonly APIService _apiService = new APIService("User");

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new UserSearchRequest { Name = txtSearch.Text };

            var result = await _apiService.Get<List<Model.User>>(search);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;

        }

        private void dgvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUsers.SelectedRows[0].Cells[0].Value;
            frmUserDetails frm = new frmUserDetails(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void ucUsers_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<Model.User>>(null);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;
        }

    }
}
