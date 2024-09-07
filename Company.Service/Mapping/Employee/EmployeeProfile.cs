using AutoMapper;
using Company.Data.Entity;
using Company.Service.Interface.EmployeeInterface.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        { 
            CreateMap<Employee,EmployeeDto>().ReverseMap();
        
        }

    }
}
