using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class NoteAndTag
    {
        public int NoteId { get; set; }

        public int TagId { get; set; }

        public Note Note { get; set; }

        public Tag Tag { get; set; }
    }
}
