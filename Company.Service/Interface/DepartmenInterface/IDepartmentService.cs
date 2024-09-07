using Company.Data.Entity;
using Company.Service.Interface.DepartmenInterface.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interface.DepartmenInterface
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add(DepartmentDto entity);

        void Delete(DepartmentDto entity);
        void Update(DepartmentDto entity);


    }
}
