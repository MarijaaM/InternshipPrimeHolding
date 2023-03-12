using AutoMapper;
using Server.Interfaces;
using Model;
using Server.Services;
using Microsoft.AspNetCore.Mvc;
using Server.DTO.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ICustomMapperService _customMapper;
        private readonly IValidatorService _validatorService;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ICustomMapperService customMapper, IValidatorService validatorService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _customMapper = customMapper;
            _validatorService = validatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<EmployeeDTO> employees = (await _employeeService.GetAll())
                                                .Select(x => _customMapper.MapEmpoloyee(x))
                                                .ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Employee? employee = await _employeeService.Get(id);
            if (employee == null)
                return NoContent();

            EmployeeDTO employeeDTO = _customMapper.MapEmpoloyee(employee);

            return Ok(employeeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeDTO employee)
        {
            if (!_validatorService.ValidateEmployee(employee))
                return BadRequest();


            Employee e = _mapper.Map<Employee>(employee);

            await _employeeService.Add(e);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] AddEmployeeDTO employeeDTO)
        {
            if (!_validatorService.ValidateEmployee(employeeDTO))
                return BadRequest();

            Employee employee = _mapper.Map<Employee>(employeeDTO);

            await _employeeService.Update(id, employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }
        [HttpGet("Best")]
        public async Task<IActionResult> GetBest5()
        {
            List<EmployeeDTO> employees = (await _employeeService.GetBest5())
                                                                    .Select(x => _customMapper.MapEmpoloyee(x))
                                                                    .ToList();
            return Ok(employees);
        }
    }
}
