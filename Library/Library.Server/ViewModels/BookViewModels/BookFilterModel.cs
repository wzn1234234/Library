using System.ComponentModel.DataAnnotations;

namespace Library.Server.ViewModels.BookViewModels
{
    public class BookFilterModel
    {
        public string? SortData { get; set; }

        public bool Random { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public int Availability { get; set; }
    }
}
