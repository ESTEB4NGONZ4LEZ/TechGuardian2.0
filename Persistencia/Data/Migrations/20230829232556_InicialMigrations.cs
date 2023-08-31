using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "arl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NIT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arl", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "componente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "eps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NIT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eps", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_docuemento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_docuemento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_email", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_insidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_insidencia", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_telefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_telefono", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lugar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_area = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lugar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lugar_area_Id_area",
                        column: x => x.Id_area,
                        principalTable: "area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_pais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_Id_pais",
                        column: x => x.Id_pais,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "computador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_lugar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_computador_lugar_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "lugar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_departamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_Id_departamento",
                        column: x => x.Id_departamento,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "compo_compu",
                columns: table => new
                {
                    Id_computador = table.Column<int>(type: "int", nullable: false),
                    Id_tipo_componente = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compo_compu", x => new { x.Id_computador, x.Id_tipo_componente });
                    table.ForeignKey(
                        name: "FK_compo_compu_componente_Id_tipo_componente",
                        column: x => x.Id_tipo_componente,
                        principalTable: "componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compo_compu_computador_Id_computador",
                        column: x => x.Id_computador,
                        principalTable: "computador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_ciudad = table.Column<int>(type: "int", nullable: false),
                    Id_eps = table.Column<int>(type: "int", nullable: false),
                    Id_arl = table.Column<int>(type: "int", nullable: false),
                    Id_tipo_telefono = table.Column<int>(type: "int", nullable: false),
                    Id_tipo_email = table.Column<int>(type: "int", nullable: false),
                    Id_lugar = table.Column<int>(type: "int", nullable: false),
                    Id_tipo_documento = table.Column<int>(type: "int", nullable: false),
                    Id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_arl_Id_arl",
                        column: x => x.Id_arl,
                        principalTable: "arl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_ciudad_Id_ciudad",
                        column: x => x.Id_ciudad,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_eps_Id_eps",
                        column: x => x.Id_eps,
                        principalTable: "eps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_lugar_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "lugar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_rol_Id_rol",
                        column: x => x.Id_rol,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipo_docuemento_Id_tipo_documento",
                        column: x => x.Id_tipo_documento,
                        principalTable: "tipo_docuemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipo_email_Id_tipo_email",
                        column: x => x.Id_tipo_email,
                        principalTable: "tipo_email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipo_telefono_Id_tipo_telefono",
                        column: x => x.Id_tipo_telefono,
                        principalTable: "tipo_telefono",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_persona = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Carrera = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Diagonal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barrio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detalle = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_persona_Id_persona",
                        column: x => x.Id_persona,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Id_estado = table.Column<int>(type: "int", nullable: false),
                    Id_persona = table.Column<int>(type: "int", nullable: false),
                    Id_computador = table.Column<int>(type: "int", nullable: false),
                    Id_categoria = table.Column<int>(type: "int", nullable: false),
                    Id_tipo_insidencia = table.Column<int>(type: "int", nullable: false),
                    Id_lugar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_insidencia_categoria_Id_categoria",
                        column: x => x.Id_categoria,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidencia_computador_Id_computador",
                        column: x => x.Id_computador,
                        principalTable: "computador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidencia_estado_Id_estado",
                        column: x => x.Id_estado,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidencia_lugar_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "lugar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidencia_persona_Id_persona",
                        column: x => x.Id_persona,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidencia_tipo_insidencia_Id_tipo_insidencia",
                        column: x => x.Id_tipo_insidencia,
                        principalTable: "tipo_insidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_Id_departamento",
                table: "ciudad",
                column: "Id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_compo_compu_Id_tipo_componente",
                table: "compo_compu",
                column: "Id_tipo_componente");

            migrationBuilder.CreateIndex(
                name: "IX_computador_Id_lugar",
                table: "computador",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_Id_pais",
                table: "departamento",
                column: "Id_pais");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_Id_persona",
                table: "direccion",
                column: "Id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_insidencia_Id_categoria",
                table: "insidencia",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_insidencia_Id_computador",
                table: "insidencia",
                column: "Id_computador");

            migrationBuilder.CreateIndex(
                name: "IX_insidencia_Id_estado",
                table: "insidencia",
                column: "Id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_insidencia_Id_lugar",
                table: "insidencia",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_insidencia_Id_persona",
                table: "insidencia",
                column: "Id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_insidencia_Id_tipo_insidencia",
                table: "insidencia",
                column: "Id_tipo_insidencia");

            migrationBuilder.CreateIndex(
                name: "IX_lugar_Id_area",
                table: "lugar",
                column: "Id_area");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_arl",
                table: "persona",
                column: "Id_arl");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_ciudad",
                table: "persona",
                column: "Id_ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_eps",
                table: "persona",
                column: "Id_eps");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_lugar",
                table: "persona",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_rol",
                table: "persona",
                column: "Id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_tipo_documento",
                table: "persona",
                column: "Id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_tipo_email",
                table: "persona",
                column: "Id_tipo_email");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_tipo_telefono",
                table: "persona",
                column: "Id_tipo_telefono");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compo_compu");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "insidencia");

            migrationBuilder.DropTable(
                name: "componente");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "computador");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "tipo_insidencia");

            migrationBuilder.DropTable(
                name: "arl");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "eps");

            migrationBuilder.DropTable(
                name: "lugar");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "tipo_docuemento");

            migrationBuilder.DropTable(
                name: "tipo_email");

            migrationBuilder.DropTable(
                name: "tipo_telefono");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
