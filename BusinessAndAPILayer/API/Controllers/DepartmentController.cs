using Business.Abstract;
using DTO.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // API den Business a IDepartmentService ile gidicez
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CreateDepartmentRequest department)
        {
            var response = _service.Insert(department); 
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put(UpdateDepartmentRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Department department)
        {
            var response = _service.Delete(department);
            return Ok(response);
        }


    }
}
