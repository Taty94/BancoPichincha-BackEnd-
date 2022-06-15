using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using System;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> CreateUpdateAsync(T entityObject)
        {
            if(entityObject.Id>0){
                _context.Set<T>().Update(entityObject);
            }else
            {
                await _context.Set<T>().AddAsync(entityObject);
            }

            await _context.SaveChangesAsync();
            return entityObject;
        }

        public async Task<bool> DeteleAsync(int id)
        {
            try
            {
               T entityObject = await _context.Set<T>().FindAsync(id);
               if(entityObject ==null)
               {
                    return false;
                }
                _context.Set<T>().Remove(entityObject);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}