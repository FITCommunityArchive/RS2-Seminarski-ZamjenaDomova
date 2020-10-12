
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile
{
    public class Recommender
    {
        Dictionary<int, List<Rating>> listings = new Dictionary<int, List<Rating>>();

        public async Task<List<ListingModel>> GetSimilarListings(int listingId)
        {
            await LoadListings(listingId);
            List<ListingModel> recommendedListings = new List<ListingModel>();

            List<Rating> thisListingsRatings = await APIService.GetRatingsByListing(listingId);
            if (thisListingsRatings == null)
            {
                return recommendedListings;
            }
            thisListingsRatings = thisListingsRatings.OrderBy(x => x.UserId).ToList();

            List<Rating> commonRatings1 = new List<Rating>();
            List<Rating> commonRatings2 = new List<Rating>();

            foreach (var item in listings.ToList())
            {
                foreach (var r in thisListingsRatings)
                {
                    if (item.Value.Where(x => x.UserId == r.UserId).Count() > 0)
                    {
                        commonRatings1.Add(r);
                        commonRatings2.Add(item.Value.Where(x => x.UserId == r.UserId).FirstOrDefault());
                    }
                }

                double similarity = GetSimilarity(commonRatings1, commonRatings2);

                if (similarity > 0.5)
                {
                    recommendedListings.Add(await APIService.GetListing(item.Key));
                }

                commonRatings1.Clear();
                commonRatings2.Clear();
            }

            return recommendedListings;
        }

        private double GetSimilarity(List<Rating> commonRatings1, List<Rating> commonRatings2)
        {
            if (commonRatings1.Count != commonRatings2.Count)
                return 0;

            double counter = 0, denominator1 = 0, denominator2 = 0;

            for (int i = 0; i < commonRatings1.Count; i++)
            {
                counter += commonRatings1[i].RatingValue * commonRatings2[i].RatingValue;
                denominator1 += commonRatings1[i].RatingValue * commonRatings1[i].RatingValue;
                denominator2 += commonRatings2[i].RatingValue * commonRatings2[i].RatingValue;
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double denominator = denominator1 * denominator2;
            if (denominator == 0)
                return 0;
            else
                return counter / denominator;
        }

        private async Task LoadListings(int listingId)
        {
            ListingsModelsSearchRequest request = new ListingsModelsSearchRequest();
            request.Amenities = null;
            List<Model.ListingModel> listingsList = await APIService.GetListingsModels(request);

            var listingToRemove = listingsList.Find(x => x.ListingId == listingId);
            listingsList.Remove(listingToRemove);

            List<Rating> ratings = new List<Rating>();

            foreach (var item in listingsList)
            {
                ratings = await APIService.GetRatingsByListing(item.ListingId);
                if (ratings != null)
                {
                    ratings = ratings.OrderBy(x => x.UserId).ToList();
                    listings.Add(item.ListingId, ratings);
                }
            }
        }
    }
}