using AutoMapper;
using Server.Interfaces;
using Model;
using Server.Services;
using Microsoft.AspNetCore.Mvc;
using Server.DTO.Employee;
using Server.DTO.Project;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;
    private readonly ICustomMapperService _customMapper;
    private readonly IValidatorService _validatorService;

    public ProjectController(IProjectService projectService, IMapper mapper, 
                    ICustomMapperService customMapper, IValidatorService validatorService)
    {
        _projectService = projectService;
        _mapper = mapper;
        _customMapper = customMapper;
        _validatorService = validatorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ProjectDTO> employees = (await _projectService.GetAll())
                                            .Select(x => _customMapper.MapProject(x))
                                            .ToList();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        Project? project = await _projectService.Get(id);
        if (project == null)
            return NoContent();

        ProjectDTO projectDTO = _customMapper.MapProject(project);

        return Ok(projectDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProjectDTO projectDTO)
    {
        if (!_validatorService.ValidateProject(projectDTO))
            return BadRequest();


        Project project = _mapper.Map<Project>(projectDTO);

        await _projectService.Add(project);
        return Ok();

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] AddProjectDTO projectDTO)
    {
        if (!_validatorService.ValidateProject(projectDTO))
            return BadRequest();

        Project project = _mapper.Map<Project>(projectDTO);

        await _projectService.Update(id, project);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _projectService.Delete(id);
        return Ok();
    } 
}
