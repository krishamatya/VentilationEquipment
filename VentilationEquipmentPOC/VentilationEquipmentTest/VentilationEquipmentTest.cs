using NUnit.Framework;
using VentilationEquipment;
using VentilationEquipment.Repository;
namespace VentilationEquipmentTest
{
    public class VentilationEquipmentTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVentilationService _ventilationService;
        public VentilationEquipmentTest(IUnitOfWork unitOfWork,IVentilationService ventilationService)
        {
            _ventilationService = ventilationService;
            _unitOfWork = unitOfWork;

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllDepartment()
        {
            var data = _unitOfWork.DepartmentRepository.GetAll();
            Assert.Pass();
        }
        [Test]
        public void GetDepartmentById()
        {
            int Id = 0;
            var data = _unitOfWork.DepartmentRepository.Get(x=>x.Id==Id);
            Assert.Pass();
        }

        [Test]
        public void AddDepartment()
        {
            Department department = new Department();
            _unitOfWork.DepartmentRepository.Insert(department);
            _unitOfWork.Commit();
            Assert.Pass();
        }
        [Test]
        public void AddVentilationEquipment()
        {
           VentilationMonitor ventilationMonitor = new VentilationMonitor();
           var data = _ventilationService.AddVentilationEquipment (ventilationMonitor);
            
            Assert.Pass();
        }

    }
}