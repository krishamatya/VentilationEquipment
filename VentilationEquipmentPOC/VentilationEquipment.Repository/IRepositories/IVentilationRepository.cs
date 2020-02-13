using System;
using System.Collections.Generic;
using System.Text;

namespace VentilationEquipment
{
    public interface IVentilationRepository
    {
        dynamic AddVentilationEquipment(VentilationMonitor veqObj);
        dynamic GetAllVentilationEquipment();
    }
}
