using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.Server.Models.Identity;

namespace Library.Server.Models.Entity
{
    public class UserBookCheckOut : BaseEntity
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
        /// Gets or sets Check Out Date for UserBook.
        /// </summary>
        [Display(Name = "Check Out Date")]
        public DateTime? CheckOutDate { get; set; }

        /// <summary>
        /// Gets or sets Is Returned for UserBook.
        /// </summary>
        [Display(Name = "Is Returned")]
        public bool IsReturned { get; set; }

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
