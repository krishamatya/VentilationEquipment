using System;
using System.Collections.Generic;
using System.Text;

namespace VentilationEquipment
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public decimal VentilationCapacity { get; set; } 
    }
}
