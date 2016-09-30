using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExecutionControllerCore.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAdress",
                table: "ExecutionResult",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "ExecutionResult",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionResult_RequestId",
                table: "ExecutionResult",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionResult_ExecutionRequest_RequestId",
                table: "ExecutionResult",
                column: "RequestId",
                principalTable: "ExecutionRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionResult_ExecutionRequest_RequestId",
                table: "ExecutionResult");

            migrationBuilder.DropIndex(
                name: "IX_ExecutionResult_RequestId",
                table: "ExecutionResult");

            migrationBuilder.DropColumn(
                name: "IPAdress",
                table: "ExecutionResult");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "ExecutionResult");
        }
    }
}
