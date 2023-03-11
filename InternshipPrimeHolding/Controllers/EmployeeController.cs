using AutoMapper;
using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Interfaces;
using InternshipPrimeHolding.Model;
using InternshipPrimeHolding.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternshipPrimeHolding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper; 
        private readonly IValidatorService _validatorService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IValidatorService validatorService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _validatorService = validatorService;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<EmployeeDTO> employees = _mapper.Map<List<EmployeeDTO>>(await _employeeService.GetAll());
            return Ok(employees);
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EmployeeDTO employee = _mapper.Map<EmployeeDTO>(await _employeeService.Get(id)); 
            if (employee != null)
            {
                return Ok(employee);
            }
            return NoContent();
        }
         
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEmployeeDTO employee)
        {
            if(!_validatorService.ValidateEmployee(employee))
                return BadRequest();


            Employee e = _mapper.Map<Employee>(employee);

            if (await _employeeService.Add(e))
                return Ok();
            return BadRequest();

        }
         
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AddEmployeeDTO employee)
        { 
            if (!_validatorService.ValidateEmployee(employee))
                return BadRequest();

            Employee e = _mapper.Map<Employee>(employee);

            if (await _employeeService.Update(id, e))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _employeeService.Delete(id))
                return Ok();
            return BadRequest();
        }
    }
}
