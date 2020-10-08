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
    public partial class WishlistPage : ContentPage
    {
        public ObservableCollection<Model.ListingModel> listings;
        public WishlistPage()
        {
            InitializeComponent();
            listings = new ObservableCollection<Model.ListingModel>();
            this.Appearing += async (object sender, EventArgs e) =>
            {
                await GetListingsModels();
            };
        }

        async Task GetListingsModels()
        {
            listings.Clear();
            var list = await APIService.GetWishlistListings();
            foreach (var item in list)
            {
                listings.Add(item);
            }
            lvListings.ItemsSource = listings;
        }
        private void lvListings_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listingId = (e.SelectedItem as Model.ListingModel).ListingId;
            Navigation.PushAsync(new OglasDetaljiPage(listingId, true));
        }
    }
}