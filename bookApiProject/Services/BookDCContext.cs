using bookApiProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Services
{
    // DbContext class helps us keep track of our eneity relationships
    // it is an in-built class so we need to inherit it, so we can make 
    // use of its methods and properties
    // also, the parent class "DbContext" has an 'options' parameter
    // to its constructor so we have to pass an options parameter to 
    // the the base class here.
    public class BookDCContext : DbContext
    {
        public BookDCContext(DbContextOptions<DbContext> options):base(options)
        { 
            // this is how you define the pattern of operation
            // you wish to carryout with this class
            Database.Migrate();
        }

        // DbSets inessence creates the tables from the properties
        // of your model classes
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
    }
}
