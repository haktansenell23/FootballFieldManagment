using FootballFieldManagmentAngularJS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;


namespace FootballFieldManagmentAngularJS.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ValuesApiController : ControllerBase
    {
        private readonly IOptions<RapidApi> rapidApi;

        public ValuesApiController(IOptions<RapidApi> rapidApi)
        {
            this.rapidApi = rapidApi;
        }

        [HttpGet]
        public IActionResult GetRapidApiKey()
        {
            var api = rapidApi.Value.ApiKey;
            var jsonApi = JsonSerializer.Serialize(api);

            return Ok(jsonApi);
        }
    

    }
}
