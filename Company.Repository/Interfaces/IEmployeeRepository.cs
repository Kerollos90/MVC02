using Company.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenirecRepository<Employee>
    {
        public IEnumerable<Employee> GetEmployeeByName(string Name );
        public IEnumerable<Employee> GetEmployeeByAddress(string Address);
       

    }
}
