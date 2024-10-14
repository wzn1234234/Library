using Azure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Server.Models.Entity
{
    public class Book : BaseEntity
    {        
        /// <summary>
        /// Gets or sets Title for this book.
        /// </summary>
        [Display(Name = "Title")]
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets Author for this book.
        /// </summary>
        [Display(Name = "Author")]
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets Description for this book.
        /// </summary>
        [Display(Name = "Description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets Cover Image Path for this book.
        /// </summary>
        [Display(Name = "Cover Image Path")]
        public string? CoverImagePath { get; set; }

        /// <summary>
        /// Gets or sets Publisher for this book.
        /// </summary>
        [Display(Name = "Publisher")]
        public string? Publisher { get; set; }

        /// <summary>
        /// Gets or sets  Publication Date for this book.
        /// </summary>
        [Display(Name = " Publication Date")]
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets Category for this book.
        /// </summary>
        [Display(Name = "Category")]
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets ISBN for this book.
        /// </summary>
        [Display(Name = "ISBN")]
        public string? ISBN { get; set; }

        /// <summary>
        /// Gets or sets Page Count for this book.
        /// </summary>
        [Display(Name = "Page Count")]
        public int? PageCount { get; set; }

        /// <summary>
        /// Gets UserBookReviews for this book.
        /// </summary>
        [Display(Name = "UserBookCheckOuts")]
        public List<UserBookCheckOut>? UserBookCheckOuts { get; }

        /// <summary>
        /// Gets UserBookReviewss for this book.
        /// </summary>
        [Display(Name = "UserBookReviews")]
        public List<UserBookReview>? UserBookReviews { get; }
    }
}
