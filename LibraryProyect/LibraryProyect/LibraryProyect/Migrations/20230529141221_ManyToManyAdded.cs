using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProyect.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherCode",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherCode",
                table: "Person",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCode",
                table: "Person",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentCode",
                table: "Person",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    IdPrestamo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idPersona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idLibro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fehcaPrestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fehcaLimite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Loans_Books_idLibro",
                        column: x => x.idLibro,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Person_idPersona",
                        column: x => x.idPersona,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_EmployeeCode",
                table: "Person",
                column: "EmployeeCode",
                unique: true,
                filter: "[EmployeeCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_StudentCode",
                table: "Person",
                column: "StudentCode",
                unique: true,
                filter: "[StudentCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_TeacherCode",
                table: "Person",
                column: "TeacherCode",
                unique: true,
                filter: "[TeacherCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_idLibro",
                table: "Loans",
                column: "idLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_idPersona",
                table: "Loans",
                column: "idPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_EmployeeCode",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_StudentCode",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_TeacherCode",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EmployeeCode",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "StudentCode",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherCode",
                table: "Teachers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherCode",
                table: "Teachers",
                column: "TeacherCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCode",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentCode",
                table: "Students",
                column: "StudentCode",
                unique: true);
        }
    }
}
