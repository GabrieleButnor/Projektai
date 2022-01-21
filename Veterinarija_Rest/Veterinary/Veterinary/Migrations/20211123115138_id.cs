using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinary.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "fk_VisitId",
                table: "vizis_services",
                newName: "Fk_VisitId");

            migrationBuilder.RenameColumn(
                name: "fk_ServiceId",
                table: "vizis_services",
                newName: "Fk_ServiceId");

            migrationBuilder.RenameColumn(
                name: "fk_PetId",
                table: "visits",
                newName: "Fk_PetId");

            migrationBuilder.RenameColumn(
                name: "fk_UserId",
                table: "services",
                newName: "Fk_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "services",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_services_UserId",
                table: "services",
                newName: "IX_services_userId");

            migrationBuilder.RenameColumn(
                name: "fk_UserId",
                table: "pets",
                newName: "Fk_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "pets",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_pets_UserId",
                table: "pets",
                newName: "IX_pets_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_pets_AspNetUsers_userId",
                table: "pets",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_AspNetUsers_userId",
                table: "services",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pets_AspNetUsers_userId",
                table: "pets");

            migrationBuilder.DropForeignKey(
                name: "FK_services_AspNetUsers_userId",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "Fk_VisitId",
                table: "vizis_services",
                newName: "fk_VisitId");

            migrationBuilder.RenameColumn(
                name: "Fk_ServiceId",
                table: "vizis_services",
                newName: "fk_ServiceId");

            migrationBuilder.RenameColumn(
                name: "Fk_PetId",
                table: "visits",
                newName: "fk_PetId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "services",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Fk_UserId",
                table: "services",
                newName: "fk_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_services_userId",
                table: "services",
                newName: "IX_services_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "pets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Fk_UserId",
                table: "pets",
                newName: "fk_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_pets_userId",
                table: "pets",
                newName: "IX_pets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_pets_AspNetUsers_UserId",
                table: "pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_AspNetUsers_UserId",
                table: "services",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
