using Company.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interface.DepartmenInterface
{
    public interface IDepartmentService
    {
        Department GetById(int id);
        IEnumerable<Department> GetAll();
        void Add(Department entity);

        void Delete(Department entity);
        void Update(Department entity);


    }
}
