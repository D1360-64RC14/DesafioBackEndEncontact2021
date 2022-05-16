using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.PostDataClass;
using TesteBackendEnContact.PostDataClass.Interface;
using TesteBackendEnContact.DataClass;
using TesteBackendEnContact.DataClass.Interface;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger) {
            _logger = logger;
        }
    }
}
