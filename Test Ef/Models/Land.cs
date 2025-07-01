using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Ef.Models;

[Table("Landen")]
public class Land {
    [Key]
    public int LandCode { get; set; }
    public required string Naam { get; set; }
}