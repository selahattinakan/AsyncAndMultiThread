using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("istek başladı");

                //Thread.Sleep(5000); // Task Cancellation örneği için eklendi

                await Task.Delay(5000, token); // eğer bir sayfa kapansa bile metot çalışmaya devam ediyordu, async metota cancellation token gönderirsek task sayfanın kapanmasıyla birlikte iptal olur

                var mytask = new HttpClient().GetStringAsync("https://www.google.com");


                // can do something


                var data = await mytask;

                _logger.LogInformation("istek bitti");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("istek iptal edildi");
                return BadRequest();
            }
        }
    }
}
