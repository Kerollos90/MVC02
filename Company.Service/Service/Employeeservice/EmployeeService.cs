using AutoMapper;
using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.EmployeeInterface;
using Company.Service.Interface.EmployeeInterface.Dto;
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
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employee)
        {
            //Employee emp = new Employee
            //{
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,
            //    DepartmentId = employee.DepartmentId,
            //    HiringDate= employee.HiringDate,
            //    Email = employee.Email,
            //    ImageUrl = employee.ImageUrl,
            //    CreateAt= employee.CreateAt



            //};
            Employee emp = _mapper.Map<Employee>(employee);

            _unitOfWork.EmployeeRepository.Add(emp);          
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee1 = new Employee
            //{
            //   Name = employeeDto.Name,
            //   Age = employeeDto.Age,
            //   Address = employeeDto.Address,
            //   PhoneNumber = employeeDto.PhoneNumber,
            //   Salary = employeeDto.Salary,
            //   DepartmentId = employeeDto.DepartmentId,
            //   HiringDate = employeeDto.HiringDate,
            //   Email = employeeDto.Email,
            //   ImageUrl = employeeDto.ImageUrl,
            //   CreateAt = employeeDto.CreateAt,
            //   Id = employeeDto.Id




            //};
            Employee emp = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Delete(emp);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employee = _unitOfWork.EmployeeRepository.GetAll();
            //var employeeDto = employee.Select(employee => new EmployeeDto
            //{
            //   Email = employee.Email,
            //   ImageUrl = employee.ImageUrl,
            //   CreateAt = employee.CreateAt,
            //   Address = employee.Address,
            //   PhoneNumber = employee.PhoneNumber,
            //   Salary = employee.Salary,
            //   DepartmentId = employee.DepartmentId,
            //   Age= employee.Age,
            //   HiringDate= employee.HiringDate,
            //   Id= employee.Id,
            //   Name= employee.Name,




            //});
           IEnumerable<EmployeeDto> emp = _mapper.Map<IEnumerable<EmployeeDto>>(employee);


            return emp;
        }

        public EmployeeDto GetById(int? id)
        {

            if (id == null)
                return null;
            var emp = _unitOfWork.EmployeeRepository.GetById(id);
            if (emp is null)
            return null;

            //EmployeeDto employee = new EmployeeDto
            //{ 
            //    Name= emp.Name,
            //    DepartmentId= emp.DepartmentId,
            //    Address= emp.Address,
            //    PhoneNumber= emp.PhoneNumber,
            //    Salary= emp.Salary,
            //    Age= emp.Age,
            //    Email= emp.Email,
            //    ImageUrl= emp.ImageUrl,
            //    HiringDate= emp.HiringDate,
            //    Id= emp.Id,
            //    CreateAt= emp.CreateAt






            //};
            EmployeeDto employee = _mapper.Map<EmployeeDto>(emp);



            return employee;
            
        }

        public IEnumerable<EmployeeDto> GetEmployeeByAddress(string Address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string SearchInp)
        {
            
            var emp= _unitOfWork.EmployeeRepository.GetEmployeeByName(SearchInp);
            //var employeeDto = emp.Select(x => new EmployeeDto
            //{
            //    Name=x.Name,
            //    DepartmentId=x.DepartmentId,
            //    Address=x.Address,
            //    PhoneNumber=x.PhoneNumber,
            //    Salary=x.Salary,
            //    Age=x.Age,
            //    Email=x.Email,
            //    ImageUrl=x.ImageUrl,
            //    HiringDate=x.HiringDate,
            //    Id=x.Id,
            //    CreateAt=x.CreateAt

            //});

            IEnumerable<EmployeeDto> empl = _mapper.Map<IEnumerable<EmployeeDto>>(emp);

            return empl; 
            
        }

        public void Update(EmployeeDto employee)
        {
            //Employee employeeDto = new Employee
            //{
            //    Name = employee.Name,
            //    DepartmentId=employee.DepartmentId,
            //    Address=employee.Address,
            //    PhoneNumber=employee.PhoneNumber,
            //    Salary=employee.Salary,
            //    Age=employee.Age,
            //    Email=employee.Email,
            //    ImageUrl=employee.ImageUrl,
            //    HiringDate=employee.HiringDate,
            //    Id=employee.Id,
            //    CreateAt= employee.CreateAt






            //};

            Employee emp = _mapper.Map<Employee>(employee);


            _unitOfWork.EmployeeRepository.Update(emp);

            _unitOfWork.Complete();
        }
    }
}
