using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Appointment
{
    public int Id { get; set; }

    [Required]
    public int PatientId { get; set; }

    [ForeignKey("PatientId")]
    public User Patient { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    public User Doctor { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Status { get; set; }  // "Scheduled", "Completed", "Cancelled"
}
