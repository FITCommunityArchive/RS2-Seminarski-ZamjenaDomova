using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TraziPage : ContentPage
    {
        public TraziPage()
        {
            InitializeComponent();
            GetListingsModels();
        }
        private async void GetListingsModels()
        {
            var listings = await APIService.GetListingsModels(null);
            lvListings.ItemsSource = listings;
        }
       
    }
}