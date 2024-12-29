using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Domain;
using Notes.Services.Interfaces;

namespace Notes.Services
{
    public class ContactsService : IService<Contact>
    {
        public NoteContext _noteContext;

        public ContactsService(NoteContext noteContext)
        {
            _noteContext = noteContext;
        }

        public void Add(Notes.Domain.Contact adding)
        {
            if (adding is not null)
            { _noteContext.Contacts.Add(new Data.Entities.Contact { Id = adding.Id, Name = adding.Name, Surname = adding.Surname, Description = adding.Description, Email = adding.Email, Phone1 = adding.Phone1, Phone2 = adding.Phone2 }); 
            
               _noteContext.SaveChanges();
            }
           
        }

        public Notes.Domain.Contact Get(int Id)
        {
            if (Id >= 0)
            {
                return _noteContext.Contacts.Where(x => x.Id == Id).Select(x => new Notes.Domain.Contact { Id = x.Id, Name = x.Name, Surname = x.Surname, Description = x.Description, Email = x.Email, Phone1 = x.Phone1, Phone2 = x.Phone2 }).FirstOrDefault();
            }
            else { return null; }
        }

        public IEnumerable<Contact> GetAll()
        {
            return _noteContext.Contacts.Select(x => new Notes.Domain.Contact { Id = x.Id, Name = x.Name, Surname = x.Surname, Description = x.Description, Email = x.Email, Phone1 = x.Phone1, Phone2 = x.Phone2 });
        }

        public void Remove(int Id)
        {
            if (Id >= 0)
            {
                var deletingItem = _noteContext.Contacts.Where(x => x.Id == Id).FirstOrDefault();

                if (deletingItem != null)
                {
                    _noteContext.Contacts.Remove(deletingItem);
                    _noteContext.SaveChanges();
                }
                else { throw new Exception(); }
            }
            else { throw new Exception(); }
        }

        public void Update(int Id, Contact contact)
        {
            if (Id >= 0)
            {
                var changingItem = _noteContext.Contacts.Where(x => x.Id == Id).FirstOrDefault();

                if (changingItem != null)
                {
                    changingItem.Name = contact.Name;
                    changingItem.Surname = contact.Surname;
                    changingItem.Description = contact.Description;
                    changingItem.Email = contact.Email;
                    changingItem.Phone1 = contact.Phone1;
                    changingItem.Phone2 = contact.Phone2;
                    _noteContext.SaveChanges();
                }
                else { throw new Exception(); }
            }
            else { throw new Exception(); }
        }
    }
}
