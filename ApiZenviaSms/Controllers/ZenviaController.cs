using EnvioSMS;
using Microsoft.AspNetCore.Mvc;

namespace ApiZenviaSms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZenviaController : ControllerBase
    {

        private readonly ILogger<ZenviaController> _logger;

        public ZenviaController(ILogger<ZenviaController> logger)
        {
            _logger = logger;
        }


        [HttpPost(Name = "ZenviaController")]
 
        public string Post([FromBody] ZenviaRequest atendimento)
        {
            EnvioSMSServices envioSMSServices = new EnvioSMSServices();

            return envioSMSServices.EnviarSMS(atendimento);

           

        }
    }
}