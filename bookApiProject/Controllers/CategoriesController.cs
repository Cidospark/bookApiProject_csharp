using bookApiProject.Models;
using bookApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Controllers
{
    public class CategoriesController : Controller
    {
        /****************************Initial setups***********************************/
            // bring in the interface to use
            private ICategoryRepository _categoryRepository;

            // inject it into the constructor
            public CategoriesController(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
        /*****************************setup is ends****************************/

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories().ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);

        }
    }
}
