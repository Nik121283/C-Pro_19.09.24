using Notes.Data;
using Notes.Data;
using Notes.Data.Entities;
using Notes.Domain;
using Notes.Services.Interfaces;

namespace Notes.Services
{
    public class NotesService : IService<Notes.Domain.Note>
    {
        public NoteContext _noteContext;

        public NotesService(NoteContext noteContext)
        {
            _noteContext = noteContext;
        }

        public void Add(Notes.Domain.Note adding)
        {
            _noteContext.Add(new Data.Entities.Note { Title = adding.Title, Text = adding.Text, Created = adding.Created, ContactId = adding.ContactId});
        }

        public Notes.Domain.Note Get(int Id)
        {
            if (Id > 0)
            {
                return _noteContext.Notes.Where(x => x.Id == Id).Select(x => new Notes.Domain.Note { Id = x.Id, Title = x.Title, ContactId = x.ContactId, Created = x.Created }).FirstOrDefault();
            }
            else { return null; }
        }

        public IEnumerable<Notes.Domain.Note> GetAll()
        {
            return _noteContext.Notes.Select(x => new Notes.Domain.Note { Id = x.Id, Title = x.Title, ContactId = x.ContactId, Created = x.Created});
        }

        public void Remove(int Id)
        {
            if (Id >= 0)
            {
                var deletingItem = _noteContext.Notes.Where(x => x.Id == Id).FirstOrDefault();

                if (deletingItem != null)
                {
                    _noteContext.Notes.Remove(deletingItem);
                    _noteContext.SaveChanges();
                }
                else { throw new Exception(); }
            }
            else { throw new Exception(); }
        }

        public void Update(int Id, Notes.Domain.Note newItem)
        {
            if (Id >= 0)
            {
                var changingItem = _noteContext.Notes.Where(x => x.Id == Id).FirstOrDefault();

                if (changingItem != null)
                {
                    changingItem.Text = newItem.Text;
                    changingItem.Title = newItem.Title;
                    changingItem.ContactId = newItem.ContactId;
                    changingItem.Created = newItem.Created;

                    _noteContext.SaveChanges();
                }
                else { throw new Exception(); }
            }
            else { throw new Exception(); }
        }
    }
}
