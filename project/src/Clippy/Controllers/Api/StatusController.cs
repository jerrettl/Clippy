using Microsoft.AspNetCore.Mvc;

namespace Clippy.Controllers.Api {
    public class StatusController : ApiController {
        [HttpGet]
        public string Get() {
            return "Ok";
        }
    }
}
