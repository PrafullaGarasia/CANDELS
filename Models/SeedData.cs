using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCandel.Data;

namespace MvcCandel.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCandelContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCandelContext>>()))
            {
                // Look for any Candels.
                if (context.Candel.Any())
                {
                    return;   // DB has been seeded
                }

                context.Candel.AddRange(
                    new Candel
                    {
                        Type = "Natural",
                        Color = "White",
                        MadeFrom = "Bee Wax",
                        Fragrance = "Yes",
                        ExpiryDate = DateTime.Parse("2022-2-12"),
                        Price = 7.99M,
                        Rating = "4"
                    },

                    new Candel
                    {
                        Type = "Natural",
                        Color = "Mix Color",
                        MadeFrom = "Vegetable Wax",
                        Fragrance = "Yes",
                        ExpiryDate = DateTime.Parse("2022-5-13"),
                        Price = 8.99M,
                        Rating = "3"
                    },

                    new Candel
                    {
                        Type = "Natural",
                        Color = "White",
                        MadeFrom = "Soy",
                        Fragrance = "No",
                        ExpiryDate = DateTime.Parse("2022-6-14"),
                        Price = 9.99M,
                        Rating = "5"
                    },

                    new Candel
                    {
                        Type = "Natural",
                        Color = "Blue",
                        MadeFrom = "Wax",
                        Fragrance = "No",
                        ExpiryDate = DateTime.Parse("2022-6-12"),
                        Price = 5.99M,
                        Rating = "5"
                    },

                    new Candel
                    {
                        Type = "Natural",
                        Color = "White",
                        MadeFrom = "Bee Wax",
                        Fragrance = "Yes",
                        ExpiryDate = DateTime.Parse("2022-6-15"),
                        Price = 7.99M,
                        Rating = "4"
                    },

                    new Candel
                    {
                        Type = "Artificial",
                        Color = "White",
                        MadeFrom = "Plastic",
                        Fragrance = "No",
                        ExpiryDate = DateTime.Parse("2022-6-14"),
                        Price = 9.99M,
                        Rating = "5"
                    },

                     new Candel
                     {
                         Type = "Artificial",
                         Color = "Black",
                         MadeFrom = "Plastic",
                         Fragrance = "No",
                         ExpiryDate = DateTime.Parse("2022-6-13"),
                         Price = 12.99M,
                         Rating = "3"
                     },

                      new Candel
                      {
                          Type = "Artificial",
                          Color = "Mix Color",
                          MadeFrom = "Plastic",
                          Fragrance = "No",
                          ExpiryDate = DateTime.Parse("2022-6-12"),
                          Price = 11.99M,
                          Rating = "5"
                      },

                       new Candel
                       {
                           Type = "Artificial",
                           Color = "Blue",
                           MadeFrom = "Plastic",
                           Fragrance = "No",
                           ExpiryDate = DateTime.Parse("2022-6-11"),
                           Price = 22.99M,
                           Rating = "2"
                       },

                    new Candel
                    {
                        Type = "Artificial",
                        Color = "Yellow",
                        MadeFrom = "Plastic",
                        Fragrance = "No",
                        ExpiryDate = DateTime.Parse("2022-7-16"),
                        Price = 3.99M,
                        Rating = "4"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
