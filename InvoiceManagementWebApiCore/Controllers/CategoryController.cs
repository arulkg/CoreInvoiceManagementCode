using InvoiceManagementWebApiCore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceManagementWebApiCore.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMG_CoreContext _context;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMG_CoreContext context, ILogger<CategoryController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            if (categories.Any())
            {
                _logger.LogInformation("Retrieved category record total {Count}", categories.Count().ToString());
            }
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            _logger.LogInformation("Record found {CategoryName}", category.Name);
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        { 
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Category created: {CategoryName}", category.Name);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            _context.Categories.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _logger.LogInformation("Category updated {CategoryName}", category.Name);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            _context.Remove(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Category deleted {CategoryName}",category.Name);
            return NoContent();
        
        }
    }
   
}
