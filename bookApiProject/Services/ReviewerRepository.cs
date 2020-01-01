using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApiProject.Models;

namespace bookApiProject.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        BookDBContext _reviewerContext;

        public ReviewerRepository(BookDBContext reviewerContext)
        {
            _reviewerContext = reviewerContext;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _reviewerContext.Reviewers.Where( r => r.Id == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            return _reviewerContext.Reviews.Where(r => r.Id == reviewId)
                .Select(rr => rr.Reviewer).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerContext.Reviewers.OrderBy(r => r.LastName).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
            // because it is a review dataset and we want to match a test against a reviewerid
            // we had to do this 'r.Reviewer.Id == reviewerId' in the code above
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
