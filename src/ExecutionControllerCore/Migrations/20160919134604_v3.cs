using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExecutionControllerCore.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionJobs_ExecutionRequest_RequestId",
                table: "ExecutionJobs");

            migrationBuilder.DropIndex(
                name: "IX_ExecutionJobs_RequestId",
                table: "ExecutionJobs");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "ExecutionJobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "ExecutionJobs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionJobs_RequestId",
                table: "ExecutionJobs",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionJobs_ExecutionRequest_RequestId",
                table: "ExecutionJobs",
                column: "RequestId",
                principalTable: "ExecutionRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
