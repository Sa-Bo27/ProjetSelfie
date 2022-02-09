using Microsoft.AspNetCore.Mvc;
using SelfieAWookies.Core.Selfies.Domain;

namespace SelfieAWookie.Controllers
{
    /// <summary>
    /// Objet qui représente le Controller, permet des requetes Http pour obtenir différente réponse a renvoyé a la vue
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<Selfie> GetSelfies()
        //{
        //    return Enumerable.Range(0, 10).Select(x => new Selfie() { Id = x });
        //}
        [HttpGet]
        public IActionResult Test()
        {
            var result = Enumerable.Range(1,10).Select(x => new Selfie() { Id = x });
           
            return Ok(result);
        }
    }
}
