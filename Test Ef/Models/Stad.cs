using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Ef.Models;

[Table("Steden")]
public class Stad {
    [Key, Column("StadNr")]
    public int StadNummer { get; set; }
    [StringLength(255)]
    public required string Naam { get; set; }
    
    [ForeignKey("Land")]
    public required string LandCode { get; set; }
    public Land Land { get; set; }
}