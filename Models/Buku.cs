using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apilibraryapps.Models;

[Table("buku")]
public class Buku
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("nama_buku")]
    public String NamaBuku { get; set; }

    [Column("jenis_buku")]
    public String JenisBuku { get; set; }

    [Column("penerbit")]
    public String Penerbit { get; set; }

    [Column("lokasi_rak")]
    public int LokasiRak { get; set; }

    [Column("stok_buku")]
    public long StokBuku { get; set; }

    public ICollection<TransaksiBuku>? TransaksiBukus { get; set; }
}