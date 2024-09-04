﻿using Company.Data.Entity;
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
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            var mapped = new Department
            {
                Name = department.Name,
                Code = department.Code,
                CreateAt = DateTime.Now


            };
            _departmentRepository.Add(mapped);
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            var dept = _departmentRepository.GetAll();
            return dept;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;

            var dept = _departmentRepository.GetById(id.Value);

            if (dept is null)
                return null;

            return (dept);
        }

        public void Update(Department entity)
        {
            
                
            
            _departmentRepository.Update(entity);

            
        }
    }
}