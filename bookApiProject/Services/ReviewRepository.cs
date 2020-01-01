using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApiProject.Models;

namespace bookApiProject.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private BookDBContext _reviewContext;
        public ReviewRepository(BookDBContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public Book GetBookOfAReview(int reviewId)
        {
            //get book id first
            var bookId = _reviewContext.Reviews.Where(r => r.Id == reviewId)
                .Select(b => b.Book.Id).FirstOrDefault();
            // to actually get the book id it has to be  'b.Book.Id'
            // because 'b.Id' will return the review Id gotten in the where clause
            // use the bookId to get book
            return _reviewContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return _reviewContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _reviewContext.Reviews.OrderBy(r => r.Rating).ToList();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            // getting the bookid that matches inside the review dataset
            return _reviewContext.Reviews.Where(b => b.Book.Id == bookId).ToList();

        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewContext.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
