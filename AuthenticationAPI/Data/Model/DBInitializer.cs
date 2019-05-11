using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Data.Model
{
    public class DBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
               var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User() { Email = "abc@xyz", Password = "123456", BuyerName = "XYZ", CreationDateTime = DateTime.Now, Address = "gfhg", UserUid = Guid.NewGuid() },
                    new User() { Email = "pqr@xyz", Password = "aaaaaa", BuyerName = "PQR", CreationDateTime = DateTime.Now, Address = "gfhg", UserUid = Guid.NewGuid() }

                        );

                }
            //    if (!context.Categories.Any())
            //    {
            //        context.Categories.AddRange(Categories.Select(c => c.Value));
            //    }
                
            //    if (!context.Weapons.Any())
            //    {
            //        context.AddRange(
            //                 new Weapon()
            //                 {
            //                     Description = "Smith & Wesson 686 Stainless 6 357MAG Revolvr NEW",
            //                     ImageUrl = "/Images/1_Cat1.jpg",
            //                     Price = 100000M,
            //                     InStock = 5,
            //                     IsTrending = true,
            //                     Name = "Smith & Wesson 686 Stainless 6 357MAG Revolvr NEW",
            //                     Category = Categories["Pistol"]
            //                 },
            //                new Weapon()
            //                {
            //                    Description = "TAURUS MODEL 94 .22LR",
            //                    ImageUrl = "/Images/2_Cat1.jpg",
            //                    Price = 100660M,
            //                    InStock = 10,
            //                    IsTrending = false,
            //                    Name = "TAURUS MODEL 94 .22LR",
            //                    Category = Categories["Pistol"]
            //                },
            //                new Weapon()
            //                {
            //                    Description = "COLT 38 DS II - NO CC FEES!",
            //                    ImageUrl = "/Images/3_Cat1.jpg",
            //                    Price = 90000M,
            //                    InStock = 2,
            //                    IsTrending = false,
            //                    Name = "COLT 38 DS II - NO CC FEES!",
            //                    Category = Categories["Pistol"]

            //                },
            //                new Weapon()
            //                {
            //                    Description = "Ruger Bearcat .22 LR 1971",
            //                    ImageUrl = "/Images/4_Cat1.jpg",
            //                    Price = 350000M,
            //                    InStock = 10,
            //                    IsTrending = true,
            //                    Name = "Ruger Bearcat .22 LR 1971",
            //                    Category = Categories["Pistol"]

            //                },
            //                new Weapon()
            //                {
            //                    Description = "Pointer Phenoma PPHCW2028GRY 20/28 3 Walther 5CT",
            //                    ImageUrl = "/Images/1_Cat2.jpg",
            //                    Price = 600000M,
            //                    InStock = 50,
            //                    IsTrending = true,
            //                    Name = "Pointer Phenoma PPHCW2028GRY 20/28 3 Walther 5CT",
            //                    Category = Categories["ShotGun"]

            //                },
            //                new Weapon()
            //                {
            //                    Description = "Remington TAC-14 12GA Wood Remington TAC14 81231",
            //                    ImageUrl = "/Images/2_Cat2.jpg",
            //                    Price = 956320M,
            //                    InStock = 10,
            //                    IsTrending = true,
            //                    Name = "Remington TAC-14 12GA Wood Remington TAC14 81231",
            //                    Category = Categories["ShotGun"]
            //                }
            //            );
            //    }
            //    context.SaveChanges();
            //}
            //AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();
           

        }
        //private static Dictionary<string, Category> categories;
        //public static Dictionary<string, Category> Categories
        //{
        //    get
        //    {
        //        if (categories == null)
        //        {
        //            var genresList = new Category[]
        //            {
        //             new Category(){ CategoryName="Pistol",Description="A pistol is a type of handgun. The pistol originates in the 16th century, when early handguns were produced in Europe."},
        //             new Category(){ CategoryName="ShotGun",Description="A shotgun is a firearm that is usually designed to be fired from the shoulder, which uses the energy of a fixed shell to fire a number of small spherical pellets."},
        //            };

        //            categories = new Dictionary<string, Category>();

        //            foreach (Category genre in genresList)
        //            {
        //                categories.Add(genre.CategoryName, genre);
        //            }
        //        }

        //        return categories;
        //    }
        }
    }
}
