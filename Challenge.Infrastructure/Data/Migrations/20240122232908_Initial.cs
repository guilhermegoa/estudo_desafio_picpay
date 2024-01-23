using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Challenge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    document = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    balance = table.Column<double>(type: "REAL", nullable: false),
                    user_type = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceiverId = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_user_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaction_user_SenderId",
                        column: x => x.SenderId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "balance", "created_at", "document", "email", "name", "password", "user_type" },
                values: new object[,]
                {
                    { 1, 1000.0, new DateTime(2024, 1, 22, 23, 29, 8, 192, DateTimeKind.Utc).AddTicks(1878), "123456789", "usuario1@example.com", "Usuário 1", "senha1", 0 },
                    { 2, 500.0, new DateTime(2024, 1, 22, 23, 29, 8, 192, DateTimeKind.Utc).AddTicks(1887), "987654321", "usuario2@example.com", "Usuário 2", "senha2", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_ReceiverId",
                table: "transaction",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_SenderId",
                table: "transaction",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_user_document",
                table: "user",
                column: "document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
