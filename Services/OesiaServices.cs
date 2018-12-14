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
    }
}