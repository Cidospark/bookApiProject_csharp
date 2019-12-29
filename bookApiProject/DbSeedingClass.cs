using bookApiProject.Models;
using bookApiProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject
{
    public static class DbSeedingClass
    {
        // this use of 'this' keyword on the parameter type indicates
        // it is an extension method to be called and passed the context to it
        public static void SeedDataContext(this BookDBContext context)
        {
            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "123",
                        Title = "Call of Duty",
                        DatePublished = new DateTime(2019,12,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory{
                                Category = new Category() {
                                    Name = "Action"
                                }
                            },
                            new BookCategory{
                                Category = new Category() {
                                    Name = "Adventure"
                                }
                            }
                        },
                        Reviews = new List<Review>()
                        {
                            new Review {HeadLine = "Awesome", ReviewText = "Call of Duty is an amazing book",
                                Rating = 5,
                                Reviewer = new Reviewer()
                                {
                                    FirstName = "Cidos", LastName = "Spark"
                                }
                            },
                            new Review {HeadLine = "Nice!", ReviewText = "Its a good work",
                                Rating = 4,
                                Reviewer = new Reviewer()
                                {
                                    FirstName = "John", LastName = "Doe"
                                }
                            }
                        }
                    },

                    Author = new Author()
                    {
                        FirstName = "Francis",
                        LastName = "Ibe",
                        Country = new Country()
                        {
                            Name = "Nigeria"
                        }
                    }
                },

                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "2345",
                        Title = "Chike and the river",
                        DatePublished = new DateTime(2018,6,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory{Category= new Category(){Name = "Educational"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review {HeadLine = "Beautiful Work", ReviewText = "Chike and the river is a very edcative book",
                                Rating = 5,
                                Reviewer = new Reviewer()
                                {
                                    FirstName = "Cidos", LastName = "Spark"
                                }
                            }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Chinu",
                        LastName = "Achebe",
                        Country = new Country()
                        {
                            Name = "Nigeria"
                        }
                    }
                }
            };
            context.BookAuthors.AddRange(booksAuthors);
            context.SaveChanges();
        }
    }
}
