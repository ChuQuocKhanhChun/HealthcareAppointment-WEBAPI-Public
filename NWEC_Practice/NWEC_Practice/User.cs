using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; }  // "Doctor" or "Patient"

    public string? Specialization { get; set; } // Optional, only for doctors
}
