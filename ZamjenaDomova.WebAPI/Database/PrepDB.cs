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
                        UserId = 16,
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
                        UserId = 24,
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
                        UserId = 24,
                        FirstName = "Anja",
                        LastName = "Tri",
                        Email = "mobile",
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
                    new UserRole { UserRoleId = 1, UserId = 16, RoleId = 1 },
                    new UserRole { UserRoleId = 2, UserId = 16, RoleId = 3 },
                    new UserRole { UserRoleId = 3, UserId = 24, RoleId = 3 },
                    new UserRole { UserRoleId = 4, UserId = 25, RoleId = 3 }
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
                    new Wishlist { WishlistId = 1, UserId = 16 },
                    new Wishlist { WishlistId = 2, UserId = 24 },
                    new Wishlist { WishlistId = 3, UserId = 25 }
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
                      ListingId = 38,
                      Name = "Villa Lokve",
                      ListingDescription = "Objekt Villa Lokve nalazi se u Hadžićima u Kantonu Sarajevo i obuhvaća terasu.U ovoj su vikendici na raspolaganju vrt, oprema za roštilj, besplatan WiFi i besplatno privatno parkiralište. Ova vikendica uključuje klima - uređaj, 5 odvojenih spavaćih soba, dnevni boravak, potpuno opremljenu kuhinju i 4 kupaonice.Također ima TV ravnog ekrana. U okviru vikendice dostupni su dječje igralište i zajednički salon.",
                      AreaDescription = "Sarajevo je udaljeno 29 km od objekta Villa Lokve, a Ilidža 19 km.",
                      Address = "Lokve 1",
                      City = "Hadžići",
                      TerritoryId = 1,
                      Persons = 16,
                      Beds = 13,
                      Bathrooms = 4,
                      UserId = 16,
                      DateCreated = DateTime.Now.AddDays(-10),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-5)
                  },
                  new Listing
                  {
                      ListingId = 33,
                      Name = "Stara kuća estate",
                      ListingDescription = "Objekt Stara kuća Estate nalazi se u Grabu pokraj Ljubuškog, a uključuje smještaj u 4 kamene vile, novo renovirane s vanjskim sezonskim bazenom, dvorištem i vinarijom koja je dostupna gostima na korištenje i degustaciju domaćeg vina. Pojedine jedinice obuhvaćaju balkon i/ili popločani dio dvorišta. Gostima objekta Stara kuća Estate dostupna je oprema za roštilj, te vrtni namještaj i ležaljke za bazen. Gostima je po narudžbi dostupno domaće voće, povrće, vino, likeri i med.",
                      AreaDescription = "Aktivnosti u okolici uključuju planinarenje, pješačenje i vožnju biciklom, rafting, jahanje konja, kite surfing, padle surf, ronjenje, … U blizini, pola sata vožnje se nalazi svetište Međugorje, te Mostar, stari grad interesantan po svojim znamenitostima također za manje od sat vremena vožnje. U Mostaru se nalazi i aerodrom te je time i atraktivno i prometno povezana destinacija, kao i aerodromi u Dubrovniku i Splitu koji su cca 100km udaljeni, a posebni po svojim povijesnim znamenitostima. 7 km od objekta je i ulaz na autoput u Vrgorcu što je dodatna značajka u prometnoj povezanosti. Makarska rivijera sa svojim prekrasnim plažama i čistim morem je udaljena 40ak kilometara od objekta.",
                      Address = "Ljubuški 1",
                      City = "Ljubuški",
                      TerritoryId = 9,
                      Persons = 7,
                      Beds = 4,
                      Bathrooms = 2,
                      UserId = 16,
                      DateCreated = DateTime.Now.AddDays(-12),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-10)
                  },
                  new Listing
                  {
                      ListingId = 34,
                      Name = "Planinska kuća",
                      ListingDescription = "Planinska kuća smještena je na Bjelašnici te nudi zajednički salon, vrt i opremu za roštilj, ima  WiFi i privatno parkiralište. Ova planinska kuća uključuje 4 spavaće sobe, TV ravnog ekrana sa satelitskim programima, opremljenu kuhinju s perilicom posuđa i mikrovalnom pećnicom, perilicu rublja te 2 kupaonice s tušem. Planinska kuća ima terasu.",
                      AreaDescription = "Ovaj objekt udaljen je 40 km od Sarajeva. Skijanje, hiking, trailing, trekking.",
                      Address = "Bjelašnica 1",
                      City = "Sarajevo",
                      TerritoryId = 1,
                      Persons = 10,
                      Beds = 10,
                      Bathrooms = 3,
                      UserId = 16,
                      DateCreated = DateTime.Now.AddDays(-8),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-2)
                  },
                  new Listing
                  {
                      ListingId = 35,
                      Name = "Studio penthouse",
                      ListingDescription = "Moderno namjesten penthouse. Stan je moderno opremljen sa i sastoji se od ulaznog hodnika, kupatila, garderobera, dnevne sobe sa kuhinjom, spavace sobe i velike terase sa otvrenim pogledom.",
                      AreaDescription = "Cafes, restaurants, bus.",
                      Address = "Dž. Bijedića 129",
                      City = "Sarajevo",
                      TerritoryId = 1,
                      Persons = 2,
                      Beds = 1,
                      Bathrooms = 1,
                      UserId = 16,
                      DateCreated = DateTime.Now.AddDays(-15),
                      Approved = true,
                      DateApproved = DateTime.Now.AddDays(-1)
                  },
                  new Listing
                  {
                      ListingId = 42,
                      Name = "Studio u centru",
                      ListingDescription = "Moderno namjesten stan otvorenog koncepta.",
                      AreaDescription = "Centar Mostara, trgovine, kazalište, kino.",
                      Address = "Stjepana Radića 10",
                      City = "Mostar",
                      TerritoryId = 2,
                      Persons = 2,
                      Beds = 1,
                      Bathrooms = 1,
                      UserId = 24,
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
                    new ListingAmenity { ListingAmenityId = 47, ListingId = 33, AmenityId = 14 },
                    new ListingAmenity { ListingAmenityId = 48, ListingId = 33, AmenityId = 18 },
                    new ListingAmenity { ListingAmenityId = 49, ListingId = 33, AmenityId = 12 },
                    new ListingAmenity { ListingAmenityId = 50, ListingId = 33, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 51, ListingId = 34, AmenityId = 5 },
                    new ListingAmenity { ListingAmenityId = 52, ListingId = 34, AmenityId = 18 },
                    new ListingAmenity { ListingAmenityId = 53, ListingId = 34, AmenityId = 12 },
                    new ListingAmenity { ListingAmenityId = 54, ListingId = 34, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 55, ListingId = 34, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 56, ListingId = 35, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 57, ListingId = 35, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 58, ListingId = 35, AmenityId = 16 },
                    new ListingAmenity { ListingAmenityId = 59, ListingId = 35, AmenityId = 10 },
                    new ListingAmenity { ListingAmenityId = 60, ListingId = 35, AmenityId = 4 },
                    new ListingAmenity { ListingAmenityId = 62, ListingId = 38, AmenityId = 5 },
                    new ListingAmenity { ListingAmenityId = 63, ListingId = 38, AmenityId = 18 },
                    new ListingAmenity { ListingAmenityId = 64, ListingId = 38, AmenityId = 13 },
                    new ListingAmenity { ListingAmenityId = 65, ListingId = 38, AmenityId = 12 },
                    new ListingAmenity { ListingAmenityId = 66, ListingId = 38, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 67, ListingId = 38, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 68, ListingId = 38, AmenityId = 8 },
                    new ListingAmenity { ListingAmenityId = 69, ListingId = 38, AmenityId = 10 },
                    new ListingAmenity { ListingAmenityId = 70, ListingId = 38, AmenityId = 4 },
                    new ListingAmenity { ListingAmenityId = 75, ListingId = 42, AmenityId = 7 },
                    new ListingAmenity { ListingAmenityId = 76, ListingId = 42, AmenityId = 1 },
                    new ListingAmenity { ListingAmenityId = 77, ListingId = 42, AmenityId = 16 },
                    new ListingAmenity { ListingAmenityId = 78, ListingId = 42, AmenityId = 10 },
                    new ListingAmenity { ListingAmenityId = 79, ListingId = 42, AmenityId = 4 }
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


            //if (!context.SlikeVozila.Any())
            //{
            //    context.SlikeVozila.AddRange(
            //        new SlikaVozila { SlikaVozilaId = 1, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_1.jpg")) },
            //        new SlikaVozila { SlikaVozilaId = 2, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_2.jpg")) },
            //        new SlikaVozila { SlikaVozilaId = 3, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_3.jpg")) },
            //        new SlikaVozila { SlikaVozilaId = 4, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_4.jpg")) },

            //        new SlikaVozila { SlikaVozilaId = 5, VoziloId = 2, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo2_1.jpg")) },

            //        new SlikaVozila { SlikaVozilaId = 6, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 7, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_2.png")) },
            //        new SlikaVozila { SlikaVozilaId = 8, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_3.png")) },
            //        new SlikaVozila { SlikaVozilaId = 10, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_4.png")) },

            //        new SlikaVozila { SlikaVozilaId = 11, VoziloId = 4, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo4_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 12, VoziloId = 4, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo4_2.png")) },

            //        new SlikaVozila { SlikaVozilaId = 13, VoziloId = 5, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo5_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 14, VoziloId = 5, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo5_2.png")) },
            //        new SlikaVozila { SlikaVozilaId = 15, VoziloId = 5, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo5_3.png")) },

            //        new SlikaVozila { SlikaVozilaId = 16, VoziloId = 6, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo6_1.png")) },

            //        new SlikaVozila { SlikaVozilaId = 17, VoziloId = 7, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo7_1.jpg")) },
            //        new SlikaVozila { SlikaVozilaId = 18, VoziloId = 7, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo7_2.png")) },

            //        new SlikaVozila { SlikaVozilaId = 19, VoziloId = 8, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo8_1.jpg")) },

            //        new SlikaVozila { SlikaVozilaId = 20, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 21, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_2.png")) },
            //        new SlikaVozila { SlikaVozilaId = 22, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_3.png")) },
            //        new SlikaVozila { SlikaVozilaId = 23, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_4.png")) },

            //        new SlikaVozila { SlikaVozilaId = 24, VoziloId = 10, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo10_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 25, VoziloId = 10, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo10_2.png")) },

            //        new SlikaVozila { SlikaVozilaId = 26, VoziloId = 11, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo11_1.png")) },

            //        new SlikaVozila { SlikaVozilaId = 27, VoziloId = 12, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo12_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 28, VoziloId = 12, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo12_2.png")) },

            //        new SlikaVozila { SlikaVozilaId = 29, VoziloId = 13, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo13_1.png")) },
            //        new SlikaVozila { SlikaVozilaId = 30, VoziloId = 13, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo13_2.png")) },
            //        new SlikaVozila { SlikaVozilaId = 31, VoziloId = 13, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo13_3.png")) },

            //        new SlikaVozila { SlikaVozilaId = 32, VoziloId = 14, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo14_1.png")) }
            //    );
            //    context.Database.OpenConnection();
            //    try
            //    {
            //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SlikeVozila ON");
            //        context.SaveChanges();
            //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SlikeVozila OFF");
            //    }
            //    finally
            //    {
            //        context.Database.CloseConnection();
            //    }
            //}

            //if (!context.Ocjene.Any())
            //{
            //    context.Ocjene.AddRange(
            //        new Ocjena { OcjenaId = 1, KorisnikId = 3, VoziloId = 1, DataOcjena = 5 },
            //        new Ocjena { OcjenaId = 2, KorisnikId = 3, VoziloId = 2, DataOcjena = 5 },
            //        new Ocjena { OcjenaId = 3, KorisnikId = 3, VoziloId = 4, DataOcjena = 3 },
            //        new Ocjena { OcjenaId = 4, KorisnikId = 3, VoziloId = 13, DataOcjena = 5 },

            //        new Ocjena { OcjenaId = 5, KorisnikId = 4, VoziloId = 1, DataOcjena = 4 },
            //        new Ocjena { OcjenaId = 6, KorisnikId = 4, VoziloId = 2, DataOcjena = 5 },
            //        new Ocjena { OcjenaId = 7, KorisnikId = 4, VoziloId = 4, DataOcjena = 3 },
            //        new Ocjena { OcjenaId = 8, KorisnikId = 4, VoziloId = 13, DataOcjena = 5 },

            //        new Ocjena { OcjenaId = 9, KorisnikId = 5, VoziloId = 3, DataOcjena = 4 },

            //        new Ocjena { OcjenaId = 10, KorisnikId = 6, VoziloId = 5, DataOcjena = 4 },

            //        new Ocjena { OcjenaId = 11, KorisnikId = 7, VoziloId = 6, DataOcjena = 4 },

            //        new Ocjena { OcjenaId = 12, KorisnikId = 8, VoziloId = 12, DataOcjena = 2 }
            //    );
            //    context.Database.OpenConnection();
            //    try
            //    {
            //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ocjene ON");
            //        context.SaveChanges();
            //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ocjene OFF");
            //    }
            //    finally
            //    {
            //        context.Database.CloseConnection();
            //    }
        }
    }


}