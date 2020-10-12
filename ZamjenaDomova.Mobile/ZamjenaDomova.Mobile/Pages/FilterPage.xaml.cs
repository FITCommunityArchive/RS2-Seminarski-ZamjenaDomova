using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Controls;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public SelectableObservableCollection<SelectableItem<Model.AmenityModel>> AmenitiesItems { get; set; }
        public ObservableCollection<Model.Territory> TerritoriesCollection = new ObservableCollection<Territory>();

        private double StepValue = 1.0;
        private int territoryId = -1;
        public FilterPage()
        {
            InitializeComponent();
            GetAmenities();
            GetTerritories();

        }
        private async void BtnFilter_Clicked(object sender, EventArgs e)
        {
            var request = new ListingsModelsSearchRequest();
            request.City = EntCity.Text;
            request.TerritoryId = territoryId;
            request.Persons = int.Parse(lblPersons.Text);
            request.Beds = int.Parse(lblBeds.Text);
            request.Bathrooms = int.Parse(lblBathrooms.Text);
            request.Amenities = new List<int>();
            var selectedAmenities = AmenitiesItems.SelectedItems().ToList();

            foreach (var item in selectedAmenities)
            {
                request.Amenities.Add(item.Data.AmenityId);
            }
            await Navigation.PushAsync(new HomePage(request));

        }

        private void sPersons_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            sPersons.Value = newStep * StepValue;
            if (sPersons.Value != 0)
                lblPersons.Text = sPersons.Value.ToString();
            else
                lblPersons.Text = "";
        }

        private void sBeds_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);
            sBeds.Value = newStep * StepValue;
            if (sBeds.Value != 0)
                lblBeds.Text = sBeds.Value.ToString();
            else lblBeds.Text = "";
        }

        private void sBathrooms_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            sBathrooms.Value = newStep * StepValue;
            if (sBathrooms.Value != 0)
                lblBathrooms.Text = sBathrooms.Value.ToString();
            else lblBathrooms.Text = "";
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
        private async void GetTerritories()
        {
            var territories = await APIService.GetTerritories();
            territories = territories.OrderBy(x => x.Name).ToList();

            foreach (var item in territories)
            {
                TerritoriesCollection.Add(item);
            }
            PickerTerritory.Items.Clear();
            PickerTerritory.ItemsSource = TerritoriesCollection;
        }

        private void TapReset_Tapped(object sender, EventArgs e)
        {
            EntCity.Text = "";
            PickerTerritory.SelectedItem = -1;
            sPersons.Value = 0;
            sBeds.Value = 0;
            sBathrooms.Value = 0;
            GetAmenities();
        }

        private void PickerTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = sender as Picker;
            if (!(picker.SelectedItem is int))
            {
                var selectedTerritory = (Model.Territory)picker.SelectedItem;

                territoryId = (int)selectedTerritory.TerritoryId;
            }
            else
            {
                territoryId = -1;
            }
        }

    }
}