﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.DTOs;
using ProjectManager.Core.BaseClasses;
using ProjectManager.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : BaseController
    {
        private IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public TaskController(IRepositoryWrapper _repositoryWrapper, IMapper _mapper)
        {
            repositoryWrapper = _repositoryWrapper;
            mapper = _mapper;
        }

        [HttpPost("PostNewTask")]
        public async Task<ActionResult<TaskDto>> PostNewTask([FromBody] TaskDto task)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var newTask = new ProjectManager.Core.Entities.Task
            {
                TaskId = task.TaskId,
                Title = task.Title,
                StatusId = task.StatusId,
                PriorityId = task.PriorityId,
                Description = task.Description,
                CreatedDate = task.CreatedDate,
            };

            await repositoryWrapper.taskRepository.Create(newTask);

            if (repositoryWrapper.Save())
                return Ok(newTask);
            else
                return BadRequest();
        }

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            var result = await repositoryWrapper.taskRepository.GetAll();
            var tasks = mapper.Map<IEnumerable<TaskDto>>(result);

            return Ok(tasks);
        }
    }
}
