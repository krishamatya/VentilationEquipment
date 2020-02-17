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
        public VentilationEquipmentController(IOptions<ConnectionStrings> appsettings, IVentilationService service, IUnitOfWork unitOfWork)
        {
            ventilationService = service;
            _unitOfWork = unitOfWork;
            _appSettings = appsettings;
        }

        [HttpGet("GetAllDepartment")]
        public ActionResult GetAllDepartment()
        {
            return Ok(_unitOfWork.DepartmentRepository.GetAll());
        }

        [HttpGet("GetDepartmentById", Name = "GetDepartmentById")]
        public IActionResult GetDepartmentById(int id)
        {
            return Ok(_unitOfWork.DepartmentRepository.Get(x => x.Id == id));
        }

        [HttpPost("PostDepartment")]
        public IActionResult PostDepartment(Department veqObj)
        {
            if (veqObj.Id > 0) {
                _unitOfWork.DepartmentRepository.Update(veqObj);
                _unitOfWork.Commit();
            }
            else
            {
                _unitOfWork.DepartmentRepository.Insert(veqObj);
                _unitOfWork.Commit();
            }
            return CreatedAtRoute("GetDepartmentById", new { id = veqObj.Id }, veqObj);
        }
        [HttpPost("DeleteDepartment")]
        public IActionResult DeleteDepartment(Department veqObj)
        {

            _unitOfWork.DepartmentRepository.Delete(veqObj);
            _unitOfWork.Commit();

            return CreatedAtRoute("GetDepartmentById", new { id = veqObj.Id }, veqObj);
        }


        [HttpGet("GetAllVentilationEquipment")]
        public ActionResult GetAllVentilationEquipment()
        {
            return Ok(ventilationService.GetAllVentilationEquipment());
        }

        [HttpPost("PostVentilationEquipment")]
        public IActionResult PostVentilationEquipment([FromBody]List<VentilationMonitor> deptObj)
        {
            return Ok(ventilationService.AddVentilationEquipment(deptObj));
        }
        [HttpPost("DeleteVentilationEquipment")]
        public IActionResult DeleteVentilationEquipment([FromQuery]int Id)
        {
            return Ok(ventilationService.DeleteVentilationEquipment(Id));
        }
    }
}