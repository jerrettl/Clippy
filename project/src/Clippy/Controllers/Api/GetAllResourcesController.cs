using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clippy.Data;
using Clippy.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace Clippy.Controllers.Api {
    public class GetAllResourcesController : ApiController {
        private readonly ClippyContext _context;

        public GetAllResourcesController(ClippyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Resource>> Get() {
            return await _context.GetResourcesAsync();
        }
    }
}

