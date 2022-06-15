using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> CreateUpdateAsync(T entityObject);
        Task<bool> DeteleAsync(int id);
    }
}