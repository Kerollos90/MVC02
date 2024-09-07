using Company.Data.Entity;
using Company.Service.Interface.DepartmenInterface.Dto;
using Company.Service.Interface.EmployeeInterface.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Company.Service.Mapping
{
    public class DepartmentProfile :Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();






        }


    }
}
