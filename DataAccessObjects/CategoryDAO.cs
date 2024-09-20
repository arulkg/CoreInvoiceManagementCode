using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CategoryDAO:ICategoryDAO
    {
        private readonly IMGCoreDbContext _dbContext;
        private readonly ILogger<CategoryDAO> _logger;

        public CategoryDAO(IMGCoreDbContext dbContext, ILogger<CategoryDAO> logger) { 
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<CategoryObj>> GetAll()
        {
            List<CategoryObj> list = new List<CategoryObj>();
            try
            {
                list = await _dbContext.Categories.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
        public async Task<CategoryObj> AddCategory(CategoryObj categoryObj)
        { 
            try
            {
                var obj = await _dbContext.Categories.AddAsync(categoryObj);
                await _dbContext.SaveChangesAsync();
                return obj.Entity;
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
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryObj.Id);
                if (existingCategory != null)
                {
                    _dbContext.Entry(existingCategory).State = EntityState.Detached;
                }

                var obj = _dbContext.Categories.Update(categoryObj);
                await _dbContext.SaveChangesAsync();
                return obj.Entity;
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
               var categoryObj = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (categoryObj == null) throw new Exception("Category not found");
               return categoryObj;
            }
            catch (Exception ex)
            {

                throw ;
            }
        }
        public async Task<int> DeleteCategory(int id)
        {
            try
            {
                var categoryObj = await _dbContext.Categories.FindAsync(id);
                if (categoryObj == null) throw new Exception("Category does not find");
                _dbContext.Categories.Remove(categoryObj);
                await _dbContext.SaveChangesAsync();
                return categoryObj.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
