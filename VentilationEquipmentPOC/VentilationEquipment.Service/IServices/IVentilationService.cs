using System;
using System.Collections.Generic;
using System.Text;

namespace VentilationEquipment
{
    public interface IVentilationService
    {
        dynamic AddVentilationEquipment(VentilationMonitor veqObj);
        dynamic GetAllVentilationEquipment();
    }
}
