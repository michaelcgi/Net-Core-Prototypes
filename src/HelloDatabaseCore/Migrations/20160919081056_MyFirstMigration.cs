using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HelloDatabaseCore.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExecututionRequests",
                columns: table => new
                {
                    ExecutionRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arguments = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecututionRequests", x => x.ExecutionRequestId);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionResults",
                columns: table => new
                {
                    ExecutionResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExceptionXml = table.Column<string>(nullable: true),
                    ExecutionRequestId = table.Column<int>(nullable: true),
                    OSDescription = table.Column<string>(nullable: true),
                    Output = table.Column<string>(nullable: true),
                    RunDuration = table.Column<TimeSpan>(nullable: true),
                    RunTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionResults", x => x.ExecutionResultId);
                    table.ForeignKey(
                        name: "FK_ExecutionResults_ExecututionRequests_ExecutionRequestId",
                        column: x => x.ExecutionRequestId,
                        principalTable: "ExecututionRequests",
                        principalColumn: "ExecutionRequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionResults_ExecutionRequestId",
                table: "ExecutionResults",
                column: "ExecutionRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecutionResults");

            migrationBuilder.DropTable(
                name: "ExecututionRequests");
        }
    }
}
