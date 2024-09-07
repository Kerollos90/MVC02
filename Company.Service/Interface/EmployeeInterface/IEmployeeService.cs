using Company.Data.Entity;
using Company.Service.Interface.EmployeeInterface.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interface.EmployeeInterface
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll();
        EmployeeDto GetById(int? id);

        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
         void Delete(EmployeeDto employee);

        IEnumerable<EmployeeDto> GetEmployeeByName(string Name);
        IEnumerable<EmployeeDto> GetEmployeeByAddress(string Address);





    }
}
