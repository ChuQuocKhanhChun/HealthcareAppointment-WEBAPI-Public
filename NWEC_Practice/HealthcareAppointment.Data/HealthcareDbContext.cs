using Microsoft.EntityFrameworkCore;

public class HealthcareDbContext : DbContext
{
    public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cấu hình quan hệ giữa User và Appointment (Doctor và Patient)
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Thêm dữ liệu ban đầu cho User và Appointment
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com", DateOfBirth = new DateTime(1980, 1, 1), Password = "password", Role = "Patient" },
            new User { Id = 2, Name = "Jane Doe", Email = "janedoe@gmail.com", DateOfBirth = new DateTime(1985, 2, 1), Password = "password", Role = "Patient" },
            new User { Id = 3, Name = "Dr. Smith", Email = "drsmith@gmail.com", DateOfBirth = new DateTime(1975, 3, 1), Password = "password", Role = "Doctor", Specialization = "Cardiology" },
            new User { Id = 4, Name = "Dr. Brown", Email = "drbrown@gmail.com", DateOfBirth = new DateTime(1980, 4, 1), Password = "password", Role = "Doctor", Specialization = "Neurology" },
            new User { Id = 5, Name = "Dr. Adams", Email = "dradams@gmail.com", DateOfBirth = new DateTime(1985, 5, 1), Password = "password", Role = "Doctor", Specialization = "Pediatrics" }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { Id = 1, PatientId = 1, DoctorId = 3, Date = new DateTime(2024, 10, 11, 9, 0, 0), Status = "Scheduled" },
            new Appointment { Id = 2, PatientId = 2, DoctorId = 3, Date = new DateTime(2024, 10, 12, 10, 0, 0), Status = "Scheduled" },
            new Appointment { Id = 3, PatientId = 1, DoctorId = 4, Date = new DateTime(2024, 10, 13, 11, 0, 0), Status = "Completed" },
            new Appointment { Id = 4, PatientId = 2, DoctorId = 5, Date = new DateTime(2024, 10, 14, 12, 0, 0), Status = "Scheduled" },
            new Appointment { Id = 5, PatientId = 1, DoctorId = 5, Date = new DateTime(2024, 10, 15, 13, 0, 0), Status = "Cancelled" }
        );
    }
}
