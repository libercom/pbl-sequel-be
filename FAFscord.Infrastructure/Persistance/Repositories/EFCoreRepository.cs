using FAFscord.Application.Common.Interfaces.Repositories;
using FAFscord.Domain;
using FAFscord.Infrastructure.Persistance.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Infrastructure.Persistance.Repositories
{
    public class EFCoreRepository : IRepository
    {
        private readonly FAFscordDbContext _context;

        public EFCoreRepository(FAFscordDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Read<T>() where T : BaseEntity
        {
            return _context.Set<T>();
        }

        public async Task<List<T>> GetAll<T>(List<string> includes) where T : BaseEntity
        {
            var query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById<T>(Guid id, List<string> includes) where T : BaseEntity
        {
            var query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetById<T>(Expression<Func<T, bool>> predicate, List<string> includes) where T : BaseEntity
        {
            var query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> Create<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);

            await Save();

            return entity;
        }

        public async Task<T> Delete<T>(Guid id) where T : BaseEntity
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);

                await Save();
            
                return entity;
            }

            return null;
        }

        public async Task<T> Update<T>(Guid id, Action<T> action) where T : BaseEntity
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity != null)
            {
                action(entity);

                await Save();

                return entity;
            }

            return null;
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
