using System;
using System.Data.Entity;

namespace Adventure.Data
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        void SaveChanges();
    }
}
