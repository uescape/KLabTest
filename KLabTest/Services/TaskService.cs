using KLabTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLabTest.Services
{
    public class TaskService
    {
        private KLabTextContext _dbContext { get; set; }

        public TaskService(KLabTextContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Task AddTask(Models.Task task)
        {
            _dbContext.Task.Add(task);
            _dbContext.SaveChanges();
            return task;
        }

        public Models.Task GetTaskById(int id)
        {
            return _dbContext.Task.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Models.Task> GetTaskList()
        {
            return _dbContext.Task.ToList();
        }

        public bool Delete(List<Models.Task> tasks)
        {
            _dbContext.Task.RemoveRange(tasks);
            int rowAffected = _dbContext.SaveChanges();

            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
