using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExecutionControllerCore.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionRequest_ExecutionJobs_ExecutionJobId",
                table: "ExecutionRequest");

            migrationBuilder.DropIndex(
                name: "IX_ExecutionRequest_ExecutionJobId",
                table: "ExecutionRequest");

            migrationBuilder.DropColumn(
                name: "ExecutionJobId",
                table: "ExecutionRequest");

            migrationBuilder.AddColumn<int>(
                name: "ExecutionCount",
                table: "ExecutionRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutionJobId1",
                table: "ExecutionRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionRequest_ExecutionJobId1",
                table: "ExecutionRequest",
                column: "ExecutionJobId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionRequest_ExecutionJobs_ExecutionJobId1",
                table: "ExecutionRequest",
                column: "ExecutionJobId1",
                principalTable: "ExecutionJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionRequest_ExecutionJobs_ExecutionJobId1",
                table: "ExecutionRequest");

            migrationBuilder.DropIndex(
                name: "IX_ExecutionRequest_ExecutionJobId1",
                table: "ExecutionRequest");

            migrationBuilder.DropColumn(
                name: "ExecutionCount",
                table: "ExecutionRequest");

            migrationBuilder.DropColumn(
                name: "ExecutionJobId1",
                table: "ExecutionRequest");

            migrationBuilder.AddColumn<int>(
                name: "ExecutionJobId",
                table: "ExecutionRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionRequest_ExecutionJobId",
                table: "ExecutionRequest",
                column: "ExecutionJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionRequest_ExecutionJobs_ExecutionJobId",
                table: "ExecutionRequest",
                column: "ExecutionJobId",
                principalTable: "ExecutionJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
