using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _service = new APIService("User");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
                var request = new AuthenticateModel
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };
                var url = $"{Properties.Settings.Default.APIUrl}/User/Login";
                var response = await url.PostJsonAsync(request).ReceiveJson<Model.User>();
                var test = response;
                APIService.Token = test.Token;

                await _service.Get<dynamic>(null);

                this.Hide();
                var frm = new frmIndex();
                frm.ShowDialog();
                this.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Login podaci nisu ispravni!", "Autentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
