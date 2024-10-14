using System.ComponentModel.DataAnnotations;

namespace Library.Server.ViewModels.BookViewModels
{
    public class BookReviewModel
    {
        /// <summary>
        /// Gets or sets Book Id for UserBook.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets Review for UserBook.
        /// </summary>
        public string? Review { get; set; }


        /// <summary>
        /// Gets or sets Rate for UserBook.
        /// </summary>
        public int? Rate { get; set; }
    }
}
