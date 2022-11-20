using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApp.Models
{
    public class TaskAppCoreCourseContext : DbContext
    {
        public TaskAppCoreCourseContext (DbContextOptions<TaskAppCoreCourseContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreWebApp.Models.TaskEntityApp> TaskEntityApp { get; set; }
    }
}
