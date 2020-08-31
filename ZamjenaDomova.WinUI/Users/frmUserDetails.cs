using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
