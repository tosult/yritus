using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.EF.App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IsikYrituselRollid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RollNimetus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsikYrituselRollid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JurIsikLiigid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LiikNimetus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurIsikLiigid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OsavotumaksuStaatused",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Staatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsavotumaksuStaatused", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasumiseViisid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ViisNimetus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasumiseViisid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yritused",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nimi = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Algus = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lopp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Asukoht = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yritused", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osavotumaksud",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OsavotumaksuStaatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TasumiseViisId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osavotumaksud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osavotumaksud_OsavotumaksuStaatused_OsavotumaksuStaatusId",
                        column: x => x.OsavotumaksuStaatusId,
                        principalTable: "OsavotumaksuStaatused",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osavotumaksud_TasumiseViisid_TasumiseViisId",
                        column: x => x.TasumiseViisId,
                        principalTable: "TasumiseViisid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Isikud",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OsavotumaksId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Eesnimi = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Perenimi = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Isikukood = table.Column<int>(type: "INTEGER", nullable: false),
                    Lisainfo = table.Column<string>(type: "TEXT", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isikud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Isikud_Osavotumaksud_OsavotumaksId",
                        column: x => x.OsavotumaksId,
                        principalTable: "Osavotumaksud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JurIsikud",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OsavotumaksId = table.Column<Guid>(type: "TEXT", nullable: false),
                    JurIsikLiikId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nimi = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Registrikood = table.Column<int>(type: "INTEGER", nullable: false),
                    Lisainfo = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurIsikud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JurIsikud_JurIsikLiigid_JurIsikLiikId",
                        column: x => x.JurIsikLiikId,
                        principalTable: "JurIsikLiigid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JurIsikud_Osavotumaksud_OsavotumaksId",
                        column: x => x.OsavotumaksId,
                        principalTable: "Osavotumaksud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IsikudYritusel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    YritusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsikId = table.Column<Guid>(type: "TEXT", nullable: true),
                    JurIsikId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsikudYritusel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsikudYritusel_Isikud_IsikId",
                        column: x => x.IsikId,
                        principalTable: "Isikud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsikudYritusel_JurIsikud_JurIsikId",
                        column: x => x.JurIsikId,
                        principalTable: "JurIsikud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsikudYritusel_Yritused_YritusId",
                        column: x => x.YritusId,
                        principalTable: "Yritused",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Isikud_OsavotumaksId",
                table: "Isikud",
                column: "OsavotumaksId");

            migrationBuilder.CreateIndex(
                name: "IX_IsikudYritusel_IsikId",
                table: "IsikudYritusel",
                column: "IsikId");

            migrationBuilder.CreateIndex(
                name: "IX_IsikudYritusel_JurIsikId",
                table: "IsikudYritusel",
                column: "JurIsikId");

            migrationBuilder.CreateIndex(
                name: "IX_IsikudYritusel_YritusId",
                table: "IsikudYritusel",
                column: "YritusId");

            migrationBuilder.CreateIndex(
                name: "IX_JurIsikud_JurIsikLiikId",
                table: "JurIsikud",
                column: "JurIsikLiikId");

            migrationBuilder.CreateIndex(
                name: "IX_JurIsikud_OsavotumaksId",
                table: "JurIsikud",
                column: "OsavotumaksId");

            migrationBuilder.CreateIndex(
                name: "IX_Osavotumaksud_OsavotumaksuStaatusId",
                table: "Osavotumaksud",
                column: "OsavotumaksuStaatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Osavotumaksud_TasumiseViisId",
                table: "Osavotumaksud",
                column: "TasumiseViisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsikudYritusel");

            migrationBuilder.DropTable(
                name: "IsikYrituselRollid");

            migrationBuilder.DropTable(
                name: "Isikud");

            migrationBuilder.DropTable(
                name: "JurIsikud");

            migrationBuilder.DropTable(
                name: "Yritused");

            migrationBuilder.DropTable(
                name: "JurIsikLiigid");

            migrationBuilder.DropTable(
                name: "Osavotumaksud");

            migrationBuilder.DropTable(
                name: "OsavotumaksuStaatused");

            migrationBuilder.DropTable(
                name: "TasumiseViisid");
        }
    }
}
