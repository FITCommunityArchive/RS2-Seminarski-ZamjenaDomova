using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ZamjenaDomovaContext>());
            }
        }
        public static void SeedData(ZamjenaDomovaContext context)
        {
            context.Database.Migrate();

            if (!context.AmenitiesCategory.Any())
            {
                context.AmenitiesCategory.AddRange(
                    new AmenitiesCategory { AmenitiesCategoryId = 1, Name = "Kuhinja" },
                    new AmenitiesCategory { AmenitiesCategoryId = 2, Name = "Dvorište" },
                    new AmenitiesCategory { AmenitiesCategoryId = 3, Name = "Kupaonica" },
                    new AmenitiesCategory { AmenitiesCategoryId = 4, Name = "Tehnologija" },
                    new AmenitiesCategory { AmenitiesCategoryId = 5, Name = "Pristupačnost" },
                    new AmenitiesCategory { AmenitiesCategoryId = 6, Name = "Automobil" }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.AmenitiesCategory ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.AmenitiesCategory OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Amenity.Any())
            {
                context.Amenity.AddRange(
                    new Amenity { AmenityId = 1, Name = "Mikrovalna", AmenitiesCategoryId = 1 },
                    new Amenity { AmenityId = 4, Name = "TV", AmenitiesCategoryId = 4 },
                    new Amenity { AmenityId = 5, Name = "Garaža", AmenitiesCategoryId = 6 },
                    new Amenity { AmenityId = 6, Name = "Sauna", AmenitiesCategoryId = 3 },
                    new Amenity { AmenityId = 7, Name = "Hladnjak", AmenitiesCategoryId = 1 },
                    new Amenity { AmenityId = 8, Name = "DVD player", AmenitiesCategoryId = 4 },
                    new Amenity { AmenityId = 10, Name = "PC", AmenitiesCategoryId = 4 },
                    new Amenity { AmenityId = 12, Name = "Grill", AmenitiesCategoryId = 1 },
                    new Amenity { AmenityId = 13, Name = "Vanjski bazen", AmenitiesCategoryId = 2 },
                    new Amenity { AmenityId = 14, Name = "Kućica za pse", AmenitiesCategoryId = 2 },
                    new Amenity { AmenityId = 15, Name = "Invalidski lift", AmenitiesCategoryId = 5 },
                    new Amenity { AmenityId = 16, Name = "Pećnica", AmenitiesCategoryId = 1 },
                    new Amenity { AmenityId = 18, Name = "Terasa", AmenitiesCategoryId = 2 },
                    new Amenity { AmenityId = 20, Name = "Jacuzzi", AmenitiesCategoryId = 2 },
                    new Amenity { AmenityId = 21, Name = "Mogućnost korištenja automobila", AmenitiesCategoryId = 6 }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Amenity ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Amenity OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.User.Any())
            {
                context.User.AddRange(
                    new User
                    {
                        UserId = 1,
                        FirstName = "Anja",
                        LastName = "Jedan",
                        Email = "desktop",
                        PasswordHash = "bUBHhasx3aUpr7cmjozMzIeL35c=",
                        PasswordSalt = "zthomrUyhZjeapvj5KYL+A==",
                        PhoneNumber = "+387603573562",
                        Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/AnjaJedan.jpg"))
                    },
                    new User
                    {
                        UserId = 2,
                        FirstName = "Anja",
                        LastName = "Dva",
                        Email = "mobile",
                        PasswordHash = "ctdN66Ftv+YJP9LAK6i3dKDqchg=",
                        PasswordSalt = "NSqADQ/R7xKWHlTVz2BMwg==",
                        PhoneNumber = "+387603573562",
                        Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/AnjaDva.jpg"))
                    },
                    new User
                    {
                        UserId = 3,
                        FirstName = "Anja",
                        LastName = "Tri",
                        Email = "mobiletri",
                        PasswordHash = "ctdN66Ftv+YJP9LAK6i3dKDqchg=",
                        PasswordSalt = "NSqADQ/R7xKWHlTVz2BMwg==",
                        PhoneNumber = "+387603573562",
                        Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/AnjaTri.jpg"))
                    },
                    new User
                    {
                        UserId = 4,
                        FirstName = "Anja",
                        LastName = "Cetiri",
                        Email = "mobilecetiri",
                        PasswordHash = "ctdN66Ftv+YJP9LAK6i3dKDqchg=",
                        PasswordSalt = "NSqADQ/R7xKWHlTVz2BMwg==",
                        PhoneNumber = "+387603573562",
                        Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/AnjaTri.jpg"))
                    });

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.User ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.User OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Role.Any())
            {
                context.Role.AddRange(
                    new Role { RoleId = 1, Name = "Administrator" },
                    new Role { RoleId = 3, Name = "User" }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Role ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Role OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.UserRole.Any())
            {
                context.UserRole.AddRange(
                    new UserRole { UserRoleId = 1, UserId = 1, RoleId = 1 },
                    new UserRole { UserRoleId = 2, UserId = 1, RoleId = 3 },
                    new UserRole { UserRoleId = 3, UserId = 2, RoleId = 3 },
                    new UserRole { UserRoleId = 4, UserId = 3, RoleId = 3 }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserRole ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserRole OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Territory.Any())
            {
                context.Territory.AddRange(
                    new Territory { TerritoryId = 1, Name = "Sarajevo" },
                    new Territory { TerritoryId = 2, Name = "Hercegovačko - neretvanski" },
                    new Territory { TerritoryId = 3, Name = "Posavski" },
                    new Territory { TerritoryId = 4, Name = "Unsko - sanski" },
                    new Territory { TerritoryId = 5, Name = "Tuzlanski" },
                    new Territory { TerritoryId = 6, Name = "Zeničko - dobojski" },
                    new Territory { TerritoryId = 7, Name = "Bosansko - podrinjski" },
                    new Territory { TerritoryId = 8, Name = "Srednjobosanski" },
                    new Territory { TerritoryId = 9, Name = "Zapadnohercehovački" },
                    new Territory { TerritoryId = 10, Name = "Kanton 10" },
                    new Territory { TerritoryId = 11, Name = "Republika Srpska" },
                    new Territory { TerritoryId = 12, Name = "Brčko distrikt" }
                   );

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Territory ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Territory OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Wishlist.Any())
            {
                context.Wishlist.AddRange(
                    new Wishlist { WishlistId = 1, UserId = 1 },
                    new Wishlist { WishlistId = 2, UserId = 2 },
                    new Wishlist { WishlistId = 3, UserId = 3 }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Wishlist ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Wishlist OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Listing.Any())
            {
                context.Listing.AddRange(
                  new Listing
                  {
                      ListingId = 1,
                      Name = "Villa Lokve",
                      ListingDescription = "Objekt Villa Lokve nalazi se u Hadžićima u Kantonu Sarajevo i obuhvaća terasu.U ovoj su vikendici na raspolaganju vrt, oprema za roštilj, besplatan WiFi i besplatno privatno parkiralište. Ova vikendica uključuje klima - uređaj, 5 odvojenih spavaćih soba, dnevni boravak, potpuno opremljenu kuhinju i 4 kupaonice.Također ima TV ravnog ekrana. U okviru vikendice dostupni su dječje igralište i zajednički salon.",
                      AreaDescription = "Sarajevo je udaljeno 29 km od objekta Villa Lokve, a Ilidža 19 km.",
                      Address = "Lokve 1",
                      City = "Hadžići",
                      TerritoryId = 1,
                      Persons = 16,
                      Beds = 13,
                      Bathrooms = 4,
                      UserId = 1,
                      DateCreated = DateTime.Now.AddDays(-10),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-5)
                  },
                  new Listing
                  {
                      ListingId = 2,
                      Name = "Stara kuća estate",
                      ListingDescription = "Objekt Stara kuća Estate nalazi se u Grabu pokraj Ljubuškog, a uključuje smještaj u 4 kamene vile, novo renovirane s vanjskim sezonskim bazenom, dvorištem i vinarijom koja je dostupna gostima na korištenje i degustaciju domaćeg vina. Pojedine jedinice obuhvaćaju balkon i/ili popločani dio dvorišta. Gostima objekta Stara kuća Estate dostupna je oprema za roštilj, te vrtni namještaj i ležaljke za bazen. Gostima je po narudžbi dostupno domaće voće, povrće, vino, likeri i med.",
                      AreaDescription = "Aktivnosti u okolici uključuju planinarenje, pješačenje i vožnju biciklom, rafting, jahanje konja, kite surfing, padle surf, ronjenje, … U blizini, pola sata vožnje se nalazi svetište Međugorje, te Mostar, stari grad interesantan po svojim znamenitostima također za manje od sat vremena vožnje. U Mostaru se nalazi i aerodrom te je time i atraktivno i prometno povezana destinacija, kao i aerodromi u Dubrovniku i Splitu koji su cca 100km udaljeni, a posebni po svojim povijesnim znamenitostima. 7 km od objekta je i ulaz na autoput u Vrgorcu što je dodatna značajka u prometnoj povezanosti. Makarska rivijera sa svojim prekrasnim plažama i čistim morem je udaljena 40ak kilometara od objekta.",
                      Address = "Ljubuški 1",
                      City = "Ljubuški",
                      TerritoryId = 9,
                      Persons = 7,
                      Beds = 4,
                      Bathrooms = 2,
                      UserId = 1,
                      DateCreated = DateTime.Now.AddDays(-12),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-10)
                  },
                  new Listing
                  {
                      ListingId = 3,
                      Name = "Planinska kuća",
                      ListingDescription = "Planinska kuća smještena je na Bjelašnici te nudi zajednički salon, vrt i opremu za roštilj, ima  WiFi i privatno parkiralište. Ova planinska kuća uključuje 4 spavaće sobe, TV ravnog ekrana sa satelitskim programima, opremljenu kuhinju s perilicom posuđa i mikrovalnom pećnicom, perilicu rublja te 2 kupaonice s tušem. Planinska kuća ima terasu.",
                      AreaDescription = "Ovaj objekt udaljen je 40 km od Sarajeva. Skijanje, hiking, trailing, trekking.",
                      Address = "Bjelašnica 1",
                      City = "Sarajevo",
                      TerritoryId = 1,
                      Persons = 10,
                      Beds = 10,
                      Bathrooms = 3,
                      UserId = 1,
                      DateCreated = DateTime.Now.AddDays(-8),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-2)
                  },
                  new Listing
                  {
                      ListingId = 4,
                      Name = "Studio penthouse",
                      ListingDescription = "Moderno namjesten penthouse. Stan je moderno opremljen sa i sastoji se od ulaznog hodnika, kupatila, garderobera, dnevne sobe sa kuhinjom, spavace sobe i velike terase sa otvrenim pogledom.",
                      AreaDescription = "Cafes, restaurants, bus.",
                      Address = "Dž. Bijedića 129",
                      City = "Sarajevo",
                      TerritoryId = 1,
                      Persons = 2,
                      Beds = 1,
                      Bathrooms = 1,
                      UserId = 2,
                      DateCreated = DateTime.Now.AddDays(-15),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-1)
                  },
                  new Listing
                  {
                      ListingId = 5,
                      Name = "Studio u centru",
                      ListingDescription = "Moderno namjesten stan otvorenog koncepta.",
                      AreaDescription = "Centar Mostara, trgovine, kazalište, kino.",
                      Address = "Stjepana Radića 10",
                      City = "Mostar",
                      TerritoryId = 2,
                      Persons = 2,
                      Beds = 1,
                      Bathrooms = 1,
                      UserId = 2,
                      DateCreated = DateTime.Now.AddDays(-2),
                      Approved = false,
                      DateApproved = new DateTime()
                  });

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Listing ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Listing OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.ListingAmenity.Any())
            {
                context.ListingAmenity.AddRange(
                    new ListingAmenity { ListingAmenityId = 47, ListingId = 2, AmenityId = 14 },
                    new ListingAmenity { ListingAmenityId = 48, ListingId = 2, AmenityId = 18 },
                    new ListingAmenity { ListingAmenityId = 49, ListingId = 2, AmenityId = 12 },
                    new ListingAmenity { ListingAmenityId = 50, ListingId = 2, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 51, ListingId = 3, AmenityId = 5 },
                    new ListingAmenity { ListingAmenityId = 52, ListingId = 3, AmenityId = 18 },
                    new ListingAmenity { ListingAmenityId = 53, ListingId = 3, AmenityId = 12 },
                    new ListingAmenity { ListingAmenityId = 54, ListingId = 3, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 55, ListingId = 3, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 56, ListingId = 4, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 57, ListingId = 4, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 58, ListingId = 4, AmenityId = 16 },
                    new ListingAmenity { ListingAmenityId = 59, ListingId = 4, AmenityId = 10 },
                    new ListingAmenity { ListingAmenityId = 60, ListingId = 4, AmenityId = 4 },
                    new ListingAmenity { ListingAmenityId = 62, ListingId = 1, AmenityId = 5 },
                    new ListingAmenity { ListingAmenityId = 63, ListingId = 1, AmenityId = 18 },
                    new ListingAmenity { ListingAmenityId = 64, ListingId = 1, AmenityId = 13 },
                    new ListingAmenity { ListingAmenityId = 65, ListingId = 1, AmenityId = 12 },
                    new ListingAmenity { ListingAmenityId = 66, ListingId = 1, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 67, ListingId = 1, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 68, ListingId = 1, AmenityId = 8 },
                    new ListingAmenity { ListingAmenityId = 69, ListingId = 1, AmenityId = 10 },
                    new ListingAmenity { ListingAmenityId = 70, ListingId = 1, AmenityId = 4 },
                    new ListingAmenity { ListingAmenityId = 75, ListingId = 5, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 76, ListingId = 5, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 77, ListingId = 5, AmenityId = 16 },
                    new ListingAmenity { ListingAmenityId = 78, ListingId = 5, AmenityId = 10 },
                    new ListingAmenity { ListingAmenityId = 79, ListingId = 5, AmenityId = 4 }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ListingAmenity ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ListingAmenity OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.ListingImage.Any())
            {
                context.ListingImage.AddRange(
                    new ListingImage { ListingImageId = 1, ListingId = 1, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/lokve1.jpg")) },
                    new ListingImage { ListingImageId = 2, ListingId = 1, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/lokve2.jpg")) },
                    new ListingImage { ListingImageId = 3, ListingId = 1, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/lokve3.jpg")) },

                    new ListingImage { ListingImageId = 4, ListingId = 2, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/vila1.jpg")) },
                    new ListingImage { ListingImageId = 5, ListingId = 2, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/vila2.jpg")) },
                    new ListingImage { ListingImageId = 6, ListingId = 2, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/vila3.jpg")) },
                    new ListingImage { ListingImageId = 7, ListingId = 2, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/vila4.jpg")) },
                    new ListingImage { ListingImageId = 8, ListingId = 2, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/vila5.jpg")) },

                    new ListingImage { ListingImageId = 9, ListingId = 3, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/chalet1.jpg")) },
                    new ListingImage { ListingImageId = 10, ListingId = 3, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/chalet2.jpg")) },
                    new ListingImage { ListingImageId = 11, ListingId = 3, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/chalet3.jpg")) },

                    new ListingImage { ListingImageId = 12, ListingId = 4, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/penthouse1.jpg")) },
                    new ListingImage { ListingImageId = 13, ListingId = 4, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/penthouse2.jpg")) },
                    new ListingImage { ListingImageId = 14, ListingId = 4, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/penthouse3.jpg")) },
                    new ListingImage { ListingImageId = 15, ListingId = 4, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/penthouse4.jpg")) },
                    new ListingImage { ListingImageId = 16, ListingId = 4, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/penthouse5.jpg")) },

                    new ListingImage { ListingImageId = 17, ListingId = 5, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/studio1.jpg")) },
                    new ListingImage { ListingImageId = 18, ListingId = 5, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/studio2.jpg")) },
                    new ListingImage { ListingImageId = 19, ListingId = 5, Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/studio3.jpg")) }
                  );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ListingImage ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ListingImage OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Rating.Any())
            {
                context.Rating.AddRange(
                    new Rating { RatingId = 1, UserId = 3, ListingId = 1, RatingValue = 4 },
                    new Rating { RatingId = 2, UserId = 3, ListingId = 2, RatingValue = 4 },
                    new Rating { RatingId = 3, UserId = 3, ListingId = 3, RatingValue = 5 },
                    new Rating { RatingId = 4, UserId = 3, ListingId = 4, RatingValue = 4 },

                    new Rating { RatingId = 5, UserId = 2, ListingId = 1, RatingValue = 4 },
                    new Rating { RatingId = 6, UserId = 2, ListingId = 2, RatingValue = 4 },

                    new Rating { RatingId = 1, UserId = 4, ListingId = 1, RatingValue = 3 },
                    new Rating { RatingId = 2, UserId = 4, ListingId = 2, RatingValue = 2 },
                    new Rating { RatingId = 3, UserId = 4, ListingId = 3, RatingValue = 5 },
                    new Rating { RatingId = 4, UserId = 4, ListingId = 4, RatingValue = 4 }
                  );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Rating ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Rating OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            //if (!context.WishlistListing.Any())
            //{
            //    context.WishlistListing.AddRange(new WishlistListing { WishlistListingId = 1, WishlistId = 2, ListingId = 1 });
            //    context.Database.OpenConnection();
            //    try
            //    {
            //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.WishlistListing ON");
            //        context.SaveChanges();
            //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.WishlistListing OFF");
            //    }
            //    finally
            //    {
            //        context.Database.CloseConnection();
            //    }
            //}
        }


    }
}