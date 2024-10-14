using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Server.Models.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets Id for Entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets  Created Date for this book.
        /// </summary>
        [Display(Name = " Created Date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets  Created By for this book.
        /// </summary>
        [Display(Name = " Created By")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets  Updated Date for this book.
        /// </summary>
        [Display(Name = " Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets  Updated Date for this book.
        /// </summary>
        [Display(Name = " Updated By")]
        public string? UpdatedBy { get; set; }
    }
}
