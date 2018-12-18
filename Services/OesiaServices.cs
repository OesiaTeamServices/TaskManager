using System;
using Oesia.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Oesia.Data;
using Microsoft.AspNetCore.Identity;

namespace Oesia.Services
{
    public class OesiaServices
    {
        public OesiaServices()
        {
        }
        private readonly ApplicationDbContext _context;

        public object User { get; private set; }
        private readonly UserManager<AppUser> _userManager;

        public OesiaServices(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Project> GetProjectsDB()
        {
            List<Project> projects = _context.Project.ToList();
            return projects;
        }

        public List<Module> GetModulesDB()
        {
            List<Module> modules = _context.Module.ToList();
            return modules;
        }

        public List<Submodule> GetSubmodulesDB()
        {
            List<Submodule> submodules = _context.Submodule.ToList();
            return submodules;
        }

        public List<Oesia.Models.Task> GetTasksDB()
        {
            List<Oesia.Models.Task> tasks = _context.Task.ToList();
            return tasks;
        }

        public List<Subtask> GetSubtasksDB()
        {
            List<Subtask> subtasks = _context.Subtask.ToList();
            return subtasks;
        }

        public List<AppUser> GetUsersByRoleDB(string role)
        {
            switch (role)
            {
                case "Project manager":
                    role = "1";
                    break;
                case "Task manager":
                    role = "2";
                    break;
                case "Technician":
                    role = "3";
                    break;
            }
            var userRoles = _context.UserRoles.Where(x => x.RoleId==role);
            List<AppUser> users = new List<AppUser>();
            foreach(var item in userRoles){
                AppUser user = _context.Users.Single(x=>x.Id==item.UserId);
                users.Add(user);
            }
            //List<AppUser> users = _context.Users.ToList();
            //List<AppUser> userroles= new List<AppUser>();
            //foreach(AppUser user in users){
            //    ICollection<string> roles =  _userManager.GetRolesAsync(user);
            //    if (.)
            //}
            return users;
        }

        //public UserProject GetUserProjectObject(AppUser user, Project project)
        //{
        //    UserProject link = new UserProject()
        //    {
        //        AppUsers = user,
        //        Projects = project
        //    };
        //    return link;
        //}

        public string GetNameAndSurnamesDBFromId(string userId)
        {
            List<AppUser> users = _context.AppUser.Where(x => x.Id == userId).ToList();
            string name = "";
            string surname = "";
            if (users.Count == 1)
            {
                name = users[0].FirstName;
                surname = users[0].LastName;
            }
            return name + " " + surname;
        }

        public List<string> LisOfTypes()
        {
            List<string> types = new List<string>
            {
                "Error",
                "Internal task",
                "Modification",
                "Suport"
            };
            return types;
        }

        public List<string> LisOfCriticality()
        {
            List<string> criticalities = new List<string>
            {
                "Aesthetic",
                "Inhibiting",
                "Important",
                "Normal"
            };
            return criticalities;
        }

        public List<string> LisOfPriority()
        {
            List<string> priorities = new List<string>
            {
                "P1",
                "P2",
                "P3",
            };
            return priorities;
        }

        public string GetUserIdFromTaskId(int taskId)
        {
            List<UserTask> relations = _context.UserTask.Where(x => x.Tasks.Id == taskId).ToList();
            if (relations.Count == 1)
            {
                return relations[0].AppUsers.Id;
            }
            return "";
        }

        public void UpdateSubtaskTimes(long subtaskId, string userId)
        {
            Subtask currentSubtask = _context.Subtask.Single(x => x.Id == subtaskId);
            UserSubtask currentUserSubtask = _context.UserSubtask.Single(x => x.AppUsers.Id == userId && x.Subtasks.Id == subtaskId);

            double timeConsumed = (currentUserSubtask.RecordTime.Hour / 1.00);
            timeConsumed += (currentUserSubtask.RecordTime.Minute / 60.00);
            timeConsumed += (currentUserSubtask.RecordTime.Second / 3600.00);
            timeConsumed = Math.Round(timeConsumed, 2);
            currentSubtask.ElapsedHours = timeConsumed;
            currentSubtask.PendingHours = currentSubtask.EstimatedHours - timeConsumed;
            if (currentSubtask.PendingHours < 0)
            {
                currentSubtask.PendingHours = 0;
            }

            _context.Subtask.Update(currentSubtask);
        }

        public void UpdateTaskTimes(long taskId)
        {
            Models.Task currentTask = _context.Task.Single(x => x.Id == taskId);

            double sumOfElapsedTimes = 0.0;
            foreach (Subtask subtask in currentTask.Subtasks)
            {
                sumOfElapsedTimes += subtask.ElapsedHours;
            }

            currentTask.ElapsedHours = sumOfElapsedTimes;
            currentTask.PendingHours = currentTask.EstimatedHours - sumOfElapsedTimes;
            if (currentTask.PendingHours < 0)
            {
                currentTask.PendingHours = 0;
            }
            _context.Task.Update(currentTask);
        }

        public void UpdateSubmoduleTimes(long submoduleId)
        {
            Submodule currentSubmodule = _context.Submodule.Single(x => x.Id == submoduleId);

            double sumOfElapsedTimes = 0.0;
            foreach (Models.Task task in currentSubmodule.Tasks)
            {
                sumOfElapsedTimes += task.ElapsedHours;
            }

            currentSubmodule.ElapsedHours = sumOfElapsedTimes;
            currentSubmodule.PendingHours = currentSubmodule.EstimatedHours - sumOfElapsedTimes;
            if (currentSubmodule.PendingHours < 0)
            {
                currentSubmodule.PendingHours = 0;
            }

            _context.Submodule.Update(currentSubmodule);
        }

        public void UpdateModuleTimes(long moduleId)
        {
            Module currentModule = _context.Module.Single(x => x.Id == moduleId);

            double sumOfElapsedTimes = 0.0;
            foreach (Submodule submodule in currentModule.Submodules)
            {
                sumOfElapsedTimes += submodule.ElapsedHours;
            }

            currentModule.ElapsedHours = sumOfElapsedTimes;
            currentModule.PendingHours = currentModule.EstimatedHours - sumOfElapsedTimes;
            if (currentModule.PendingHours < 0)
            {
                currentModule.PendingHours = 0;
            }

            _context.Module.Update(currentModule);
        }

        public void UpdateProjectTimes(long projectId)
        {
            Project currentProject = _context.Project.Single(x => x.Id == projectId);

            double sumOfElapsedTimes = 0.0;
            foreach (Module module in currentProject.Modules)
            {
                sumOfElapsedTimes += module.ElapsedHours;
            }

            currentProject.ElapsedHours = sumOfElapsedTimes;
            currentProject.PendingHours = currentProject.EstimatedHours - sumOfElapsedTimes;
            if (currentProject.PendingHours < 0)
            {
                currentProject.PendingHours = 0;
            }

            _context.Project.Update(currentProject);
        }
    }
}