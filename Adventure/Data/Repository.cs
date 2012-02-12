using System;
using System.Linq;

namespace Adventure.Data
{
    public class Repository : IRepository
    {
        private IUnitOfWork uow;

        public Repository(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IQueryable<T> AsQueryable<T>() where T : class
        {
            return UnitOfWork.Context.Set<T>();
        }

        public T Add<T>(T obj) where T : class
        {
            return UnitOfWork.Context.Set<T>().Add(obj);
        }

        public void Delete<T>(T obj) where T : class
        {
            UnitOfWork.Context.Set<T>().Remove(obj);
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return uow;
            }
        }
    }
}
