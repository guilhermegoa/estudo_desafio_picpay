using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_user_ReceiverId",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_user_SenderId",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "transaction",
                newName: "sender_id");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "transaction",
                newName: "receiver_id");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_SenderId",
                table: "transaction",
                newName: "IX_transaction_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_ReceiverId",
                table: "transaction",
                newName: "IX_transaction_receiver_id");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 1, 22, 23, 31, 49, 469, DateTimeKind.Utc).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 1, 22, 23, 31, 49, 469, DateTimeKind.Utc).AddTicks(9665));

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_user_receiver_id",
                table: "transaction",
                column: "receiver_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_user_sender_id",
                table: "transaction",
                column: "sender_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_user_receiver_id",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_user_sender_id",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "sender_id",
                table: "transaction",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "receiver_id",
                table: "transaction",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_sender_id",
                table: "transaction",
                newName: "IX_transaction_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_receiver_id",
                table: "transaction",
                newName: "IX_transaction_ReceiverId");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 1, 22, 23, 29, 8, 192, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 1, 22, 23, 29, 8, 192, DateTimeKind.Utc).AddTicks(1887));

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_user_ReceiverId",
                table: "transaction",
                column: "ReceiverId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_user_SenderId",
                table: "transaction",
                column: "SenderId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
