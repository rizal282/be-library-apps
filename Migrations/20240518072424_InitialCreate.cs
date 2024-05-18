using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace apilibraryapps.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventori",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nama_rak = table.Column<string>(type: "text", nullable: true),
                    deskripsi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventori", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mahasiswa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nim_mhs = table.Column<string>(type: "text", nullable: false),
                    nama_mhs = table.Column<string>(type: "text", nullable: false),
                    jurusan = table.Column<string>(type: "text", nullable: false),
                    aktif_flag = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahasiswa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "buku",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nama_buku = table.Column<string>(type: "text", nullable: false),
                    jenis_buku = table.Column<string>(type: "text", nullable: false),
                    penerbit = table.Column<string>(type: "text", nullable: false),
                    lokasi_rak = table.Column<int>(type: "integer", nullable: false),
                    stok_buku = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buku", x => x.id);
                    table.ForeignKey(
                        name: "FK_buku_inventori_lokasi_rak",
                        column: x => x.lokasi_rak,
                        principalTable: "inventori",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaksi_buku",
                columns: table => new
                {
                    id_buku = table.Column<int>(type: "integer", nullable: false),
                    id_mhs = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    no_transaksi = table.Column<string>(type: "text", nullable: false),
                    tgl_pinjam = table.Column<string>(type: "text", nullable: false),
                    tgl_kembali = table.Column<string>(type: "text", nullable: false),
                    lama_pinjam = table.Column<int>(type: "integer", nullable: false),
                    jml_pinjam = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaksi_buku", x => new { x.id_buku, x.id_mhs });
                    table.ForeignKey(
                        name: "FK_transaksi_buku_buku_id_buku",
                        column: x => x.id_buku,
                        principalTable: "buku",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaksi_buku_mahasiswa_id_mhs",
                        column: x => x.id_mhs,
                        principalTable: "mahasiswa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buku_lokasi_rak",
                table: "buku",
                column: "lokasi_rak");

            migrationBuilder.CreateIndex(
                name: "IX_transaksi_buku_id_mhs",
                table: "transaksi_buku",
                column: "id_mhs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaksi_buku");

            migrationBuilder.DropTable(
                name: "buku");

            migrationBuilder.DropTable(
                name: "mahasiswa");

            migrationBuilder.DropTable(
                name: "inventori");
        }
    }
}
