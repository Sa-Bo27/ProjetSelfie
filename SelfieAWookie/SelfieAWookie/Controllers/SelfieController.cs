using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Application.DTO_s;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System.Linq;

namespace SelfieAWookie.Controllers
{
    /// <summary>
    /// Objet qui représente le Controller, permet des requetes Http pour obtenir différente réponse a renvoyé a la vue
    /// </summary>
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        private readonly ISelfieRepository  _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        
        public SelfieController(ISelfieRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository; 
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("photo")]
        [HttpPost]
        public async Task<IActionResult> AddPictures(IFormFile picture)
        {
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, picture.FileName);

            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);

            var item = this._repository.AddOnePicture(filePath);
            
            this._repository.UnitOfWork.SaveChanges();

           
            return Ok(item);
        }

        [HttpPost]
        public IActionResult AddOne(SelfieDTO selfie)
        {
            IActionResult result = this.BadRequest();

            Selfie addSelfie = this._repository.AddOne(new Selfie()
            {
                ImagePath = selfie.ImagePath,
                Title = selfie.Title
            });
            this._repository.UnitOfWork.SaveChanges();

            if(addSelfie != null)
            {
                selfie.Id = addSelfie.Id;
                result = this.Ok(selfie);
            }


            return result;
        }



        //[HttpGet]
        //public IEnumerable<Selfie> GetSelfies()
        //{
        //    return Enumerable.Range(0, 10).Select(x => new Selfie() { Id = x });
        //}
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? wookieId)
        {
            var param = this.Request.Query["wookieId"]; // Permet de recuperer des element de la requete// 

            var selifeList = _repository.GetAll(wookieId);
            //var result = Enumerable.Range(1,10).Select(x => new Selfie() { Id = x });
            var model = selifeList
                .Select(
                    item => 
                            new SelfieResumeDTO() { 
                                 Id = item.Id, 
                                 Title = item.Title, 
                                 WookieId = item.Wookie.Id, 
                                 NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count()).GetValueOrDefault() })
                .ToList();               

            

            return Ok(model);
        }
    }
}
