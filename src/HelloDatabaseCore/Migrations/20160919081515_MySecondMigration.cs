using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDatabaseCore.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionResults_ExecututionRequests_ExecutionRequestId",
                table: "ExecutionResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExecututionRequests",
                table: "ExecututionRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExecutionRequests",
                table: "ExecututionRequests",
                column: "ExecutionRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionResults_ExecutionRequests_ExecutionRequestId",
                table: "ExecutionResults",
                column: "ExecutionRequestId",
                principalTable: "ExecututionRequests",
                principalColumn: "ExecutionRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "ExecututionRequests",
                newName: "ExecutionRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionResults_ExecutionRequests_ExecutionRequestId",
                table: "ExecutionResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExecutionRequests",
                table: "ExecutionRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExecututionRequests",
                table: "ExecutionRequests",
                column: "ExecutionRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionResults_ExecututionRequests_ExecutionRequestId",
                table: "ExecutionResults",
                column: "ExecutionRequestId",
                principalTable: "ExecutionRequests",
                principalColumn: "ExecutionRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "ExecutionRequests",
                newName: "ExecututionRequests");
        }
    }
}
