using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDocument.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AppDbContext _context { get; }

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity item)
        {            
            _context.Set<TEntity>().Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Add(IEnumerable<TEntity> items)
        {
            _context.Set<TEntity>().AddRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var obj = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Attach(obj);
            _context.Entry(obj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }   

        public async Task<TEntity> Get(Guid id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var obj = await _context.Set<TEntity>().ToListAsync();
            return obj;
        }

        public async Task<bool> Exist(Guid id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj != null)
                _context.Entry(obj).State = EntityState.Detached;
            return (obj != null);
        }
    }
}
