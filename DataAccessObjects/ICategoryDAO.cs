using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface ICategoryDAO
    {
        Task<List<CategoryObj>> GetAll();
        Task<CategoryObj> AddCategory(CategoryObj categoryObj);
        Task<CategoryObj> UpdateCategory(CategoryObj categoryObj);
        Task<CategoryObj> GetCategoryById(int id);
        Task<int> DeleteCategory(int id);

    }
}
