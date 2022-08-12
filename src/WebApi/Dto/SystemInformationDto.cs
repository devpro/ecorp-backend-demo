using System.Runtime.InteropServices;

namespace Ecorp.BackendDemo.WebApi.Dto
{
    public class SystemInformationDto
    {
        public string MachineName { get; set; } = string.Empty;
        public string ProcessorArchitecture { get; internal set; } = string.Empty;
        public string FrameworkDescription { get; internal set; } = string.Empty;
        public string RuntimeIdentifier { get; internal set; } = string.Empty;
    }
}
