using Ecorp.BackendDemo.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ecorp.BackendDemo.WebApi.Controllers
{
    [ApiController]
    [Route("system-informations")]
    public class SystemInformationController : ControllerBase
    {
        [HttpGet(Name = "GetSystemInformation")]
        public SystemInformationDto Toto()
        {
            return new SystemInformationDto
            {
                MachineName = Environment.MachineName,
                ProcessorArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),
                FrameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                RuntimeIdentifier = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier
            };
        }
    }
}
