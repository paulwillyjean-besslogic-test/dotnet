using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace app.Models;

[Index(nameof(SerialNumber), IsUnique = true)]
public class Aircraft
{
    [Key]
    public long RegistrationNumber { get; set; }
    [Required]
    public required string SerialNumber { get; set; }
    [Required]
    public required string ModelName { get; set; }
    [Required]
    public required RegistrationStatus RegistrationStatus { get; set; }
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime RegistrationDate { get; set; }
}