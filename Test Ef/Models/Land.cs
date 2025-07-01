using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Ef.Models;

[Table("Landen")]
public class Land {
    [Key]
    public int LandCode { get; set; }
    [StringLength(255)]
    public required string Naam { get; set; }

    public ICollection<Taal> Talen { get; set; } = [];
    
    public ICollection<Stad> Steden  { get; set; } = [];
}