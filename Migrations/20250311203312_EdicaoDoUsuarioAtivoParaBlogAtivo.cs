using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiBlogs.Migrations
{
    /// <inheritdoc />
    public partial class EdicaoDoUsuarioAtivoParaBlogAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioAtivo",
                table: "Blogs",
                newName: "BlogAtivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogAtivo",
                table: "Blogs",
                newName: "UsuarioAtivo");
        }
    }
}
