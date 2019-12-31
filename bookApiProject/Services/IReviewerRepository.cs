using bookApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Services
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewers(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        ICollection<Reviewer> GetReviewerOfAReview(int reviewId);
        bool ReviewerExists(int reviewerId);
    }
}
