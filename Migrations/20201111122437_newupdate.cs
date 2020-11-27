using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Vehicle.Migrations
{
    public partial class newupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Waybill_Vehicle_VehicleId",
                table: "Waybill");

            migrationBuilder.DropIndex(
                name: "IX_Waybill_VehicleId",
                table: "Waybill");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Waybill");

            migrationBuilder.AlterColumn<string>(
                name: "WaybilNumber",
                table: "Waybill",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaybillId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaybillId1",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_WaybillId",
                table: "Vehicle",
                column: "WaybillId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_WaybillId1",
                table: "Vehicle",
                column: "WaybillId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Waybill_WaybillId",
                table: "Vehicle",
                column: "WaybillId",
                principalTable: "Waybill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Waybill_WaybillId1",
                table: "Vehicle",
                column: "WaybillId1",
                principalTable: "Waybill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Waybill_WaybillId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Waybill_WaybillId1",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_WaybillId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_WaybillId1",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "WaybillId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "WaybillId1",
                table: "Vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "WaybilNumber",
                table: "Waybill",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Waybill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_VehicleId",
                table: "Waybill",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybill_Vehicle_VehicleId",
                table: "Waybill",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
