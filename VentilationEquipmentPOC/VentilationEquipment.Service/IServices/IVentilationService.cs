using System;
using System.Collections.Generic;
using System.Text;

namespace VentilationEquipment
{
    public interface IVentilationService
    {
        dynamic AddVentilationEquipment(List<VentilationMonitor> veqObj);
        dynamic GetAllVentilationEquipment();
        dynamic DeleteVentilationEquipment(int Id);
    }
}
