using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apilibraryapps.Models;

[Table("mahasiswa")]
public class Mahasiswa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("nim_mhs")]
    public String NimMhs { get; set; }

    [Column("nama_mhs")]
    public String NamaMhs { get; set; }

    [Column("jurusan")]
    public String Jurusan  { get; set; }   

    [Column("aktif_flag")] 
    public bool AktifFlag { get; set; } = true;

    public ICollection<TransaksiBuku>? TransaksiBukus { get; set; }
}