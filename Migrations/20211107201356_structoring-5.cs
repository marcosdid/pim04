using Microsoft.EntityFrameworkCore.Migrations;

namespace pim04.Migrations
{
    public partial class structoring5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_MetodoPagamentos_MetodoPagamentoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_MetodoPagamentoId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "MetodoPagamentoId",
                table: "Reservas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MetodoPagamentoId",
                table: "Reservas",
                column: "MetodoPagamentoId",
                unique: true,
                filter: "[MetodoPagamentoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_MetodoPagamentos_MetodoPagamentoId",
                table: "Reservas",
                column: "MetodoPagamentoId",
                principalTable: "MetodoPagamentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_MetodoPagamentos_MetodoPagamentoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_MetodoPagamentoId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "MetodoPagamentoId",
                table: "Reservas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MetodoPagamentoId",
                table: "Reservas",
                column: "MetodoPagamentoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_MetodoPagamentos_MetodoPagamentoId",
                table: "Reservas",
                column: "MetodoPagamentoId",
                principalTable: "MetodoPagamentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
