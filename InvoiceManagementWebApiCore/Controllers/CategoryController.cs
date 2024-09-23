using BusinessAccessObjects;
using BusinessObjects;
using InvoiceManagementWebApiCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace InvoiceManagementWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBAL _categoryBAL;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryBAL categoryBAL, ILogger<CategoryController> logger)
        { 
            _categoryBAL = categoryBAL;
            _logger = logger;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<StandardResponse<List<CategoryObj>>>> GetAll()
        {
            List<CategoryObj> list = new List<CategoryObj>();
            try
            {
                list = await _categoryBAL.GetAll();
                if (list.Any())
                {
                    _logger.LogInformation("Retrieved category record total {Count}", list.Count().ToString());
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return new JsonResult(new StandardResponse<IEnumerable<CategoryObj>>(
                                    true,
                                    "200",
                                    "Retrived all categories success",
                                    list))
            {
                StatusCode = 200
            };
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<StandardResponse<CategoryObj>>> GetById(int id)
        {
            var category = new CategoryObj();
            try
            {
                category = await _categoryBAL.GetCategoryById(id);
                if (category == null) return NotFound();
                _logger.LogInformation("Record found {CategoryName}", category.Name);
            }
            catch (Exception ex)
            {
                throw;
            }
            return new JsonResult(new StandardResponse<CategoryObj>(
                true,
                "200",
                "Retrieved GetById success",
                category
                ))
            {
                StatusCode = 200,
            };
        }
        [HttpPost("create")]
        public async Task<ActionResult<StandardResponse<CategoryObj>>> AddCategory([FromBody] CategoryObj categoryObj)
        {
            var category = new CategoryObj();
            try
            {
                category = await _categoryBAL.AddCategory(categoryObj);
                _logger.LogInformation("Category created: {CategoryName}", category.Name);
                //return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                throw;
            }
            return new JsonResult(new StandardResponse<CategoryObj>(
                true,
                "200",
                "Category has been added success",
                category
                ))
            {
                StatusCode = 200
            };
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<StandardResponse<CategoryObj>>> UpdateCategory(int id, [FromBody] CategoryObj categoryObj)
        {
            var category = new CategoryObj();
            try
            {
                categoryObj.Id = id;
                category = await _categoryBAL.UpdateCategory(categoryObj);
                _logger.LogInformation("Category updated {CategoryName}", category.Name);
            }
            catch (Exception ex)
            {

                throw;
            }
            return new JsonResult(new StandardResponse<CategoryObj>(
                true,
                "200",
                "Category has been updated success",
                category
                ))
            {
                StatusCode = 200
            };
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<StandardResponse<string>>> DeleteCategory(int id)
        {
            var retVal = string.Empty;
            try
            {
                var category = await _categoryBAL.GetCategoryById(id);
                if (category == null) return NotFound();
                await _categoryBAL.DeleteCategory(id);
                _logger.LogInformation("Category deleted {CategoryName}", category.Name);
            }
            catch (Exception ex)
            {

                throw;
            }

            return new JsonResult(new StandardResponse<string>(
                    true,
                    "200",
                    "Category deleted success",
                    ""
                ))
            {
                StatusCode = 200
            };
        }

    }
}
