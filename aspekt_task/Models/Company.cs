using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspekt_task.Models;

public class Company
{
    [Key]
    public int CompanyId { get; set; }
    //postgesql doesn't recognise nvarchar
    [Column(TypeName = "varchar(255)")]
    public string CompanyName { get; set; }
    public List<Contact> Contacts { get; set; } = new List<Contact>();

}