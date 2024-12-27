using Microsoft.EntityFrameworkCore;
using Notes.Data.Entities;

namespace Notes.Data
{
    public class NoteContext :DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }


        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteAndTag> NotesAndTags { get; set;}

        public DbSet<Tag> Tags { get; set; }

    }
}
