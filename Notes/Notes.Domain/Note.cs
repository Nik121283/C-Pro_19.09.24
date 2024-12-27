namespace Notes.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public virtual IEnumerable<NoteAndTag> Tags { get; set; }
    }
}
