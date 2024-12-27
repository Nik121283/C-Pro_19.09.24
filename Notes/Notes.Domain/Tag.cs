﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public virtual IEnumerable<NoteAndTag> NotesAndTags { get; set; }
    }
}
