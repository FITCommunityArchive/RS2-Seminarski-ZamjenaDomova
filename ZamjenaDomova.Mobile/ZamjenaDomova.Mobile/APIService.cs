using ZamjenaDomova.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile
{
    public static class APIService
    {
#if DEBUG
        public readonly static string _apiUrl = "http://localhost:8080/api";
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
            var result = JsonConvert.DeserializeObject<Model.UserResponse>(jsonResult);
            Preferences.Set("access_token", result.Token);
            Preferences.Set("userId", result.UserId);
            Preferences.Set("token_expiration_time", result.Token_Expiration_Time);
            Preferences.Set("userName", result.FirstName + " " + result.LastName);
            Preferences.Set("wishlistId", result.WishlistId);
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
            request.UserId = Preferences.Get("userId", 0);
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Listing/GetListingsModels", content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Model.ListingModel>>(jsonResult);
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

        public static async Task<List<Model.ListingModel>> GetWishlistListings()
        {
            await TokenValidator.CheckTokenValidity();
            int wishlistId = Preferences.Get("wishlistId", 0);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Wishlist/{wishlistId}");
            return JsonConvert.DeserializeObject<List<Model.ListingModel>>(response);
        }

        public static async Task<Model.WishlistListing> SaveWishlistListing(int listingId)
        {
            await TokenValidator.CheckTokenValidity();
            var wishlistInsertRequest = new WishlistListingInsertRequest
            {
                ListingId = listingId,
                WishlistId = Preferences.Get("wishlistId", 0),
                DateAdded = DateTime.Now
            };

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(wishlistInsertRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_apiUrl}/Wishlist", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Model.WishlistListing>(jsonResult);
        }

        public static async Task<bool> RemoveWishlistListing(int listingId)
        {
            await TokenValidator.CheckTokenValidity();
            var wishlistId = Preferences.Get("wishlistId", 0);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.DeleteAsync($"{_apiUrl}/Wishlist/{wishlistId }/{listingId}");
            if (!response.IsSuccessStatusCode) return false;
            return true;

        }

        public static async Task<bool> IsOnWishlist(int listingId)
        {
            await TokenValidator.CheckTokenValidity();
            int wishlistId = Preferences.Get("wishlistId", 0);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Wishlist/IsOnWishlist/{wishlistId}/{listingId}");
            return JsonConvert.DeserializeObject<bool>(response);

        }

        public static async Task<Rating> SetRating(int listingId, int ratingValue)
        {
            var rating = new Model.Rating
            {
                ListingId = listingId,
                UserId = Preferences.Get("userId", 0),
                RatingValue = ratingValue
            };

            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(rating);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Rating", content).Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Rating>(response);
        }

        public static async Task<bool> UpdateListing(int listingId, Model.Requests.ListingUpdateRequest request)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PutAsync($"{_apiUrl}/Listing/{listingId}", content);

            return true;
        }

        //public static async Task<bool> DeleteListing(int listingId)
        //{
        //    await TokenValidator.CheckTokenValidity();

        //    var httpClient = new HttpClient();
        //    var content = new StringContent($"PhoneNumber={phoneNumber}", Encoding.UTF8, "application/x-www-form-urlencoded");
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //    var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/ChangePhoneNumber", content);
        //    if (!response.IsSuccessStatusCode) return false;
        //    return true;
        //}

        public static async Task<List<Rating>> GetRatingsByListing(int listingId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Rating/GetRatingsByListing/{listingId}");
            return JsonConvert.DeserializeObject<List<Rating>>(response);
        }

        public static async Task<int> GetRatingByListingAndUser(int listingId, int userId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Rating/GetRatingByListingAndUser/{listingId}/{userId}");
            return JsonConvert.DeserializeObject<int>(response);
        }

        public static async Task<Model.ListingModel> GetListing(int listingId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Listing/GetListing/{listingId}");
            return JsonConvert.DeserializeObject<Model.ListingModel>(response);
        }

        public static async Task<User> GetUserDetails()
        {
            await TokenValidator.CheckTokenValidity();
            var userId = Preferences.Get("userId", 0);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/User/{userId}");
            return JsonConvert.DeserializeObject<User>(response);
        }

        public static async Task<bool> ChangeProfilePicture(byte[] imageArray)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(imageArray);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/User/ChangeProfilePicture", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> UpdateAccountSettings(Model.Requests.AccountSettingsUpdateRequest request)
        {
            await TokenValidator.CheckTokenValidity();
            var userId =Preferences.Get("userId", 0);
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PutAsync($"{_apiUrl}/User/UpdateAccountSettings/{userId}", content);

            return true;
        }

        //        public static async Task<ProfilePictureModel> GetProfilePicture()
        //        {
        //            await TokenValidator.CheckTokenValidity();

        //            var httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
        //            var response = await httpClient.GetStringAsync($"{_apiUrl}/Korisnici/GetProfilePicture");
        //            return JsonConvert.DeserializeObject<ProfilePictureModel>(response);
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


        public static async Task<List<Model.Listing>> GetListings()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Listings/GetListings");
            return JsonConvert.DeserializeObject<List<Model.Listing>>(response);
        }

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