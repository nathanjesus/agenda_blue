using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        protected AppDbContext _entities;
        public GenericRepository(AppDbContext entities) => _entities = entities;
        public void Add(T entity)
        {
             _entities.Set<T>().AddAsync(entity);  
             Save();
        }
        public void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            Save();
        }
        public void Update(T entity)
        {
            _entities.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            _entities.Set<T>().Update(entity);
            Save();   
        }
        public  IEnumerable<T> GetAll() => _entities.Set<T>().AsNoTracking().AsEnumerable();
        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().FirstOrDefault(predicate);
        }
        public void Save() => _entities.SaveChanges();
        #region Disposed
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {

                if (_entities != null)
                {
                    handle.Dispose();
                    _entities.Dispose();
                    _entities = null;
                }
            }

            disposed = true;
        }
        #endregion
    }
}
