using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExecutionCore.Model;

namespace ExecutionControllerCore.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ExecutionJob> ExecutionJobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SybilExecutionV1;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExecutionJob>()
                .Ignore(ej => ej.Request)
                .Ignore(ej => ej.RequestLeafs);

            modelBuilder.Entity<ExecutionRequest>()
                .Ignore(er => er.Index);
        }
    }
}