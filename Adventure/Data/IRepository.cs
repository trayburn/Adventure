using System;
using System.Linq;

namespace Adventure.Data
{
    public interface IRepository
    {
        IQueryable<T> AsQueryable<T>() where T : class;
        T Add<T>(T obj) where T : class;
        void Delete<T>(T obj) where T : class;
        IUnitOfWork UnitOfWork { get; }
    }
}
