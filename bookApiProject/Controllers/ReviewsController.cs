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

    }
}
