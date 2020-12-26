using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Implementations;
using System;
using System.Linq;

namespace PetStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using var data = new PetStoreDbContext();

            //var brandService = new BrandService(data);

            //brandService.Create("Purrina");

            //var brandWithToys = brandService.FindByIdWithToys(1);

            using (var data = new PetStoreDbContext())
            {
                //data.Database.EnsureDeleted();

                //var userService = new UserService(data);
                //var foodService = new FoodService(data, userService);

                //foodService.BuyFromDistributor("Cat food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);
                //var toyService = new ToyService(data, userService);
                //var toyService = new ToyService(data);
                //var breedService = new BreedService(data);
                //var categoryService = new CategoryService(data);
                //toyService.BuyFromDistributor("Ball", null, 3.50m, 0.3, 1, 1);

                //userService.Register("Pesho", "pesho@abv.bg");
                //foodService.SellFoodToUser(1, 1);

                //toyService.SellToyToUser(1, 1);

                //breedService.Add("Persian");

                //var petService = new PetService(data, breedService, categoryService, userService);

                //petService.BuyPet(Data.Models.Gender.Male, DateTime.Now, 0m, null, 1, 1);
                //petService.SellPet(1, 1);

                for (int i = 0; i < 10; i++)
                {
                    var breed = new Breed
                    {
                        Name = "Breed" + i
                    };

                    data.Breeds.Add(breed);
                }

                data.SaveChanges();

                for (int i = 0; i < 10; i++)
                {
                    var category = new Category
                    {
                        Name = "Category" + i,
                        Description = "Category description" + i
                    };

                    data.Categories.Add(category);
                }

                data.SaveChanges();

                for (int i = 0; i < 100; i++)
                {
                    var breedId = data
                        .Breeds
                        .OrderBy(b => Guid.NewGuid())
                        .Select(b => b.Id)
                        .FirstOrDefault();

                    var categoryId = data
                        .Categories
                        .OrderBy(c => Guid.NewGuid())
                        .Select(c => c.Id)
                        .FirstOrDefault();

                    var pet = new Pet
                    {
                        DateOfBirth = DateTime.UtcNow.AddDays(-60 + i),
                        Price = 50 + i,
                        Gender = (Gender)(i % 2),
                        Description = "Some random description" + i,
                        CategoryId = categoryId,
                        BreedId = breedId
                    };

                    data.Pets.Add(pet);
                }

                data.SaveChanges();
            }
        }
    }
}
