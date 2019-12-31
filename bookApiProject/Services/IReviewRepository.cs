using bookApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Services
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        Book GetBookOfAReview(int reviewId);
        ICollection<Review> GetReviewsOfABook(int bookId);
        bool ReviewExists(int reviewId);
    }
}
