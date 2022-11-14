using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Data;
using TimeAttendance.TestJob.DAL.Interfaces;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class , IDBModel
    {
        private readonly ApplicationContext _db;
        private DbSet<T> table;
        public Repository( ApplicationContext db )
        {
            _db = db;
            table = _db.Set<T>();
        }
        public async Task<T> InsertAsync(T model)
        {
            try
            {
                if (model != null)
                {
                    var obj = table.Add(model);
                    await _db.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAsync(object id)
        {
            try
            {
                if (id != null)
                {
                    
                    T existing = await table.FindAsync(id);
                    table.Remove(existing);
                    await _db.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> GetByIdAsync(object id)
        {
            try
            {
                if (id != null)
                {
                    var obj = await table.FindAsync(id);
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateAsync(T model)
        {
            try
            {
                if (model != null)
                {
                    table.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
