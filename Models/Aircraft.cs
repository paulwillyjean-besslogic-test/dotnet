using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace app.Models;

[Index(nameof(SerialNumber), IsUnique = true)]
public class Aircraft
{
    [Key]
    public long RegistrationNumber { get; set; }
    public string SerialNumber { get; set; } = String.Empty;
    public string ModelName { get; set; } = String.Empty;
    public RegistrationStatus RegistrationStatus { get; set; } = RegistrationStatus.Pending;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}