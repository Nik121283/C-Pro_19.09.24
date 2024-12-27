using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Entities
{
    [PrimaryKey(nameof(NoteId), nameof(TagId))]
    public class NoteAndTag
    {
        public int NoteId { get; set; }

        public int TagId { get; set; }

        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
