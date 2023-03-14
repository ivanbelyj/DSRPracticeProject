using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSRPracticeProject.Api.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Gets test data
        /// </summary>
        /// <response code="200">String</response>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ApiVersion("1.0")]
        [HttpGet("")]
        public async Task<IEnumerable<string>> Get1_0()
        {
            return new[] { "Sheaneim Esae!", "Hello world!", "Привет, мир!" };
        }

        /// <summary>
        /// Gets test data
        /// </summary>
        /// <response code="200">String</response>
        [ProducesResponseType(typeof(string), 200)]
        [ApiVersion("1.1")]
        [HttpGet("")]
        public string Get1_1()
        {
            return "Peanoam!";
        }
    }
}
