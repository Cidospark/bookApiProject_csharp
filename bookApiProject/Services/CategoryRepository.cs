using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApiProject.Models;

namespace bookApiProject.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        // after implementing the category interface here , next is to
        // get the data from the database using the BookDbContext class
        // to get that, we need to do dependency injection

        private BookDBContext _categoryContext;

        /**************************************//* dependency injection *//**************************/
        public CategoryRepository(BookDBContext categoryContext) 
        {
            _categoryContext = categoryContext;
        }
        /*****************************************************************************/

        public bool CategoryExists(int categoryId)
        {
            return _categoryContext.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Book> GetAllBooksOfACategory(int categoryId)
        {
            return _categoryContext.BookCategories.Where(c => c.CategoryId == categoryId)
                .Select(b => b.Book).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Category> GetAllCategoriesOfABook(int bookId)
        {
            return _categoryContext.BookCategories.Where(b => b.BookId == bookId)
                .Select(c => c.Category).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }
    }
}
