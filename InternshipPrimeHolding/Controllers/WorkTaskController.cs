﻿using AutoMapper;
using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Interfaces;
using InternshipPrimeHolding.Model;
using InternshipPrimeHolding.Services;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternshipPrimeHolding.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkTaskController : ControllerBase
{
    private readonly IWorkTaskService _workTaskService;
    private readonly IMapper _mapper;
    private readonly IValidatorService _validatorService;

    public WorkTaskController(IWorkTaskService workTaskService, IMapper mapper, IValidatorService validatorService)
    {
        _workTaskService = workTaskService;
        _mapper = mapper;
        _validatorService = validatorService;
    }

    // GET: api/<TaskController>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<WorkTaskDTO> tasks = _mapper.Map<List<WorkTaskDTO>>(await _workTaskService.GetAll());
        return Ok(tasks);
    }

    // GET api/<TaskController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        WorkTaskDTO task = _mapper.Map<WorkTaskDTO>(await _workTaskService.Get(id)); 
        if (task != null)
        {
            return Ok(task);
        }
        return NoContent();
    }

    // POST api/<TaskController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddWorkTaskDTO workTask)
    {
        if (!_validatorService.ValidateWorkTask(workTask))
            return BadRequest();

        WorkTask task = _mapper.Map<WorkTask>(workTask); 
        if (await _workTaskService.Add(task)) 
            return Ok(); 
        return BadRequest();  
    }

    // PUT api/<TaskController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] AddWorkTaskDTO workTask)
    {
        if (!_validatorService.ValidateWorkTask(workTask))
            return BadRequest();

        WorkTask task = _mapper.Map<WorkTask>(workTask);
        if (await _workTaskService.Update(id, task))
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
     
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        bool response = await _workTaskService.Delete(id);
        if (response)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost("Assign/{workTaskId}/{employeeId}")]
    public async Task<IActionResult> Assign(long workTaskId, long employeeId)
    { 
        if (await _workTaskService.Assign(workTaskId, employeeId)) 
            return Ok(); 
        return BadRequest();
    }
    [HttpPut("State/{workTaskId}/{taskState}")]
    public async Task<IActionResult> ChangeState(long workTaskId, TaskState taskState)
    {  
        if (await _workTaskService.ChangeState(workTaskId, taskState)) 
            return Ok(); 
        return BadRequest();
    }
}