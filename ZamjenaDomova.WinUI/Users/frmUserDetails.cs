using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private int? _id = null;
        public frmUserDetails(int? userId = null)
        {
            InitializeComponent();
            _id = userId;
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
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
            if (this.ValidateChildren())
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
                if (_id.HasValue)
                {
                    await _userService.Update<Model.User>(_id, request);
                }
                else
                {
                    await _userService.Insert<Model.User>(request);
                }
                MessageBox.Show("Uspjesno!");
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
        //Regex regex = new Regex(@"[^@]+@[^\.]+\..+");
        //    if (!regex.Match(txtEmail.Text).Success)
        //    {
        //        errorProvider.SetError(txtEmail, Properties.Resources.Val_EmailRegex);
        //        e.Cancel = true;
        //    }
        //    else errorProvider.SetError(txtEmail, null);
        private void txtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                errorProvider.SetError(txtTelephone, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else errorProvider.SetError(txtTelephone, null);
        }

        //private void txtLozinka_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!_korisnikId.HasValue)
        //    {
        //        if (txtLozinka.TextLength < 8)
        //        {
        //            errorProvider.SetError(txtLozinka, Properties.Resources.Val_MinLengthPassword);
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            errorProvider.SetError(txtLozinka, null);
        //        }
        //    }
        //}

        //private void txtLozinkaPotvrda_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!_korisnikId.HasValue)
        //    {
        //        if (txtLozinkaPotvrda.Text != txtLozinka.Text)
        //        {
        //            errorProvider.SetError(txtLozinkaPotvrda, Properties.Resources.Val_PasswordConfirm);
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            errorProvider.SetError(txtLozinkaPotvrda, null);
        //        }
        //    }
        //}

        //private void btnUploadSliku_Click(object sender, EventArgs e)
        //{
        //    var result = openFileDialog.ShowDialog();

        //    if (result == DialogResult.OK)
        //    {
        //        var filename = openFileDialog.FileName;
        //        var file = File.ReadAllBytes(filename);

        //        Image image = Image.FromFile(filename);
        //        Image thumb = image.GetThumbnailImage(200, 200, () => false, IntPtr.Zero);

        //        ImageConverter _imageConverter = new ImageConverter();
        //        byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
        //        request.Slika = imagethumbbyte;
        //        pbSlikaKorisnika.Image = image;
        //    }
        //}

        //private void txtTelefon_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(txtTelefon.Text))
        //    {
        //        Regex regex = new Regex(@"^(\+)?([ 0-9]){9,16}$");
        //        if (!regex.Match(txtTelefon.Text).Success)
        //        {
        //            errorProvider.SetError(txtTelefon, Properties.Resources.Val_PhoneNumberRegex);
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            errorProvider.SetError(txtTelefon, null);
        //        }
        //    }
        //}

    }
}
