using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessJourneyCreator.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedAPropertyToHaveACapitalLetter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Macrocycles",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Macrocycles",
                newName: "description");
        }
    }
}
