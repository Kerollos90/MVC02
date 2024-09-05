﻿using Company.Data.Context;
using Company.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public UnitOfWork(CompanyDbContext context ) 
        {
            _context = context;

            
            DepartmentRepository = new DepartmentRepository(context);
            EmployeeRepository = new EmployeeRepository(context);


        }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get ; set ; }

        public int Complete()
        =>_context.SaveChanges(); 
    }
}