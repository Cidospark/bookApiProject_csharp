using bookApiProject.Dtos;
using bookApiProject.Models;
using bookApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        /****************************Initial setups***********************************/
            // bring in the interface to use
            private ICategoryRepository _categoryRepository;
            private IBookRepository _bookRepository;

        // inject it into the constructor
        public CategoriesController(ICategoryRepository categoryRepository, IBookRepository bookRepository)
            {
                _categoryRepository = categoryRepository;
                _bookRepository = bookRepository;
            }
        /*****************************setup is ends****************************/

        //api/Categories/
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories().ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriesDto = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            
            return Ok(categoriesDto);

            // now add this to the services method in the startup
        }

        //api/Categories/categoryid
        [HttpGet("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCategory(int categoryId)
        {
            // check if particular category exists
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            // get the particular category for dataset
            var category = _categoryRepository.GetCategory(categoryId);

            // check if the above line ran successfully by checking the 
            // state of the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an empty list of categoriesDto to be added list of 
            // categories in the dtp format
            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);

            // now add this to the services method in the startup
        }


        //api/Categories/books/bookid
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetAllCategoriesOfABook(int bookId)
        {
            // check if book exists
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            // get result
            var categories = _categoryRepository.GetAllCategoriesOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest();

            if (categories.Count == 0)
                return BadRequest("No record found, Id out of range");

            var categoriesDto = new List<CategoryDto>();
            foreach(var category in categories)
            {
                categoriesDto.Add(new CategoryDto { Id = category.Id, Name = category.Name });
            }

            return Ok(categoriesDto);
        }
    }
}
