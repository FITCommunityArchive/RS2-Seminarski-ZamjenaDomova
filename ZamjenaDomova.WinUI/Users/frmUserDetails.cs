using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WinUI.Users
{
    public partial class frmUserDetails : Form
    {
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _roleService = new APIService("Role");

        private int? _id = null;
        public frmUserDetails(int? userId = null)
        {
            InitializeComponent();
            _id = userId;
            
        }
        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadRoles();
            await LoadUserDetails();
        }
        private async Task LoadRoles()
        {
            var roles = await _roleService.Get<List<Model.Role>>(null);
            clbRoles.DataSource = roles;
            clbRoles.DisplayMember = "Name";
            clbRoles.ValueMember = "RoleId";
        }

        private async Task LoadUserDetails()
        {
            if (_id.HasValue)
            {

                btnDelete.Show();
                var user = await _userService.GetById<Model.User>(_id);

                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtTelephone.Text = user.PhoneNumber;

                if (user.Image.Length>0 && user.Image != null)
                {
                    MemoryStream ms = new MemoryStream(user.Image);
                    Image image = Image.FromStream(ms);
                    pbAvatar.Image = image;
                }
                var request = new RoleSearchRequest { UserId = user.UserId };
                var userRoles = await _roleService.Get<List<Model.Role>>(request);
                var rolesInt = userRoles.Select(x => x.RoleId);
                for (int i = 0; i < clbRoles.Items.Count; i++)
                {
                    var item = (clbRoles.Items[i] as Model.Role).RoleId;
                    if (rolesInt.Contains(item))
                        clbRoles.SetItemChecked(i, true);
                }

            }
        }
        //private async void frmUserDetails_Load(object sender, EventArgs e)
        //{
        //    //var roles = await _roleService.Get<List<Model.Role>>(null);
        //    //clbRoles.DataSource = roles;
        //    //clbRoles.DisplayMember = "Name";
        //    //clbRoles.ValueMember = "RoleId";

        //    if (_id.HasValue)
        //    {

        //        btnDelete.Show();
        //        var user = await _userService.GetById<Model.User>(_id);

        //        txtFirstName.Text = user.FirstName;
        //        txtLastName.Text = user.LastName;
        //        txtEmail.Text = user.Email;
        //        txtTelephone.Text = user.PhoneNumber;

        //        if (user.Image != null)
        //        {
        //            MemoryStream ms = new MemoryStream(user.Image);
        //            Image image = Image.FromStream(ms);
        //            pbAvatar.Image = image;
        //        }
        //        var request = new RoleSearchRequest { UserId = user.UserId };
        //        var userRoles = await _roleService.Get<List<Model.Role>>(request);
        //        var rolesInt = userRoles.Select(x => x.RoleId);
        //        for (int i = 0; i < clbRoles.Items.Count; i++)
        //        {
        //            var item = (clbRoles.Items[i] as Model.Role).RoleId;
        //            if (rolesInt.Contains(item))
        //                clbRoles.SetItemChecked(i, true);
        //        }

        //    }
        //}
        UserUpsertRequest request = new UserUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var roles = clbRoles.CheckedItems.Cast<Model.Role>().Select(x => x.RoleId).ToList();

                request.FirstName = txtFirstName.Text;
                request.LastName = txtLastName.Text;
                request.Email = txtEmail.Text;
                request.PhoneNumber = txtTelephone.Text;
                request.Password = txtPassword.Text;
                request.PasswordConfirmation = txtPasswordConfirmation.Text;
                request.Roles = roles;

                if (_id.HasValue)
                {
                    await _userService.Update<Model.User>(_id, request);
                }
                else
                {
                    await _userService.Insert<Model.User>(request);
                }
                MessageBox.Show("Uspjesno!");
                this.Close();
                var frm = new ucUsers();
                var frmIndex = Application.OpenForms["frmIndex"];
                var panelContainer = frmIndex.Controls.Find("panelMain", true).FirstOrDefault() as Panel;

                PanelHelper.AddPanel(panelContainer, frm);
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else errorProvider.SetError(txtFirstName, null);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else errorProvider.SetError(txtLastName, null);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else errorProvider.SetError(txtEmail, null);
        }
        
        private void txtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                errorProvider.SetError(txtTelephone, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else errorProvider.SetError(txtTelephone, null);
        }

        private void btn_UploadImage_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Image = file;
                Image image = Image.FromFile(fileName);
                pbAvatar.Image = image;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var user = await _userService.Delete<Model.User>(_id);

            MessageBox.Show("Uspjesno obrisano!");
            this.Close();
            var frm = new ucUsers();
            var frmIndex = Application.OpenForms["frmIndex"];
            var panelContainer = frmIndex.Controls.Find("panelMain", true).FirstOrDefault() as Panel;

            PanelHelper.AddPanel(panelContainer, frm);
        }

        
    }
}
