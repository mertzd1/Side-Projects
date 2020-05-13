using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TRCollection.Models {

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                        Name = "SurfBoard", Description = "A beautiful cutting board inspired by the waves!",
                        Category = "Cutting Boards", Price = 175
                    },
                    new Product {
                        Name = "Apple Board",
                        Description = "Protective and fashionable",
                        Category = "Cutting Boards", Price = 125
                    },
                    new Product {
                        Name = "Cheese Slicer",
                        Description = "Elegantance that matches your cheeses",
                        Category = "Cheese Boards", Price = 100
                    }                    
                );
                context.SaveChanges();
            }
        }
    }
}
