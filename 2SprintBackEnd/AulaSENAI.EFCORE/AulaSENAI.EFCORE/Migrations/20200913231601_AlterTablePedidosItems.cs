﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace AulaSENAI.EFCORE.Migrations
{
    public partial class AlterTablePedidosItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PedidosItens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PedidosItens");
        }
    }
}
