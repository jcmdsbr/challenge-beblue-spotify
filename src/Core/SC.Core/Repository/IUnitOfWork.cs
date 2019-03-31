using System;
using System.Threading.Tasks;

namespace SC.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}