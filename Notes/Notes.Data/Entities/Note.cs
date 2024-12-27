using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Data.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        
        public string Text { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        public virtual IEnumerable<NoteAndTag> Tags { get; set; }
    }
}
