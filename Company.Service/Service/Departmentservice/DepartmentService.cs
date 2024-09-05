using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.DepartmenInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Service.Departmentservice
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public void Add(Department department)
        {
            var mapped = new Department
            {
                Name = department.Name,
                Code = department.Code,
                CreateAt = DateTime.Now


            };
            _unitOfWork.DepartmentRepository.Add(mapped);
            _unitOfWork.Complete();
        }

        public void Delete(Department entity)
        {
            _unitOfWork.DepartmentRepository.Delete(entity);
            _unitOfWork.Complete();

        }

        public IEnumerable<Department> GetAll()
        {
            var dept = _unitOfWork.DepartmentRepository.GetAll();
            

            return dept;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;

            var dept = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (dept is null)
                return null;

            return (dept);
        }

        public void Update(Department entity)
        {
            
                
            
            _unitOfWork.DepartmentRepository.Update(entity);
            _unitOfWork.Complete();



        }



    }
}
