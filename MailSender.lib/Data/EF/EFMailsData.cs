using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.Context;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.EF
{
    public class EFMailsData : IData<Mail>
    {
        private readonly MailDatabaseContext _db;

        public EFMailsData(MailDatabaseContext db) => _db = db;

        public IEnumerable<Mail> GetAll()
        {
            return _db.Mails.AsEnumerable();
        }

        public async Task<IEnumerable<Mail>> GetAllAsync()
        {
            await Task.Yield();
            return _db.Mails.AsEnumerable();
        }

        public Mail GetById(int id)
        {
            return _db.Mails.FirstOrDefault(s => s.Id == id);
        }

        public Task<Mail> GetByIdAsync(int id)
        {
            return _db.Mails.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void AddNew(Mail NewItem)
        {
            _db.Mails.Add(NewItem);
        }

        public async Task AddNewAsync(Mail NewItem)
        {
            await Task.Yield();
            _db.Mails.Add(NewItem);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Mails.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Yield();
            var item = await GetByIdAsync(id);
            if (item is null) return;
            _db.Mails.Remove(item);

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
