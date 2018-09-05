using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VacationBiddingSite.Data.Migrations
{
    public partial class RemoveGetCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotel_city_GetCityid",
                table: "hotel");

            migrationBuilder.DropIndex(
                name: "IX_hotel_GetCityid",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "GetCityid",
                table: "hotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetCityid",
                table: "hotel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hotel_GetCityid",
                table: "hotel",
                column: "GetCityid");

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_city_GetCityid",
                table: "hotel",
                column: "GetCityid",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
