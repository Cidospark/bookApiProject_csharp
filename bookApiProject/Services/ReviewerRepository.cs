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
            // get the reviewer Id with the code below cause its not given
            var reviewerId =  _reviewerContext.Reviews.Where(r => r.Id == reviewId)
                .Select(rr => rr.Reviewer.Id).FirstOrDefault();
            // _reviewerContext.Reviews.Where(r => r.Id == reviewId) in this code r.Id is the id of reviews
            // .Select(rr => rr.Reviewer.Id) in this code rr.Reviewer.Id is how you switch to get the id of the reviewer
            // cause the code will pass r.Id into the pipeline by default unless we do thr switch

            return _reviewerContext.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();
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

            // we could'nt use the .reviewer.where() method because the 
            // dbcontext of reviewer [i.e reviewer table] does not have reference to reviews data
            // the table that has reference to both reviews and reviewers is the 
            // reviews table
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
