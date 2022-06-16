using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICuentaRepository
    {
        Task<IReadOnlyList<Cuenta>> GetCuentasAsync();
        Task<Cuenta> GetCuentaByIdAsync(int id);

        Task<bool> Deposit(int id, decimal amount_deposit);
        Task<bool> Removal(int id, decimal amount_removal);
    }
}