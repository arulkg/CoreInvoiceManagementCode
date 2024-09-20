using BusinessObjects;

namespace BusinessAccessObjects
{
    public interface ICategoryBAL
    {
        Task<List<CategoryObj>> GetAll();
        Task<CategoryObj> AddCategory(CategoryObj categoryObj);
        Task<CategoryObj> UpdateCategory(CategoryObj categoryObj);
        Task<CategoryObj> GetCategoryById(int id);
        Task<int> DeleteCategory(int id);
    }
}
