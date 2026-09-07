using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProyectoPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class RelationPeliculaVista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasU_Peliculas_PeliculasId",
                table: "PeliculasU");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasU_Usuarios_UsuariosId",
                table: "PeliculasU");

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosId",
                table: "PeliculasU",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasU",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaVista_PeliculaId",
                table: "PeliculaVista",
                column: "PeliculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasU_Peliculas_PeliculasId",
                table: "PeliculasU",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasU_Usuarios_UsuariosId",
                table: "PeliculasU",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculaVista_Peliculas_PeliculaId",
                table: "PeliculaVista",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasU_Peliculas_PeliculasId",
                table: "PeliculasU");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasU_Usuarios_UsuariosId",
                table: "PeliculasU");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculaVista_Peliculas_PeliculaId",
                table: "PeliculaVista");

            migrationBuilder.DropIndex(
                name: "IX_PeliculaVista_PeliculaId",
                table: "PeliculaVista");

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosId",
                table: "PeliculasU",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasU",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasU_Peliculas_PeliculasId",
                table: "PeliculasU",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasU_Usuarios_UsuariosId",
                table: "PeliculasU",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
