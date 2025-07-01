using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Ef.Models;

[Table("Steden")]
public class Stad {
    [Key, Column("StadNr")]
    public int StadNummer { get; set; }
    public required string Naam { get; set; }
    
    [ForeignKey("LandCode")]
    public int LandCode { get; set; }
}