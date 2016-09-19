using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExecutionControllerCore.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExecutionRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arguments = table.Column<string>(nullable: true),
                    ExecutionJobId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutionJobs_ExecutionRequest_RequestId",
                        column: x => x.RequestId,
                        principalTable: "ExecutionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ErrorOutput = table.Column<string>(nullable: true),
                    ExceptionXml = table.Column<string>(nullable: true),
                    ExecutionJobId = table.Column<int>(nullable: true),
                    OsDescription = table.Column<string>(nullable: true),
                    RunDuration = table.Column<TimeSpan>(nullable: true),
                    RunTime = table.Column<DateTime>(nullable: true),
                    StandardOutput = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutionResult_ExecutionJobs_ExecutionJobId",
                        column: x => x.ExecutionJobId,
                        principalTable: "ExecutionJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionJobs_RequestId",
                table: "ExecutionJobs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionRequest_ExecutionJobId",
                table: "ExecutionRequest",
                column: "ExecutionJobId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionResult_ExecutionJobId",
                table: "ExecutionResult",
                column: "ExecutionJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionRequest_ExecutionJobs_ExecutionJobId",
                table: "ExecutionRequest",
                column: "ExecutionJobId",
                principalTable: "ExecutionJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionJobs_ExecutionRequest_RequestId",
                table: "ExecutionJobs");

            migrationBuilder.DropTable(
                name: "ExecutionResult");

            migrationBuilder.DropTable(
                name: "ExecutionRequest");

            migrationBuilder.DropTable(
                name: "ExecutionJobs");
        }
    }
}
