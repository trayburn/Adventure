using System;
using System.Data.Entity;

namespace Adventure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbContext Context
        {
            get { return dbContext; }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
