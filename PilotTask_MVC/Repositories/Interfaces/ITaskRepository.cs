using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;


namespace PilotTask_MVC.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        void InsertTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);
        Task GetTaskById(int taskId);
        List<Task> GetTasks();
        List<Task> GetTasksByProfileId(int profileId);
    }
}
