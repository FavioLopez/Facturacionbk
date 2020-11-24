using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.Core.Interface
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetClientes();

        Task<Cliente> GetCliente(int id);

        IEnumerable<Cliente> GetNombreClientes(string nombre);

        Task PostCliente(Cliente o);

        Task<bool> PutCliente(Cliente o);

        Task<bool> DeleteCliente(int id);
    }
}
