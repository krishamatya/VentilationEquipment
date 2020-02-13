using System;
using System.Collections.Generic;
using System.Text;

namespace VentilationEquipment
{
  public  class UnitOfWork:IUnitOfWork
    {
        private DbContextMain _dbContext;
        private Repository<Department> _department;
     

        public UnitOfWork(DbContextMain dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Department> DepartmentRepository
        {
            get
            {
                return _department ??
                    (_department = new Repository<Department>(_dbContext));
            }
        }

      
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
