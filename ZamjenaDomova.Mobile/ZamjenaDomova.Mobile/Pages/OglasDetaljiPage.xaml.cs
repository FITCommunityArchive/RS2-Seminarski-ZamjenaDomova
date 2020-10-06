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
    public partial class OglasDetaljiPage : ContentPage
    {
        public ObservableCollection<Model.ListingImageModel> listingImages;
        private int _listingId;
        private int _totalImages = 0;

        public OglasDetaljiPage(int listingId)
        {
            InitializeComponent();
            listingImages = new ObservableCollection<Model.ListingImageModel>();
            _listingId = listingId;
            GetListingDetails(_listingId);
        }
        private async void GetListingDetails(int listingId)
        {
            var images = await APIService.GetListingImages(listingId);
            if (images != null)
            {
                _totalImages = images.Count;
                foreach (var item in images)
                {
                    listingImages.Add(item);
                }
            }
            crvImages.ItemsSource = listingImages;
        }
        private void crvImages_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex <= _totalImages)
            {
                var counter = e.FirstVisibleItemIndex + 1;
                lblCounter.Text = counter + " od " + _totalImages;
            }
        }

    }
}