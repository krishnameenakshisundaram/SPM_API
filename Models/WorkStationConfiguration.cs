using System.Reflection;

namespace SPM_API.Models
{
    public class WorkStationConfiguration
    {
        public Guid WorkStationId { get; set; }

        public string? WorkStationName { get; set; }

        public string? WorkStationCode { get; set; }

        public string? WorkStationDescription { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Printer>? Printers { get; set; }
    }
}
