using Notes.Data;
using Notes.Domain;
using Notes.Services.Interfaces;

namespace Notes.Services
{
    public class TagsService : IService<Notes.Domain.Tag>
    {
        public NoteContext _noteContext;
        public TagsService(NoteContext noteContext)
        {
            _noteContext = noteContext;
        }

        public void Add(Tag addingItem)
        {
            _noteContext.Tags.Add(new Data.Entities.Tag { TagName = addingItem.TagName });
        }

        public Tag Get(int Id)
        {
            var result = _noteContext.Tags.Where(x => x.TagId == Id).Select(x => new Notes.Domain.Tag { TagId = x.TagId, TagName = x.TagName }).FirstOrDefault();

            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }

        public IEnumerable<Tag> GetAll()
        {
            var result = _noteContext.Tags.Select(x => new Notes.Domain.Tag { TagId = x.TagId, TagName = x.TagName });

            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }

        public void Remove(int Id)
        {
            if (Id >= 0)
            {
                var deletingItem = _noteContext.Tags.Where(x => x.TagId == Id).FirstOrDefault();

                if (deletingItem != null)
                {
                    _noteContext.Tags.Remove(deletingItem);
                }
                else { throw new Exception(); }
            }

            else { throw new Exception(); }
        }

        public void Update(int Id, Tag newItem)
        {
            if (Id >= 0)
            {
                var changingItem = _noteContext.Tags.Where(x => x.TagId == Id).FirstOrDefault();

                if (changingItem != null)
                {
                    changingItem.TagId = newItem.TagId;
                    changingItem.TagName = newItem.TagName;
                    _noteContext.SaveChanges();
                }
                else { throw new Exception(); }
            }
            else { throw new Exception(); }
        }
    }
}