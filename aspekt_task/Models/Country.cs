using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspekt_task.Models;

public class Country
{
    [Key]
    public int CountryId { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string CountryName { get; set; }

    public List<Contact> Contacts { get; set; } = new List<Contact>();  
}