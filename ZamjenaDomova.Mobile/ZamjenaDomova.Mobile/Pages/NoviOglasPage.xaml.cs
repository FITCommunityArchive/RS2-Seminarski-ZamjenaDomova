using ZamjenaDomova.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using ZamjenaDomova.Controls;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoviOglasPage : ContentPage
    {
        private bool enableMultiSelect;
        private int territoryId;
        public ObservableCollection<Model.Territory> TerritoriesCollection = new ObservableCollection<Territory>();
        public SelectableObservableCollection<SelectableItem<Model.AmenityModel>> AmenitiesItems { get; set; }
        

        public NoviOglasPage()
        {
            InitializeComponent();

            GetTerritories();
            enableMultiSelect = true;
            GetAmenities();

            BindingContext = this;
        }

        private async void GetTerritories()
        {
            var territories = await APIService.GetTerritories();
            territories = territories.OrderBy(x => x.Name).ToList();
            foreach (var item in territories)
            {
                TerritoriesCollection.Add(item);
            }
            PickerTerritory.ItemsSource = TerritoriesCollection;
        }

        private async void GetAmenities()
        {
            var amenities = await APIService.GetAmenities();
            List<AmenityModel> amenitiesModels = amenities
                .Select(x => new AmenityModel
                {
                    AmenityId = x.AmenityId,
                    Name = x.Name
                }).ToList();
            var amenitiesItems = amenitiesModels
                .Select(x => new SelectableItem<AmenityModel>(x))
                .ToList();
            AmenitiesItems = new SelectableObservableCollection<SelectableItem<AmenityModel>>(amenitiesItems);
            lvAmenities.ItemsSource = AmenitiesItems;
        }

        
        private async void BtnList_Clicked(object sender, EventArgs e)
        {
            var listing = new ListingInsertRequest();
            listing.Name = EntName.Text;
            listing.Address = EntAddress.Text;
            listing.City = EntCity.Text;
            listing.TerritoryId = territoryId;
            listing.ListingDescription = HomeDesc.Text;
            listing.AreaDescription = AreaDesc.Text;
            if (int.TryParse(EntPersons.Text, out int persons))
            {
                listing.Persons = persons;
            }
            if (int.TryParse(EntBeds.Text, out int beds))
            {
                listing.Beds = beds;
            }
            if (int.TryParse(EntBathrooms.Text, out int bathrooms))
            {
                listing.Bathrooms = bathrooms;
            }
            listing.UserId = Preferences.Get("userId", 0);
            var selectedAmenities = AmenitiesItems.SelectedItems().ToList();
            bool a = true;
            //foreach(var item in lvAmenities)
            //{
            //    if item.is
            //}
           
            //var response = await APIService.DodajVozilo(vozilo);
            //if (response == null) return;
            //var voziloId = response.VoziloId;

            await Navigation.PopAsync();
        }

        private void PickerTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedTerritory = (Model.Territory)picker.SelectedItem;
            territoryId = selectedTerritory.TerritoryId;
        }

    }
}