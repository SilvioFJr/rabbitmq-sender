using System.ComponentModel.DataAnnotations;

namespace Sender.Models
{
    public class TemplateMessage
    {
        [Required]
        [MaxLength(50)]
        public required string TemplateName { get; set; }

        public required TemplateData? TemplateData { get; set; }
        [Required]
        public required string PhoneNumberTo { get; set; }

         public required string Language { get; set; }
    }

    public class TemplateData
    {
        public Dictionary<string, string>? Body { get; set; }

        public Dictionary<string, Button>? Buttons { get; set; }

        public Header? Header { get; set; }
    }

    public class Button
    {
        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Parameter { get; set; }
    }

    public class Header
    {
        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Placeholder { get; set; }
    }

}
