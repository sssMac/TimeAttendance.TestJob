using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAttendance.TestJob.DAL.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(object id);
        public Task<T> InsertAsync(T model);
        public Task UpdateAsync(T model);
        public Task DeleteAsync(object id);
        public Task SaveAsync();
    }
}
