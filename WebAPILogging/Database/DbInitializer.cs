using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIWPlusSequence.Models;

namespace WebAPIWPlusSequence.Database
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ShoppingContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ShoppingContext>())
                {
                    if (!context.Groceries.Any())
                    {
                        //var adminUser = new Grocery { Id = Guid.NewGuid(), Name = "Hunt's Tomato Paste", Description = "Hunt's Tomato Paste, 6 oz", Quantity = 3, Price = 0.49M };
                        //context.Users.Add(adminUser);
                        var lstFood = new List<Grocery> {
                                        new Grocery { Id = Guid.NewGuid(), Name = "Hunt's Tomato Paste", Description = "Hunt's Tomato Paste, 6 oz", Quantity = 3, Price = 0.49M },
                                        new Grocery { Id = Guid.NewGuid(), Name = "Plantains", Description = "Ripe plantains", Quantity = 8, Price = 0.79M },
                                        new Grocery { Id = Guid.NewGuid(), Name = "12 Pack Beer", Description = "Heineken lager", Quantity = 1, Price = 14.49M }
                                        };
                        foreach (var item in lstFood)
                        {
                            context.Groceries.Add(item);
                        }

                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
