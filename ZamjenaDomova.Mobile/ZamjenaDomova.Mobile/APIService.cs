﻿using ZamjenaDomova.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ZamjenaDomova.Mobile
{
    public static class APIService
    {
#if DEBUG
        public readonly static string _apiUrl = "http://localhost:1337/api";
#endif
#if RELEASE
        public readonly static string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public static async Task<bool> RegisterUser(string firstName, string lastName, string email, string phoneNumber, string password, string passwordConfirmation)
        {
            var registerModel = new RegisterModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password,
                PasswordConfirmation = passwordConfirmation
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_apiUrl}/User/Register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> Login(string email, string password)
        {
            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_apiUrl}/User/Login";
            var response = await httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Model.User>(jsonResult);
            Preferences.Set("access_token", result.Token);
            Preferences.Set("userId", result.UserId);
            Preferences.Set("token_expiration_time", result.Token_Expiration_Time);
            Preferences.Set("userName", result.FirstName + " " + result.LastName);
            return true;
        }

        public static async Task<bool> ChangePassword(string oldPassword, string newPassword, string passwordConfirmation)
        {
            var changePasswordModel = new Model.ChangePasswordModel
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                PasswordConfirmation = passwordConfirmation
            };

            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(changePasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/User/ChangePassword", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<List<Model.Territory>> GetTerritories()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Territory");
            return JsonConvert.DeserializeObject<List<Model.Territory>>(response);
        }
        
        public static async Task<List<Model.Amenity>> GetAmenities()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Amenity");
            return JsonConvert.DeserializeObject<List<Model.Amenity>>(response);
        }

        public static async Task<ListingResponse> InsertListing(Model.Requests.ListingInsertRequest request)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Listing", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ListingResponse>(jsonResult);
        }
       
        public static async Task<bool> AddListingImage(int listingId, byte[] imageArray)
        {
            var listingImage = new ListingImageModel
            {
                ListingId = listingId,
                Image = imageArray
            };

            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(listingImage);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/ListingImage", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
        
        public static async Task<List<Model.ListingModel>> GetListingsModels(Model.Requests.ListingsModelsSearchRequest request)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Listing/GetListingsModels");
            return JsonConvert.DeserializeObject<List<Model.ListingModel>>(response);
        }

        public static async Task<List<ListingImageModel>> GetListingImages(int listingId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/ListingImage/GetByListing/{listingId}");
            return JsonConvert.DeserializeObject<List<ListingImageModel>>(response);
        }

        public static async Task<ListingDetailsModel> GetListingDetails(int listingId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Listing/GetListingDetails/{listingId}");
            return JsonConvert.DeserializeObject<Model.ListingDetailsModel>(response);
        }

        public static async Task<List<Model.ListingModel>> GetMyListings(bool approved)
        {
            await TokenValidator.CheckTokenValidity();
            int userId = Preferences.Get("userId", 0);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Listing/MyListings/{userId}/{approved}");
            return JsonConvert.DeserializeObject<List<Model.ListingModel>>(response);
        }


        //        public static async Task<OcjenaModel> SetOcjena(int voziloId, int ocjena)
        //        {
        //            var ocjenaModel = new Modeli.OcjenaModel
        //            {
        //                VoziloId = voziloId,
        //                KorisnikId = Preferences.Get("korisnikId", 0),
        //                DataOcjena = ocjena
        //            };

        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            var json = JsonConvert.SerializeObject(ocjenaModel);
        //            var content = new StringContent(json, Encoding.UTF8, "application/json");
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.PostAsync($"{_apiUrl}/Ocjene", content).Result.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<OcjenaModel>(response);
        //        }

        //        public static async Task<bool> ChangePhoneNumber(string phoneNumber)
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            var content = new StringContent($"PhoneNumber={phoneNumber}", Encoding.UTF8, "application/x-www-form-urlencoded");
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/ChangePhoneNumber", content);
        //            if (!response.IsSuccessStatusCode) return false;
        //            return true;
        //        }

        //        public static async Task<List<OcjenaModel>> GetOcjeneByVozilo(int voziloId)
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Ocjene/GetOcjeneByVozilo/{voziloId}");
        //            return JsonConvert.DeserializeObject<List<OcjenaModel>>(response);
        //        }

        //        public static async Task<int> GetOcjenaByVoziloAndKorisnik(int voziloId, int korisnikId)
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Ocjene/GetOcjenaByVoziloAndKorisnik/{voziloId}/{korisnikId}");
        //            return JsonConvert.DeserializeObject<int>(response);
        //        }

        //        public static async Task<Modeli.Oglas> GetOglasByVozilo(int voziloId)
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/GetOglasByVozilo/{voziloId}");
        //            return JsonConvert.DeserializeObject<Modeli.Oglas>(response);
        //        }

        //        public static async Task<string> GetPhoneNumber()
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Korisnici/GetPhoneNumber");
        //            return response;
        //        }

        //        public static async Task<bool> ChangeProfilePicture(byte[] imageArray)
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            var json = JsonConvert.SerializeObject(imageArray);
        //            var content = new StringContent(json, Encoding.UTF8, "application/json");
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/ChangeProfilePicture", content);
        //            if (!response.IsSuccessStatusCode) return false;
        //            return true;
        //        }

        //        public static async Task<ProfilePictureModel> GetProfilePicture()
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Korisnici/GetProfilePicture");
        //            return JsonConvert.DeserializeObject<ProfilePictureModel>(response);
        //        }

        //        public static async Task<List<Modeli.Kategorija>> GetKategorije()
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Kategorije");
        //            return JsonConvert.DeserializeObject<List<Modeli.Kategorija>>(response);
        //        }

        //        public static async Task<List<VoziloSearch>> PretragaVozila(string search)
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            if (!string.IsNullOrWhiteSpace(search))
        //            {
        //                var httpClient = new HttpClient();
        //                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //                var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/Pretraga/{search}");
        //                return JsonConvert.DeserializeObject<List<VoziloSearch>>(response);
        //            }
        //            return new List<VoziloSearch>{
        //                new VoziloSearch { VoziloId = -1 }
        //            };
        //        }


        //        public static async Task<List<Modeli.Oglas>> GetOglase()
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/GetOglase");
        //            return JsonConvert.DeserializeObject<List<Modeli.Oglas>>(response);
        //        }

        //        public static async Task<List<Modeli.MojOglas>> GetMojeOglase()
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/MojiOglasi");
        //            return JsonConvert.DeserializeObject<List<Modeli.MojOglas>>(response);
        //        }
        //    }

        public static class TokenValidator
        {
            public static async Task CheckTokenValidity()
            {
                var expirationTime = Preferences.Get("token_expiration_time", DateTime.Now);
                if (DateTime.Compare(expirationTime, DateTime.Now) < 0)
                {
                    var userEmail = Preferences.Get("userEmail", string.Empty);
                    var userPassword = Preferences.Get("userPassword", string.Empty);
                    await APIService.Login(userEmail, userPassword);
                }
            }
        }
    }
}