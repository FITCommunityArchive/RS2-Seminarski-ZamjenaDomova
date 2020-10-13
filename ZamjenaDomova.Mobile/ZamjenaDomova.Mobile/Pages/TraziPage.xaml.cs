using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TraziPage : ContentPage
    {
        private string _searchText;
        public ObservableCollection<Model.ListingModel> listings;
        private ListingsModelsSearchRequest _request;
        public TraziPage()
        {
            InitializeComponent();
            _searchText = "";
            _request = new ListingsModelsSearchRequest { Amenities = null };

            listings = new ObservableCollection<Model.ListingModel>();
            this.Appearing += async (object sender, EventArgs e) =>
            {
                await GetListingsModels(_request);
            };
        }
        public TraziPage(ListingsModelsSearchRequest request)
        {
            InitializeComponent();
            _request = new ListingsModelsSearchRequest();
            _request = request;
            _searchText = "";
            listings = new ObservableCollection<Model.ListingModel>();
            this.Appearing += async (object sender, EventArgs e) =>
            {
                await GetListingsModels(_request);
            };
        }

        async Task GetListingsModels(ListingsModelsSearchRequest request)
        {
            listings.Clear();

            var list = await APIService.GetListingsModels(request);
            foreach (var item in list)
            {
                listings.Add(item);
            }
            lvListings.ItemsSource = listings;


        }
        private void lvListings_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listingId = (e.SelectedItem as Model.ListingModel).ListingId;
            Navigation.PushAsync(new OglasDetaljiPage(listingId, false));
        }
        public async void BtnFilter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
        }
    }
}