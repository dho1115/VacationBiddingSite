using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VacationBiddingSite.Data.Migrations
{
    public partial class AddedGetCountryTocity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetCountryid",
                table: "city",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_GetCountryid",
                table: "city",
                column: "GetCountryid");

            migrationBuilder.AddForeignKey(
                name: "FK_city_country_GetCountryid",
                table: "city",
                column: "GetCountryid",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_country_GetCountryid",
                table: "city");

            migrationBuilder.DropIndex(
                name: "IX_city_GetCountryid",
                table: "city");

            migrationBuilder.DropColumn(
                name: "GetCountryid",
                table: "city");
        }
    }
}
