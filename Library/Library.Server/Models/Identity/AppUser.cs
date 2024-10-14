using Library.Server.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Server.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        /// <summary>
        /// Gets or sets first name for this user.
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Gets or sets last name for this user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets UserBookReviews for this User.
        /// </summary>
        [Display(Name = "CoverImage")]
        public List<UserBookCheckOut>? UserBookCheckOuts { get; }

        /// <summary>
        /// Gets UserBookReviewss for this User.
        /// </summary>
        [Display(Name = "UserBookReviews")]
        public List<UserBookReview>? UserBookReviews { get; }

        public AppUser()
        {
        }

        public AppUser(string userName) : base(userName)
        {
        }
    }
}