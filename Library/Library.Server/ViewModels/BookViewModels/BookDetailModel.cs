using Library.Server.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace Library.Server.ViewModels.BookViewModels
{
    public class BookDetailModel : FeaturedBookModel
    {
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
        /// Gets or sets Cover Image for this book.
        /// </summary>
        [Display(Name = "Cover Image")]
        public FileStream? CoverImage { get; set; }

        /// <summary>
        /// Gets UserBookReviewss for this book.
        /// </summary>
        [Display(Name = "UserBookReviews")]
        public List<BookReviewDetailModel>? UserBookReviews { get; set; }
    }
}
