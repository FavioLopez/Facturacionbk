using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;
using VentasComputadora.Infrastructure.Data;

namespace VentasComputadora.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //private readonly VentaComputadorasContext _context;
        private DbSet<T> _entities;

        public BaseRepository(VentaComputadorasContext context) 
        {            
            this._entities = context.Set<T>();
        }                

        public IEnumerable<T> GetAll()
        {
            return this._entities.AsEnumerable();
        }

        public async Task<T> GetById(int Id)
        {
            return await this._entities.FindAsync(Id);
        }

        public IEnumerable<T> GetByName(string Name)
        {
            throw new NotImplementedException();
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);         
        }

        public void Update(T entity)
        {
            _entities.Update(entity);            
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            _entities.Remove(entity);
        }
    }
}
