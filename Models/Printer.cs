using SPM_API.Enumerations;

namespace SPM_API.Models
{
    public class Printer
    {
        public Guid PrinterId { get; set; }

        public string? PrinterName { get; set; }

        public string? PrinterCode { get; set; }

        public string? PrinterDescription { get; set; }

        public PrintType PrintType { get; set; }

        public bool? IsActive { get; set; }
    }
}
