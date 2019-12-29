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
    public class BookDBContext : DbContext
    {
        // BookDbContext inherits DbContext and is used as the datatype
        // of the DbContextOptions options we are passing to the base class
        // so that the base class can have access to all the members of the 
        // BookDbContext class and help it do the magic of entity building
        // and relationship management
        public BookDBContext(DbContextOptions<BookDBContext> options):base(options)
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

        // Next is to  add model builder
        // Use it set .HasKey, .HasOne, .HasMany relationship pattern

        // **Note it must have a  'protected' class access specifier and
        // an override access modifier and void return type
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(a => a.AuthorId);
        }

        // after the above goto the start-up file and add DbContext as a service
        // then open the package manager console under tools menu => NuGet Package Manager
        // and run 'add-migration InitialDatabaseCreation' 
    }
}
