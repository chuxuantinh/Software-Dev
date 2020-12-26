using PetStore.Data;
using PetStore.Services.Implementations;
using System;

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

                var userService = new UserService(data);
                //var foodService = new FoodService(data, userService);

                //foodService.BuyFromDistributor("Cat food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);
                //var toyService = new ToyService(data, userService);
                //var toyService = new ToyService(data);
                var breedService = new BreedService(data);
                var categoryService = new CategoryService(data);
                //toyService.BuyFromDistributor("Ball", null, 3.50m, 0.3, 1, 1);

                //userService.Register("Pesho", "pesho@abv.bg");
                //foodService.SellFoodToUser(1, 1);

                //toyService.SellToyToUser(1, 1);

                //breedService.Add("Persian");

                var petService = new PetService(data, breedService, categoryService, userService);

                //petService.BuyPet(Data.Models.Gender.Male, DateTime.Now, 0m, null, 1, 1);
                petService.SellPet(1, 1);
            }
        }
    }
}
