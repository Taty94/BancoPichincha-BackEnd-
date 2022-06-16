using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly StoreContext _context;
        

        public CuentaRepository(StoreContext context){
            _context = context;
        }

        public async Task<IReadOnlyList<Cuenta>> GetCuentasAsync()
        {
            return await _context.Cuentas.Include(c=>c.Usuario).ToListAsync();
        }

        public async Task<Cuenta> GetCuentaByIdAsync(int id)
        {
            return await _context.Cuentas.Where(c=>c.Id == id).Include(c=>c.Usuario).FirstOrDefaultAsync();
        }

        public async Task<Cuenta> CreateUpdateCuenta(Cuenta cuenta)
        {
            if(cuenta.Id > 0)
            {
                _context.Cuentas.Update(cuenta);

            }else
            {
                await _context.Cuentas.AddAsync(cuenta);
            }
            
            await _context.SaveChangesAsync();
            return cuenta;            
        }

        public async Task<bool> DeleteCuenta(int id)
        {
            try
            {
                Cuenta cuenta = await _context.Cuentas.FindAsync(id);
                if(cuenta ==null){
                    return false;
                }
                _context.Cuentas.Remove(cuenta);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> Deposit(int id, decimal amount_deposit)
        {
            try {
                var cuenta = await _context.Cuentas.FindAsync(id);
                if(cuenta!=null){
                    cuenta.Saldo = cuenta.Saldo + amount_deposit;
                    _context.Cuentas.Update(cuenta);
                    await _context.SaveChangesAsync();
                    return true;
                }else return false;
                
            }
            catch (Exception ){
                return false;
            }
            
        }
        public async Task<bool> Removal(int id, decimal amount_removal)
        {
            try {
                var cuenta = await _context.Cuentas.FindAsync(id);
                if(cuenta!=null){
                    if(amount_removal <= cuenta.Saldo){
                        cuenta.Saldo = cuenta.Saldo - amount_removal;
                        _context.Cuentas.Update(cuenta);
                    }
                    await _context.SaveChangesAsync();
                    return true;
                }else return false;
            }
            catch (Exception ){
                return false;
            }
        }

        
    }
}