using AutoMapper;
using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.DepartmenInterface;
using Company.Service.Interface.DepartmenInterface.Dto;
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
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto department)
        {
        //    Department mapped = new Department
        //    {
        //        Name = department.Name,
        //        Code = department.Code,
        //        CreateAt = department.CreateAt,
        //        Id = department.Id,


        //    };

            Department  department1 = _mapper.Map<Department>(department);
            _unitOfWork.DepartmentRepository.Add(department1);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto entity)
        {
            //var department = new Department
            //{
            //    Name = entity.Name,
            //    Code = entity.Code,
            //    CreateAt = entity.CreateAt,
            //    Id = entity.Id












            //};
            Department department1 = _mapper.Map<Department>(entity);


            _unitOfWork.DepartmentRepository.Delete(department1);
            _unitOfWork.Complete();

        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var dept = _unitOfWork.DepartmentRepository.GetAll();

            //var deptDto = dept.Select(x => new DepartmentDto
            //{
            //    Name = x.Name,
            //    Code = x.Code,
            //    CreateAt = x.CreateAt,
            //    Id = x.Id,




            //});
            IEnumerable< DepartmentDto> department1 = _mapper.Map<IEnumerable< DepartmentDto>>(dept);



            return department1;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var dept = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (dept is null)
                return null;

            //DepartmentDto department = new DepartmentDto
            //{
            //    Name = dept.Name,
            //    Code = dept.Code,
            //    CreateAt = dept.CreateAt,
            //    Id = dept.Id,



            //};
             DepartmentDto  department1 = _mapper.Map<DepartmentDto>(dept);



            return (department1);
        }

        public void Update(DepartmentDto entity)
        {


            //Department department = new Department
            //{ 
            //    Name = entity.Name,
            //    Code = entity.Code,
            //    CreateAt = entity.CreateAt,
            //    Id = entity.Id





            //};

            Department department = _mapper.Map<Department>(entity);


            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();



        }



    }
}
