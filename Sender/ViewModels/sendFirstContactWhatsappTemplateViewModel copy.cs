
using Sender.Models;

namespace Sender.ViewModels
{
    public class sendRegisterViewModel
    {
        public required Guid UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required CustomAttributes CustomAttributes { get; set; }

    }
}
    