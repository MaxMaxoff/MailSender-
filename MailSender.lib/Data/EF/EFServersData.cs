using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.Context;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.EF
{
    public class EFServersData : IData<Server>
    {
        private readonly MailDatabaseContext _db;

        public EFServersData(MailDatabaseContext db) => _db = db;

        public IEnumerable<Server> GetAll()
        {
            return _db.Servers.AsEnumerable();
        }

        public async Task<IEnumerable<Server>> GetAllAsync()
        {
            await Task.Yield();
            return _db.Servers.AsEnumerable();
        }

        public Server GetById(int id)
        {
            return _db.Servers.FirstOrDefault(s => s.Id == id);
        }

        public Task<Server> GetByIdAsync(int id)
        {
            return _db.Servers.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void AddNew(Server NewItem)
        {
            _db.Servers.Add(NewItem);
        }

        public async Task AddNewAsync(Server NewItem)
        {
            await Task.Yield();
            _db.Servers.Add(NewItem);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Servers.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Yield();
            var item = await GetByIdAsync(id);
            if (item is null) return;
            _db.Servers.Remove(item);

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
