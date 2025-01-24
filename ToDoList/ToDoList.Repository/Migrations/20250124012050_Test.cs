using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Users] ([Id],[Name],[Email],[Password],[Role],[Status]) VALUES (NEWID(), 'Administrador', 'admin@gmail.com', '123456', 1, 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Users] WHERE [Name] = 'Administrador'");
        }
    }
}
