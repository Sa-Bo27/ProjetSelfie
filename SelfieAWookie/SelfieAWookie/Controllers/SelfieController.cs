using Microsoft.AspNetCore.Mvc;

namespace SelfieAWookie.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Selfie> GetSelfies()
        {
            return Enumerable.Range(0, 10).Select(x => new Selfie() { Id = x });
        }
    }
}
