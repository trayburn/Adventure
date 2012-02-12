using System;

namespace Adventure.Data
{
    public interface IRepositoryFactoryFactory : IDisposable
    {
        IRepositoryFactory Create();
    }
}
