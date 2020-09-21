using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZamjenaDomova.WinUI.Listings
{
    public partial class frmListingDetails : Form
    {
        private int? _id = null;
        public frmListingDetails(int? listingId = null)
        {
            InitializeComponent();
            _id = listingId;
        }

    }
}
