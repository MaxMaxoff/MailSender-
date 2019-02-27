using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.Context;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.EF
{
    public class EFSchedulerTasksData : IData<SchedulerTask>
    {
        private readonly MailDatabaseContext _db;

        public EFSchedulerTasksData(MailDatabaseContext db) => _db = db;

        public IEnumerable<SchedulerTask> GetAll()
        {
            return _db.SchedulerTasks.AsEnumerable();
        }

        public async Task<IEnumerable<SchedulerTask>> GetAllAsync()
        {
            await Task.Yield();
            return _db.SchedulerTasks.AsEnumerable();
        }

        public SchedulerTask GetById(int id)
        {
            return _db.SchedulerTasks.FirstOrDefault(s => s.Id == id);
        }

        public Task<SchedulerTask> GetByIdAsync(int id)
        {
            return _db.SchedulerTasks.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void AddNew(SchedulerTask NewItem)
        {
            _db.SchedulerTasks.Add(NewItem);
        }

        public async Task AddNewAsync(SchedulerTask NewItem)
        {
            await Task.Yield();
            _db.SchedulerTasks.Add(NewItem);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.SchedulerTasks.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Yield();
            var item = await GetByIdAsync(id);
            if (item is null) return;
            _db.SchedulerTasks.Remove(item);

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
