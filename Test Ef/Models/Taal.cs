using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Ef.Models;

[Table("Talen")]
public class Taal {
    [Key, StringLength(3), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required string TaalCode { get; set; }
    public required string Naam { get; set; }
    
    public ICollection<Land> Landen { get; set; } = [];
}