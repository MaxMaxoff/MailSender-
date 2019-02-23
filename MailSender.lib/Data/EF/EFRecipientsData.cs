using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.Context;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.EF
{
    public class EFRecipientsData : IData<Recipient>
    {
        private readonly MailDatabaseContext _db;

        public EFRecipientsData(MailDatabaseContext db) => _db = db;

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipients.AsEnumerable();
        }

        public async Task<IEnumerable<Recipient>> GetAllAsync()
        {
            await Task.Yield();
            return _db.Recipients.AsEnumerable();
        }

        public Recipient GetById(int id)
        {
            return _db.Recipients.FirstOrDefault(s => s.Id == id);
        }

        public Task<Recipient> GetByIdAsync(int id)
        {
            return _db.Recipients.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void AddNew(Recipient NewItem)
        {
            _db.Recipients.Add(NewItem);
        }

        public async Task AddNewAsync(Recipient NewItem)
        {
            await Task.Yield();
            _db.Recipients.Add(NewItem);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Recipients.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Yield();
            var item = await GetByIdAsync(id);
            if (item is null) return;
            _db.Recipients.Remove(item);

        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
