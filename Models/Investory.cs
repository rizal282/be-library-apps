using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apilibraryapps.Models;

[Table("inventori")]
public class Inventory 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("nama_rak")]
    public String NamaRak { get; set; }

    [Column("deskripsi")]
    public String Deskripsi { get; set; }

    public ICollection<Buku>? Buku { get; set; }
}