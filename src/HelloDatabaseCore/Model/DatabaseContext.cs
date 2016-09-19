using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloDatabaseCore.Model;

namespace HelloDatabaseCore.SQLServer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ExecutionRequest> ExecutionRequests {get; set; }
        public DbSet<ExecutionResult> ExecutionResults {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=HelloDatabaseCore;Trusted_Connection=True;");
        }
    }
}