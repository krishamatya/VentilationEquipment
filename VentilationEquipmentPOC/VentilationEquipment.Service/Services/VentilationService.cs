using System;
using System.Collections.Generic;
using System.Text;


namespace VentilationEquipment
{

    public  class VentilationService:IVentilationService
    {
        private readonly IVentilationRepository ventilationRepository;
        public VentilationService(IVentilationRepository repository) {
            ventilationRepository = repository;
        }
       
        public dynamic AddVentilationEquipment(VentilationMonitor veqObj) {
            return ventilationRepository.AddVentilationEquipment(veqObj);
        }
        public dynamic GetAllVentilationEquipment() {
            return ventilationRepository.GetAllVentilationEquipment();

        }
    }
}
