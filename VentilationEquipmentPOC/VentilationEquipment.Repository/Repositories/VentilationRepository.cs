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

        public dynamic AddVentilationEquipment(VentilationMonitor veqObj) {
            var data = _dapperManager.QueryAsync(sql: "InsertVentilationMonitorMain", commandType: CommandType.StoredProcedure);
            return data.Result;
        }

        public dynamic GetAllVentilationEquipment()
        {
            var data = _dapperManager.QueryAsync(sql: "GetAllVentilationEquipment", commandType: CommandType.StoredProcedure);
            return data.Result;
        }
    }
}
