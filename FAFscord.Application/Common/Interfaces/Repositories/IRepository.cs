using FAFscord.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Common.Interfaces.Repositories
{
    public interface IRepository
    {
        IQueryable<T> Read<T>() where T : BaseEntity;
        Task<T> GetById<T>(Guid id, List<string> includes) where T : BaseEntity;
        Task<T> GetById<T>(Expression<Func<T, bool>> predicate, List<string> includes) where T : BaseEntity;
        Task<List<T>> GetAll<T>(List<string> includes) where T : BaseEntity;
        Task<T> Create<T>(T entity) where T : BaseEntity;
        Task<T> Update<T>(Guid id, Action<T> action) where T : BaseEntity;
        Task<T> Delete<T>(Guid id) where T : BaseEntity;
    }
}
