using Company.Data.Entity;
using Company.Service.Interface.EmployeeInterface.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interface.DepartmenInterface.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public DateTime CreateAt { get; set; } = DateTime.Now;


    }
}
