using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            await this._unitOfWork.ClienteRepository.Delete(id);
            await this._unitOfWork.SaveChangesAsync();
            return  true;
        }

        public Task<Cliente> GetCliente(int id)
        {
            return this._unitOfWork.ClienteRepository.GetById(id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return this._unitOfWork.ClienteRepository.GetAll();
        }

        public IEnumerable<Cliente> GetNombreClientes(string nombre)
        {
            return this._unitOfWork.ClienteRepository.GetByName(nombre);
        }

        public async Task PostCliente(Cliente o)
        {
            await this._unitOfWork.ClienteRepository.Add(o);
        }

        public async Task<bool> PutCliente(Cliente o)
        {
            this._unitOfWork.ClienteRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
