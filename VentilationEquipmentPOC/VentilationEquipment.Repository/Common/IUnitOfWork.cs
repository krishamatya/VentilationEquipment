using System;
using System.Collections.Generic;
using System.Text;

namespace VentilationEquipment
{
   public interface IUnitOfWork
    {
        IRepository<Department> DepartmentRepository { get; }
      
        void Commit();
    }
}
