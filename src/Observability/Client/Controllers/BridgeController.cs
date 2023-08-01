namespace Client.Controllers
{
    using Core.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;

    [ApiController]
    [Route("[controller]")]
    public class BridgeController : ControllerBase
    {
        [HttpGet("get-animals")]
        public async Task<IEnumerable<Animal>> Index()
        {
            using var webClient = new HttpClient();
            return await webClient.GetFromJsonAsync<IEnumerable<Animal>>("https://localhost:7227/Animal/get");
        }
    }
}
