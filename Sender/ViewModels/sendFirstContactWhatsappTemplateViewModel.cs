
using Sender.Models;

namespace Sender.ViewModels
{
    public class sendFirstContactWhatsappTemplateViewModel
    {
        public required string PhoneNumberTo { get; set; }
        public required string Language { get; set; }
        public required string TemplateName { get; set; }
        public required TemplateData TemplateData { get; set; }

    }
}
