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
    public class EmployeeRepository :GenirecRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext Context):base(Context)
        {
            _context = Context;
        }

      
    }
}
