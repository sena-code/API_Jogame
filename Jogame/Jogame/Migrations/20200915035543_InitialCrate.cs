﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogame.Migrations
{
    public partial class InitialCrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogosJogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdJogador = table.Column<Guid>(nullable: false),
                    IdJogo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosJogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosJogadores_Jogador_IdJogador",
                        column: x => x.IdJogador,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogosJogadores_Jogo_IdJogo",
                        column: x => x.IdJogo,
                        principalTable: "Jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogadores_IdJogador",
                table: "JogosJogadores",
                column: "IdJogador");

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogadores_IdJogo",
                table: "JogosJogadores",
                column: "IdJogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogosJogadores");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Jogo");
        }
    }
}
