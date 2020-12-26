using System;


namespace PetStore.Services
{
    using Models.Brand;
    using PetStore.Data.Models;
    using System.Collections.Generic;

    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandWithToysServiceModel FindByIdWithToys(int id);

        
    }
}
