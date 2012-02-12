using System;

namespace Adventure.Data
{
    public interface IRepositoryFactory : IDisposable
    {
        IRepository Create();
    }
}
