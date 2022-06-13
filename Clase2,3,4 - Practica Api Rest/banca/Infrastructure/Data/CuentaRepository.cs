using System;
using System.Collections.Generic;
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
            var cuentas= await _context.Cuentas.Include(u=>u.Usuario).ToListAsync();
            return cuentas;
        }

        // public async Task<Cuenta> GetCuentaByIdAsync(int id)
        // {
        //     return await _context.Cuentas.FindAsync(id);
        // }

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

        // public async Task<bool> Deposito(int id, decimal deposito)
        // {
        //     try {
        //         var cuenta = await _context.Cuentas.FindAsync(id);
        //         if(cuenta!=null){
        //             cuenta.Saldo = cuenta.Saldo + deposito;
        //             _context.Cuentas.Update(cuenta);
        //         }
        //         await _context.SaveChangesAsync();
        //         return true;
        //     }
        //     catch (Exception ){
        //         return false;
        //     }
            
        // }
        // public async Task<bool> Retiro(int id, decimal retiro)
        // {
        //     try {
        //         var cuenta = await _context.Cuentas.FindAsync(id);
        //         if(cuenta!=null){
        //             if(retiro <= cuenta.Saldo){
        //                 cuenta.Saldo = cuenta.Saldo - retiro;
        //                 _context.Cuentas.Update(cuenta);
        //             }
        //         }
            
        //         await _context.SaveChangesAsync();
        //         return true;
        //     }
        //     catch (Exception ){
        //         return false;
        //     }
        // }
    }
}