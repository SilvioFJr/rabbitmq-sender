namespace Sender.Models
{
    public class RegisterMessage
    {
        public required Guid UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required CustomAttributes CustomAttributes { get; set; }
    }

    public class CustomAttributes
    {
        public required string Cpf { get; set; }
        public required UserProfile UserProfile { get; set; }
        public required Group Group { get; set; }
    }

    public class UserProfile
    {
        public required Guid? PatientId { get; set; }
        public required Guid? DoctorId { get; set; }
        public required Guid? ReceptionistId { get; set; }
        public required Guid? HCAdminId { get; set; }
    }

    public class Group
    {
        public required Guid GroupId { get; set; }
        public required string GroupName { get; set; }
    }

}

