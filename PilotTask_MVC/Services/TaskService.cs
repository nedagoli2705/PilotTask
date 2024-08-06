using PilotTask_MVC.DataAccess;
using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotTask_MVC.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskDAL;

        public TaskService(TaskRepository taskDAL)
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

        public List<Task> GetTasks()
        {
            return _taskDAL.GetTasks();
        }
    }
}