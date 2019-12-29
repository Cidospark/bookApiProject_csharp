using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage ="Headlines must be between 10 and 200 characters", MinimumLength =10)]
        public string HeadLine { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Review must be between 50 and 2000 characters", MinimumLength = 50)]
        public string ReviewText { get; set; }
        
        [Required]
        [Range(1, 5, ErrorMessage ="Rating must be between 1 and 5 stars")]
        public int Rating { get; set; }

        public Reviewer Reviewer { get; set; }

        public Book Book { get; set; }
    }
}
