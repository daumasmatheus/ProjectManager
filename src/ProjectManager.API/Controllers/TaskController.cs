﻿using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.ViewModels;
using ProjectManager.Core.BaseClasses;
using ProjectManager.Infrastructure.Repository.Interfaces;
using System.Threading.Tasks;

namespace ProjectManager.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : BaseController
    {
        private IRepositoryWrapper repositoryWrapper;
        public TaskController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        [HttpPost("PostNewTask")]
        public async Task<ActionResult<TaskViewModel>> PostNewTask([FromBody] TaskViewModel task)
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

            if (repositoryWrapper.Save() == 1)
                return Ok(newTask);
            else
                return BadRequest();
        }
    }
}