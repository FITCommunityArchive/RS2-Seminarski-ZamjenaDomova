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

namespace ZamjenaDomova.WinUI.Users
{
    public partial class frmUserDetails : Form
    {
        private readonly APIService _userService = new APIService("User");
        private int? _id = null;
        public frmUserDetails(int? userId=null)
        {
            InitializeComponent();
            _id = userId;
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                var user = await _userService.GetById<Model.User>(_id);
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtTelephone.Text = user.PhoneNumber;
            }    
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UserUpsertRequest request = new UserUpsertRequest
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtTelephone.Text,
                Password = txtPassword.Text,
                PasswordConfirmation = txtPasswordConfirmation.Text
            };
            if(_id.HasValue)
            {
                await _userService.Update<Model.User>(_id, request);
            }
            else
            {
                await _userService.Insert<Model.User>(request);
            }
        }
    }
}
