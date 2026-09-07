using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProyectoPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class AddPeliculasVista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "es_vista",
                table: "Peliculas");

            migrationBuilder.CreateTable(
                name: "PeliculaVista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    es_vista = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaVista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeliculaVista_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaVista_UsuarioId",
                table: "PeliculaVista",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaVista");

            migrationBuilder.AddColumn<bool>(
                name: "es_vista",
                table: "Peliculas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
