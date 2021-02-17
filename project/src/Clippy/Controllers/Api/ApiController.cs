using Microsoft.AspNetCore.Mvc;

namespace Clippy.Controllers.Api {
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ApiController : ControllerBase {}
}
