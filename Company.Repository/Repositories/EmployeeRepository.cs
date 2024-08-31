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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext Context)
        {
            _context = Context;
        }

        public void Add(Employee employee)
        =>_context.Employees.Add(employee);

        public void Delete(Employee employee)
       =>_context.Employees.Remove(employee);

        public IEnumerable<Employee> GetAll()
        => _context.Employees.ToList();

        public Employee GetById(int id)
       //=> _context.Employees.FirstOrDefault(e=>e.Id==id);
       => _context.Employees.Find(id);
        public void Update(Employee employee)
        => _context.Employees.Update(employee);
    }
}
