using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBancaRepository
    {
        //Task<IReadOnlyList<Usuario>> GetUsuariosAsync();
        //Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CreateUpdateUsuario(Usuario Usuario);
        Task<bool> DeleteUsuario(int id);

        //Cuenta
        //Task<IReadOnlyList<Cuenta>> GetCuentasAsync();
        Task<bool> Deposito(int id, decimal deposito);
        Task<bool> Retiro(int id, decimal retiro);
    }
}