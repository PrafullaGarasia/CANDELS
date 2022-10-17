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
                        Rating = "R"
                    },

                    new Candel
                    {
                        Type = "Natural",
                        Color = "Mix Color",
                        MadeFrom = "Vegetable Wax",
                        Fragrance = "Yes",
                        ExpiryDate = DateTime.Parse("2022-5-13"),
                        Price = 8.99M,
                        Rating = "R"
                    },

                    new Candel
                    {
                        Type = "Natural",
                        Color = "White",
                        MadeFrom = "Soy",
                        Fragrance = "No",
                        ExpiryDate = DateTime.Parse("2022-6-14"),
                        Price = 9.99M,
                        Rating = "R"
                    },

                    new Candel
                    {
                        Type = "Artificial",
                        Color = "Yellow",
                        MadeFrom = "Plastic",
                        Fragrance = "No",
                        ExpiryDate = DateTime.Parse("2022-7-16"),
                        Price = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
