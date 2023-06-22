using System.ComponentModel.DataAnnotations;

namespace SimpleContact.Models
{
    public class EmailDataModel
    {      
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }

    }
}
