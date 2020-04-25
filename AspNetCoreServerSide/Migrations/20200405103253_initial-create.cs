using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreServerSide.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemoNestedLevelTwoEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoNestedLevelTwoEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemoNestedLevelOneEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Experience = table.Column<short>(nullable: true),
                    Extn = table.Column<int>(nullable: true),
                    DemoNestedLevelTwoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoNestedLevelOneEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemoNestedLevelOneEntity_DemoNestedLevelTwoEntity_DemoNestedLevelTwoId",
                        column: x => x.DemoNestedLevelTwoId,
                        principalTable: "DemoNestedLevelTwoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: false),
                    Office = table.Column<string>(nullable: true),
                    DemoNestedLevelOneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demos_DemoNestedLevelOneEntity_DemoNestedLevelOneId",
                        column: x => x.DemoNestedLevelOneId,
                        principalTable: "DemoNestedLevelOneEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemoNestedLevelOneEntity_DemoNestedLevelTwoId",
                table: "DemoNestedLevelOneEntity",
                column: "DemoNestedLevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Demos_DemoNestedLevelOneId",
                table: "Demos",
                column: "DemoNestedLevelOneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demos");

            migrationBuilder.DropTable(
                name: "DemoNestedLevelOneEntity");

            migrationBuilder.DropTable(
                name: "DemoNestedLevelTwoEntity");
        }
    }
}
