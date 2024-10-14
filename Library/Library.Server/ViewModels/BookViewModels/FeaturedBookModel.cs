using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Server.ViewModels.BookViewModels
{
    public class FeaturedBookModel
    {
        /// <summary>
        /// Gets or sets Id for Entity.
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

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
        /// Gets or sets Cover Image for this book.
        /// </summary>
        [Display(Name = "Cover Image")]
        public string? CoverImagePath { get; set; }

        /// <summary>
        /// Gets or sets AverageRate for this book.
        /// </summary>
        [Display(Name = "Average Rate")]
        public int AverageRate { get; set; }

        /// <summary>
        /// Gets or sets Availability for this book.
        /// </summary>
        [Display(Name = "Availability")]
        public bool Availability { get; set; }
    }
}
