using PetStore.Services.Models.Category;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        bool Exists(int categoryId);

        IEnumerable<AllCategoriesServiceModel> All();

        void Create(CreateCategoryServiceModel model);

        DetailsCategoryServiceModel GetById(int id);

        void Edit(EditCategoryServiceModel model);

        bool Remove(int id);
    }
}
