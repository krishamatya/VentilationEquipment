using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace VentilationEquipment
{
   public class VentilationRepository:IVentilationRepository
    {
        private IDapperManager _dapperManager;
        
        public VentilationRepository(IDapperManager dapperManager) {
            _dapperManager = dapperManager;
            
        }

        public dynamic AddVentilationEquipment(List<VentilationMonitor> veqObj) {
            var dynamicParameters = new DynamicParameters();
            
            dynamicParameters.Add("@Objects", veqObj.AsTableValuedParameter("dbo.VentilationMonitorMain", new[]
                {
                        "Id",
                        "Unit" ,
                        "DepartmentName",
                        "Quantity"
                }));


            var data = _dapperManager.QueryAsync(sql: "InsertVentilationMonitorMain",param:dynamicParameters, commandType: CommandType.StoredProcedure);
            return data.Result;
        }

        public dynamic GetAllVentilationEquipment()
        {
            var data = _dapperManager.QueryAsync(sql: "GetAllVentilationEquipment", commandType: CommandType.StoredProcedure);
            return data.Result;
        }
        public dynamic DeleteVentilationEquipment(int Id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", Id);
            var data = _dapperManager.QueryAsync(sql: "DeleteVentilationEquipment",param:dynamicParameters, commandType: CommandType.StoredProcedure);
            return data.Result;
        }
    }
}
