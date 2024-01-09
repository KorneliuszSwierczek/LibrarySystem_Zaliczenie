using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string Author { get; set; }

        [Display(Name = "Publication Year")]
        [Range(1000, 3000, ErrorMessage = "Please enter a valid year")]
        [Column(TypeName = "int")]
        public int? PublicationYear { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }

        [Display(Name = "Categories")]
        [Column(TypeName = "nvarchar(50)")]
        [NotMapped]
        public List<string> Categories { get; set; }
    }
}
