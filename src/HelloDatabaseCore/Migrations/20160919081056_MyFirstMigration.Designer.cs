using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HelloDatabaseCore.SQLServer;

namespace HelloDatabaseCore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20160919081056_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelloDatabaseCore.Model.ExecutionRequest", b =>
                {
                    b.Property<int>("ExecutionRequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arguments");

                    b.Property<string>("FileName");

                    b.HasKey("ExecutionRequestId");

                    b.ToTable("ExecututionRequests");
                });

            modelBuilder.Entity("HelloDatabaseCore.Model.ExecutionResult", b =>
                {
                    b.Property<int>("ExecutionResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExceptionXml");

                    b.Property<int?>("ExecutionRequestId");

                    b.Property<string>("OSDescription");

                    b.Property<string>("Output");

                    b.Property<TimeSpan?>("RunDuration");

                    b.Property<DateTime?>("RunTime");

                    b.HasKey("ExecutionResultId");

                    b.HasIndex("ExecutionRequestId");

                    b.ToTable("ExecutionResults");
                });

            modelBuilder.Entity("HelloDatabaseCore.Model.ExecutionResult", b =>
                {
                    b.HasOne("HelloDatabaseCore.Model.ExecutionRequest", "ExecutionRequest")
                        .WithMany()
                        .HasForeignKey("ExecutionRequestId");
                });
        }
    }
}
