using Library.Server.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Server.Models.Entity
{
    public class UserBookReview : BaseEntity
    {
        /// <summary>
        /// Gets or sets User Id for UserBook.
        /// </summary>
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Book Id for UserBook.
        /// </summary>
        [Display(Name = "Book Id")]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets Review for UserBook.
        /// </summary>
        [Display(Name = "Review")]
        public string? Review { get; set; }


        /// <summary>
        /// Gets or sets Rate for UserBook.
        /// </summary>
        [Display(Name = "Rate")]
        [Range(1, 5, ErrorMessage = "The field {0} must be greater than {1} and less than {2}.")]
        public int? Rate { get; set; }

        /// <summary>
        /// Gets or sets User Object for this UserBook.
        /// </summary>
        public AppUser User { get; set; }

        /// <summary>
        /// Gets or sets Book Object for this UserBook.
        /// </summary>
        public Book Book { get; set; }
    }
}
