﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ExecutionControllerCore.Model;

namespace ExecutionControllerCore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20160919131735_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExecutionCore.Model.ExecutionJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RequestId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("ExecutionJobs");
                });

            modelBuilder.Entity("ExecutionCore.Model.ExecutionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arguments");

                    b.Property<int?>("ExecutionJobId");

                    b.Property<string>("FileName");

                    b.HasKey("Id");

                    b.HasIndex("ExecutionJobId");

                    b.ToTable("ExecutionRequest");
                });

            modelBuilder.Entity("ExecutionCore.Model.ExecutionResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ErrorOutput");

                    b.Property<string>("ExceptionXml");

                    b.Property<int?>("ExecutionJobId");

                    b.Property<string>("OsDescription");

                    b.Property<TimeSpan?>("RunDuration");

                    b.Property<DateTime?>("RunTime");

                    b.Property<string>("StandardOutput");

                    b.HasKey("Id");

                    b.HasIndex("ExecutionJobId");

                    b.ToTable("ExecutionResult");
                });

            modelBuilder.Entity("ExecutionCore.Model.ExecutionJob", b =>
                {
                    b.HasOne("ExecutionCore.Model.ExecutionRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("ExecutionCore.Model.ExecutionRequest", b =>
                {
                    b.HasOne("ExecutionCore.Model.ExecutionJob")
                        .WithMany("Requests")
                        .HasForeignKey("ExecutionJobId");
                });

            modelBuilder.Entity("ExecutionCore.Model.ExecutionResult", b =>
                {
                    b.HasOne("ExecutionCore.Model.ExecutionJob")
                        .WithMany("Results")
                        .HasForeignKey("ExecutionJobId");
                });
        }
    }
}
