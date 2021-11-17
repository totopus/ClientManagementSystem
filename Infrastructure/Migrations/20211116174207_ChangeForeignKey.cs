using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Interaction_InteractionId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Interaction_InteractionId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_InteractionId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Client_InteractionId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "InteractionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "InteractionId",
                table: "Client");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_ClientId",
                table: "Interaction",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_EmpId",
                table: "Interaction",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_Client_ClientId",
                table: "Interaction",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_Employee_EmpId",
                table: "Interaction",
                column: "EmpId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_Client_ClientId",
                table: "Interaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_Employee_EmpId",
                table: "Interaction");

            migrationBuilder.DropIndex(
                name: "IX_Interaction_ClientId",
                table: "Interaction");

            migrationBuilder.DropIndex(
                name: "IX_Interaction_EmpId",
                table: "Interaction");

            migrationBuilder.AddColumn<int>(
                name: "InteractionId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InteractionId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_InteractionId",
                table: "Employee",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_InteractionId",
                table: "Client",
                column: "InteractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Interaction_InteractionId",
                table: "Client",
                column: "InteractionId",
                principalTable: "Interaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Interaction_InteractionId",
                table: "Employee",
                column: "InteractionId",
                principalTable: "Interaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
