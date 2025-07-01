using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Ef.Models;

[Table("Talen")]
public class Taal {
    [Key]
    public int TaalCode { get; set; }
    public required string Naam { get; set; }
}