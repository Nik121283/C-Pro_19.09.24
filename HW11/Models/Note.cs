using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW11.Models
{
    public class Note
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string NotesText { get; set; }

        [Column(TypeName = "Date")]
        public DateOnly NoteDateOnly { get; set; }
    }
}
