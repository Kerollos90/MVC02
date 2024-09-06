using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.EmployeeInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Service.Employeeservice
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Employee employee)
        {
            var emp = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                HiringDate= employee.HiringDate,
                Email = employee.Email,
                ImageUrl = employee.ImageUrl,
                CreateAt= DateTime.Now



            };

            _unitOfWork.EmployeeRepository.Add(emp);          
            _unitOfWork.Complete();
        }

        public void Delete(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GetAll()
        {
           var emp = _unitOfWork.EmployeeRepository.GetAll();
            return emp;
        }

        public Employee GetById(int? id)
        {
            var emp = _unitOfWork.EmployeeRepository.GetById(id);
            return emp;
            
        }

        public IEnumerable<Employee> GetEmployeeByAddress(string Address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeeByName(string SearchInp)
        {
            
            var emp= _unitOfWork.EmployeeRepository.GetEmployeeByName(SearchInp);
            return emp; 
            
        }

        public void Update(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
