using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspekt_task.Models;

public class Contact
{
    [Key]
    public int ContactId { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string ContactName { get; set; }
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    [ForeignKey("Country")] 
    public int CountryId { get; set; }

}   