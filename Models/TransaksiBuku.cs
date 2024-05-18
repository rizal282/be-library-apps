using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apilibraryapps.Models;

[Table("transaksi_buku")]
public class TransaksiBuku
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("no_transaksi")]
    public string NoTransaksi { get; set; }

    [Column("tgl_pinjam")]
    public string TglPinjam { get; set; }

    [Column("tgl_kembali")]
    public string TglKembali { get; set; }

    [Column("lama_pinjam")]
    public int LamaPinjam { get; set; }

    [Column("id_buku")]
    public int IdBuku { get; set; }

    [Column("id_mhs")]
    public int IdMhs { get; set; }

    [Column("jml_pinjam")]
    public int JumlahPinjam { get; set; }

    public Buku? Buku { get; set; }

    public Mahasiswa? Mahasiswa{ get; set; }
}
