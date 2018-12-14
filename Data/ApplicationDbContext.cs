using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oesia.Models;

namespace Oesia.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Oesia.Models.Module> Module { get; set; }
        public DbSet<Oesia.Models.Project> Project { get; set; }
        public DbSet<Oesia.Models.Submodule> Submodule { get; set; }
        public DbSet<Oesia.Models.Subtask> Subtask { get; set; }
        public DbSet<Oesia.Models.Task> Task { get; set; }
        public DbSet<Oesia.Models.UserProject> UserProject { get; set; }
        public DbSet<Oesia.Models.UserSubtask> UserSubtask { get; set; }
        public DbSet<Oesia.Models.UserTask> UserTask { get; set; }
        public DbSet<Oesia.Models.AppUser> AppUser { get; set; }
        public DbSet<Oesia.Models.AppRole> AppRole { get; set; }
    }
}
