using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data
{
    public class BancaRepository : IBancaRepository 
    {
        private readonly StoreContext _context;

        public BancaRepository(StoreContext context){
            _context = context;
        }

        public async Task<IReadOnlyList<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.Include(u=>u.Cuentas).ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.Where(u=>u.Id == id).Include(u=>u.Cuentas).FirstOrDefaultAsync();
        }
        
    }
}
