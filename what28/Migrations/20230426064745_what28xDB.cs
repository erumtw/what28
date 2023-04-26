using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace what28.Migrations
{
    /// <inheritdoc />
    public partial class what28xDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenAmount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    PosterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverPosts_Accounts_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EaterPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PosterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EaterPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EaterPosts_Accounts_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliverPostId = table.Column<int>(type: "int", nullable: true),
                    OrdererId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_OrdererId",
                        column: x => x.OrdererId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliverPosts_DeliverPostId",
                        column: x => x.DeliverPostId,
                        principalTable: "DeliverPosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EaterPostAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EaterPostId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EaterPostAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EaterPostAccount_Accounts_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EaterPostAccount_EaterPosts_EaterPostId",
                        column: x => x.EaterPostId,
                        principalTable: "EaterPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliverPosts_PosterId",
                table: "DeliverPosts",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_EaterPostAccount_BuyerId",
                table: "EaterPostAccount",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EaterPostAccount_EaterPostId",
                table: "EaterPostAccount",
                column: "EaterPostId");

            migrationBuilder.CreateIndex(
                name: "IX_EaterPosts_PosterId",
                table: "EaterPosts",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliverPostId",
                table: "Orders",
                column: "DeliverPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdererId",
                table: "Orders",
                column: "OrdererId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EaterPostAccount");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "EaterPosts");

            migrationBuilder.DropTable(
                name: "DeliverPosts");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
