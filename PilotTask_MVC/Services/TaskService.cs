using PilotTask_MVC.DataAccess;
using PilotTask_MVC.Models;
using PilotTask_MVC.Repositories.Interfaces;
using PilotTask_MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotTask_MVC.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskDAL;

        public TaskService(ITaskRepository taskDAL)
        {
            _taskDAL = taskDAL;
        }

        public void CreateTask(Task task)
        {
            _taskDAL.InsertTask(task);
        }

        public void UpdateTask(Task task)
        {
            _taskDAL.UpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            _taskDAL.DeleteTask(taskId);
        }

        public Task GetTaskById(int taskId)
        {
            return _taskDAL.GetTaskById(taskId);
        }

        public List<Task> GetTasksByProfileId(int profileId)
        {
            return _taskDAL.GetTasksByProfileId(profileId);
        }
    }
}