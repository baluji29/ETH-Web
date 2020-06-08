using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETH.API.Migrations
{
    public partial class UserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "UserName",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserName",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserName",
                table: "UserName",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserName",
                table: "UserName");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserName");

            migrationBuilder.RenameTable(
                name: "UserName",
                newName: "Users");

            migrationBuilder.AlterColumn<byte[]>(
                name: "MobileNumber",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
