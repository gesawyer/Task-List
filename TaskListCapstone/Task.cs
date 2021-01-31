using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListCapstone
{
    class Task1
    {
        public string TaskName { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string TeamMember { get; set; }

        public List<Task1> Tasks { get; set; }

        public Task1()
        {
            Tasks = new List<Task1>();
        }

        public Task1(string taskName, string status, string date, string teamMember)
        {
            this.TaskName = taskName;
            this.Status = status;
            this.Date = date;
            this.TeamMember = teamMember;
        }
        

        public void AddTask(string taskName, string status, string date, string teamMember)
        {
            Task1 newTask = new Task1();

            newTask.TaskName = taskName;
            newTask.Status = status;
            newTask.Date = date;
            newTask.TeamMember = teamMember;
            Tasks.Add(newTask);
            
        }
        
    }

}

