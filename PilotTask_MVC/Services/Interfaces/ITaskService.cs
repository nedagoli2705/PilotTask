using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;


namespace PilotTask_MVC.Services.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);
        Task GetTaskById(int taskId);
        List<Task> GetTasks();
    }
}
