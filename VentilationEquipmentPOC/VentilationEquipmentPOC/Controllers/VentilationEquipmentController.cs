using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VentilationEquipment;

namespace VentilationEquipmentPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentilationEquipmentController : ControllerBase
    {
        private readonly IOptions<ConnectionStrings> _appSettings;
        private IVentilationService ventilationService;
        private readonly IUnitOfWork _unitOfWork;
        public VentilationEquipmentController( IOptions<ConnectionStrings> appsettings,IVentilationService service ,IUnitOfWork unitOfWork)
        {
            ventilationService = service;
            _unitOfWork = unitOfWork;
            _appSettings = appsettings;
        }

        [HttpGet("GetAllDepartment")]
        public ActionResult GetAllDepartment()
        {
            return Ok (_unitOfWork.DepartmentRepository.GetAll());
        }

        [HttpGet("GetDepartmentById",Name = "GetDepartmentById")]
        public  IActionResult GetDepartmentById(int id)
        {
            return Ok(_unitOfWork.DepartmentRepository.Get(x => x.Id == id));
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Department veqObj)
        {
            _unitOfWork.DepartmentRepository.Insert(veqObj);
            _unitOfWork.Commit();
             return CreatedAtRoute("GetDepartmentById",new { id = veqObj.Id },veqObj);
        }

        [HttpGet("GetAllVentilationEquipment")]
        public ActionResult GetAllVentilationEquipment()
        {
            return ventilationService.GetAllVentilationEquipment();
        }

        [HttpPost("AddVentilationEquipment")]
        public IActionResult AddVentilationEquipment(VentilationMonitor deptObj)
        {
            return ventilationService.AddVentilationEquipment(deptObj);
        }
    }
}