using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.Context;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.EF
{
    public class EFSendersData : IData<Sender>
    {
        private readonly MailDatabaseContext _db;

        public EFSendersData(MailDatabaseContext db) => _db = db;

        public IEnumerable<Sender> GetAll()
        {
            return _db.Senders.AsEnumerable();
        }

        public async Task<IEnumerable<Sender>> GetAllAsync()
        {
            await Task.Yield();
            return _db.Senders.AsEnumerable();
        }

        public Sender GetById(int id)
        {
            return _db.Senders.FirstOrDefault(s => s.Id == id);
        }

        public Task<Sender> GetByIdAsync(int id)
        {
            return _db.Senders.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void AddNew(Sender NewItem)
        {
            _db.Senders.Add(NewItem);
        }

        public async Task AddNewAsync(Sender NewItem)
        {
            await Task.Yield();
            _db.Senders.Add(NewItem);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Senders.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Yield();
            var item = await GetByIdAsync(id);
            if (item is null) return;
            _db.Senders.Remove(item);

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
