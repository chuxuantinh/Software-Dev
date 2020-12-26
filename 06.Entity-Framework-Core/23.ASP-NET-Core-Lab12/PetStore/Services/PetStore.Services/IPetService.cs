using PetStore.Data.Models;
using PetStore.Services.Models.Pet;
using System;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> All(int page = 1);

        void BuyPet(Gender gender, DateTime dateTime, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);

        int Total();

        PetDetailsServiceModel Details(int id);

        bool Delete(int id);
    }
}
