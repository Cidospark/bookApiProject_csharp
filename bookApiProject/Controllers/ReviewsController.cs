using bookApiProject.Dtos;
using bookApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // api/reviews
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();

            if (!ModelState.IsValid)
                return BadRequest();

            var reviewsDto = new List<ReviewDto>();
            foreach (var review in reviews)
            {
                reviewsDto.Add(new ReviewDto()
                {
                    Id= review.Id,
                    HeadLine = review.HeadLine,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                });
            }

            return Ok(reviewsDto);
        }



        // api/reviews/reviewId
        [HttpGet("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
                return NotFound();

            var review = _reviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid)
                return BadRequest();

            var reviewDto = new ReviewDto()
            {
                Id = review.Id,
                HeadLine = review.HeadLine,
                ReviewText = review.ReviewText,
                Rating = review.Rating
            };

            return Ok(reviewDto);
        }


        //api/reviews/bookId/reviews
        [HttpGet("{bookId}/reviews")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReviewsOfABook(int bookId)
        {
            // validate book

            var reviews = _reviewRepository.GetReviewsOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewsDto = new List<ReviewDto>();
            foreach(var review in reviews)
            {
                reviewsDto.Add(new ReviewDto()
                {
                    Id = review.Id,
                    HeadLine = review.HeadLine,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                });
            }

            return Ok(reviewsDto);
        }


        //api/reviews/reviewId/book
        [HttpGet("{reviewId}/book")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBookOfAReview(int reviewId)
        {
            // validate book

            var book = _reviewRepository.GetBookOfAReview(reviewId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookDto = new BookDto()
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                DatePublished = book.DatePublished
            };

            return Ok(bookDto);
        }


    }
}
