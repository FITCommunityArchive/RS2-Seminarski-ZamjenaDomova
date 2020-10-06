using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Model.ListingModel> listings;
        public TraziPage()
        {
            InitializeComponent();
            listings = new ObservableCollection<Model.ListingModel>();
            this.Appearing += async (object sender, EventArgs e) => {
                await GetListingsModels();
            };
        }

        async Task GetListingsModels()
        {
            listings.Clear();
            var list = await APIService.GetListingsModels(null);
            foreach(var item in list)
            {
                listings.Add(item);
            }
            lvListings.ItemsSource = listings;
        }
       
    }
}