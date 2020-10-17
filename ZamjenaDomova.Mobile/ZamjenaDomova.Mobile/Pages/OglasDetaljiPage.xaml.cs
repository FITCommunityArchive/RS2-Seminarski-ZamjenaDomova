using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Controls;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OglasDetaljiPage : ContentPage
    {
        public ObservableCollection<Model.ListingImageModel> listingImages;
        public SelectableObservableCollection<SelectableItem<Model.AmenityModel>> AmenitiesItems { get; set; }

        private int _listingId;
        private int _totalImages = 0;
        private string email;
        private string phone;
        private int _height = 0;
        private bool _deletable;
        public OglasDetaljiPage(int listingId, bool deletable)
        {
            InitializeComponent();
            listingImages = new ObservableCollection<Model.ListingImageModel>();
            _listingId = listingId;
            GetListingDetails(_listingId);
            GetAverageRating();
            _deletable = deletable;
            if (_deletable)
            {
                BtnDelete.IsVisible = true;
            }
            else
            {
                WishlistOptions();
                UserRatingOptions();
                GetRecommendedListings(_listingId);
            }
        }
        private async void GetListingDetails(int listingId)
        {
            var listing = await APIService.GetListingDetails(listingId);

            lblName.Text = listing.Name;
            lblHomeDesc.Text = listing.ListingDescription;
            lblAreaDesc.Text = listing.AreaDescription;
            lblPersons.Text = listing.Persons.ToString();
            lblBeds.Text = listing.Beds.ToString();
            lblBathrooms.Text = listing.Bathrooms.ToString();
            lblOwner.Text = listing.UserName;
            lblAddress.Text = listing.Address;
            lblCity.Text = listing.City;
            lblTerritory.Text = listing.TerritoryName;
            lblDate.Text = listing.DateApproved.ToString("dd/MM/yyyy");
            email = listing.UserEmail;
            phone = listing.UserPhone;

            _height = 32 * listing.Amenities.Count;
            lvAmenities.ItemsSource = listing.Amenities;
            lvAmenities.HeightRequest = _height;

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
            if (listing.UserImage != null && listing.UserImage.Length > 0)
            {
                Stream stream = new MemoryStream(listing.UserImage);
                ImgUser.Source = ImageSource.FromStream(() => stream);
            }
            else
            {
                ImgUser.Source = "user.png";
            }
        }
        private void crvImages_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex <= _totalImages)
            {
                var counter = e.FirstVisibleItemIndex + 1;
                lblCounter.Text = counter + " od " + _totalImages;
            }
        }
        private async void BtnContact_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Kontaktiraj", $"Email: {email}\nTelefon: {phone}", "OK");
        }
        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Brisanje oglasa", "Jeste li sigurni da želite izbrisati oglas?", "Da", "Ne");
            if (answer)
            {
                var listing = new ListingUpdateRequest
                {
                    Approved = false
                };
                await APIService.UpdateListing(_listingId, listing);
                await Navigation.PopAsync();
            }
        }
        private async void WishlistOptions()
        {
            iconHeart.IsVisible = true;
            if (await APIService.IsOnWishlist(_listingId))
                iconHeart.Source = "heart-shape-silhouette.png";
            else iconHeart.Source = "heart-shape-outline.png";
        }
        private async void TapHeart_Tapped(object sender, EventArgs e)
        {
            if (await APIService.IsOnWishlist(_listingId))
                await APIService.RemoveWishlistListing(_listingId);
            else
                await APIService.SaveWishlistListing(_listingId);

            WishlistOptions();
        }

        private async void GetUserRating(int listingId)
        {
            var response = await APIService.GetRatingByListingAndUser(listingId, Preferences.Get("userId", 0));

            if (response != -1)
            {
                UserRating.Value = response;
            }
        }

        private async void GetRecommendedListings(int listingId)
        {
            Recommender recommender = new Recommender();
            var listings = await recommender.GetSimilarListings(listingId);
            if (listings.Count > 0)
            {
                CvRecommendedListings.IsVisible = true;
                CvRecommendedListings.ItemsSource = listings;
            }
        }

        private async void GetAverageRating()
        {
            var ratings = await APIService.GetRatingsByListing(_listingId);

            if (ratings == null && !_deletable)
            {
                LblRating.Text = "Budite prvi koji će ocijeniti ovaj oglas!";
            }
            else if (ratings == null && _deletable)
            {
                LblRating.Text = "Oglas nema ocjena!";
            }
            else
            {
                var averageRating = ratings.Average(x => x.RatingValue);
                Rating.Value = averageRating;
                LblRating.Text = $"Trenutna prosječna ocjena: {averageRating:#.##}";
            }
        }
        private void CvRecommendedListings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as ListingModel;
            Navigation.PushModalAsync(new OglasDetaljiPage(currentSelection.ListingId, false));
        }

        private async void UserRating_ValueChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            int rating = Convert.ToInt32(e.Value);
            var model = await APIService.SetRating(_listingId, rating);
            UserRating.Value = rating;
            UserRating.IsVisible = false;

            LblUserRatingMessage.Text = "Uspješno ste ocijenili oglas.";
            Device.StartTimer(new TimeSpan(0, 0, 4), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    LblUserRatingMessage.IsVisible = false;
                    LblUserRatingMessage.Text = "";
                });
                return false;
            });

            Rating.Value = model.AverageRating;

            LblRating.Text = $"Trenutna prosječna ocjena: {model.AverageRating}";
        }

        private void BtnUserRating_Clicked(object sender, EventArgs e)
        {
            UserRating.IsVisible = !UserRating.IsVisible;
        }

        private void UserRatingOptions()
        {
            RatingOptions.IsVisible = true;
        }
    }
}