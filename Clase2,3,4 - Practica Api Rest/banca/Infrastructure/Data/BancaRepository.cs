using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        
        public async Task<Usuario> CreateUpdateUsuario(Usuario usuario)
        {
            try{
                if(usuario.Id > 0){
                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync();
                }else{
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                    if(usuario.Id > 0){
                        Cuenta cuenta =  new Cuenta();
                        var random = new Random();
                        cuenta.NumCuenta = "172179"+ random.Next(0,99999).ToString();
                        cuenta.Tipo = usuario.TipoCuenta;
                        cuenta.UsuarioId = usuario.Id;
                        await _context.Cuentas.AddAsync(cuenta);

                        await _context.SaveChangesAsync();
                    }              
                }
                return usuario;
            }
            catch(Exception){
                Usuario emptyUser = new Usuario();
                return emptyUser;
            }
            
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if(usuario ==null){
                    return false;
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        //CUENTAS
        public async Task<IReadOnlyList<Cuenta>> GetCuentasAsync()
        {
            var cuentas= await _context.Cuentas.ToListAsync();
            foreach(var item in cuentas){
                await _context.Cuentas
                    .Include(u=>u.Usuario)
                    .FirstOrDefaultAsync(u=>u.Id == item.Id);
            }
            return cuentas;
        }

        public async Task<bool> Deposito(int id, decimal deposito)
        {
            try {
                var cuenta = await _context.Cuentas.FindAsync(id);
                if(cuenta!=null){
                    cuenta.Saldo = cuenta.Saldo + deposito;
                    _context.Cuentas.Update(cuenta);
                }
                
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception){
                return false;
            }
            
        }

        public async Task<bool> Retiro(int id, decimal retiro)
        {
            try {
                var cuenta = await _context.Cuentas.FindAsync(id);
                if(cuenta!=null){
                    if(retiro <= cuenta.Saldo){
                        cuenta.Saldo = cuenta.Saldo - retiro;
                        _context.Cuentas.Update(cuenta);
                    }
                }
            
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception){
                return false;
            }
        }
    }
}