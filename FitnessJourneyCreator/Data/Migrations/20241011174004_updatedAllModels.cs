using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessJourneyCreator.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "demostrationLink",
                table: "Exercises",
                newName: "DemostrationLink");

            migrationBuilder.AddColumn<string>(
                name: "MicrocycleName",
                table: "Microcycles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MesocycleName",
                table: "Mesocycles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MacrocycleName",
                table: "Macrocycles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RepsCompleted",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MicrocycleName",
                table: "Microcycles");

            migrationBuilder.DropColumn(
                name: "MesocycleName",
                table: "Mesocycles");

            migrationBuilder.DropColumn(
                name: "MacrocycleName",
                table: "Macrocycles");

            migrationBuilder.RenameColumn(
                name: "DemostrationLink",
                table: "Exercises",
                newName: "demostrationLink");

            migrationBuilder.AlterColumn<int>(
                name: "RepsCompleted",
                table: "Logs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
