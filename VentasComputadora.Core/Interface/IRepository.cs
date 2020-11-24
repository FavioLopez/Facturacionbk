using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.Core.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int Id);
        IEnumerable<T> GetByName(string Name);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int Id);
    }
}
