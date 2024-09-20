using BusinessObjects;
using DataAccessObjects;
using Microsoft.Extensions.Logging;

namespace BusinessAccessObjects
{
    public class CategoryBAL:ICategoryBAL
    {
        private readonly ICategoryDAO _categoryDAO;
        private readonly ILogger<CategoryBAL> _logger;

        public CategoryBAL(ICategoryDAO categoryDAO, ILogger<CategoryBAL> logger)
        { 
            _categoryDAO = categoryDAO;
            _logger = logger;
        }

        public async Task<List<CategoryObj>> GetAll()
        {
            try
            {
                return await _categoryDAO.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<CategoryObj> AddCategory(CategoryObj categoryObj)
        {
            try
            {
                return await _categoryDAO.AddCategory(categoryObj);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<CategoryObj> UpdateCategory(CategoryObj categoryObj)
        {
            try
            {
                return await _categoryDAO.UpdateCategory(categoryObj);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<CategoryObj> GetCategoryById(int id)
        {
            try
            {
                return await _categoryDAO.GetCategoryById(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> DeleteCategory(int id)
        {
            try
            {
                return await _categoryDAO.DeleteCategory(id);      
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
