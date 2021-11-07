using Keygen.API.Domain;
using Keygen.API.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Keygen.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeygenController : ControllerBase
    {
        private readonly ILogger<KeygenController> _logger;

        public KeygenController(ILogger<KeygenController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<GenerateKeyResponse> GenerateKey([FromBody] GenerateKeyRequest request)
        {
            var response = new GenerateKeyResponse();

            try
            {
                var data = KeyGenerator.Generate(request);
                response.Data = data;
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                response.Errors.Add(msg);
            }

            return response;
        }
    }
}
