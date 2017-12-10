using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClassManagementSystem.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    school_name = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    province = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    gmt_create = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gmt_modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    icon = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    is_male = table.Column<int>(type: "TINYINT(1)", nullable: false),
                    user_name = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    number = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    user_password = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    phone_number = table.Column<string>(type: "CHAR(11)", nullable: false),
                    title = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    wechat_id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    gmt_create = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gmt_modified = table.Column<DateTime>(nullable: false),
                    school_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.UniqueConstraint("AK_Users_email", x => x.email);
                    table.UniqueConstraint("AK_Users_number", x => x.number);
                    table.UniqueConstraint("AK_Users_phone_number", x => x.phone_number);
                    table.UniqueConstraint("AK_Users_wechat_id", x => x.wechat_id);
                    table.ForeignKey(
                        name: "FK_Users_Schools_school_id",
                        column: x => x.school_id,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_school_id",
                table: "Users",
                column: "school_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
