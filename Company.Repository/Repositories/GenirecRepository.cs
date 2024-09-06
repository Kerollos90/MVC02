using Company.Data.Context;
using Company.Data.Entity;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class GenirecRepository<T> : IGenirecRepository<T> where T : BaseEntity
    {

        private readonly CompanyDbContext _context;

        public GenirecRepository(CompanyDbContext Context)
        {
            _context = Context;
        }

        public void Add(T entity)
        
           => _context.Set<T>().Add(entity);
       

        public void Delete(T entity)
     
           => _context.Set<T>().Remove(entity);
        

        public T GetById(int? id)
        
           => _context.Set<T>().Find(id);
            
        

        public IEnumerable<T> GetAll()
        
            =>_context.Set<T>().ToList();
            
        

        public void Update(T entity)
        
           => _context.Set<T>().Update(entity);
        
    }
}
