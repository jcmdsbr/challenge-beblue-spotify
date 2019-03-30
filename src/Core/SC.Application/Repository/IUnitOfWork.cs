using System;
using System.Threading.Tasks;

namespace SC.Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}