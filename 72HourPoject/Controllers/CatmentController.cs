using Meow.Models;
using Meow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _72HourPoject.Controllers
{
    [Authorize]
    [RoutePrefix("api/catment")]
    public class CatmentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CatmentService catmentService = CreateCatmentService();
            var catments = catmentService.GetComments();
            return Ok(catments);
        }

        public IHttpActionResult Post(CatmentCreate catment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatmentService();
            return InternalServerError();

            return Ok();
        }

    public CatmentService CreateCatmentService()
        {
            var userId = Guid.Parse(User.Identity.GetAuthorId());
            var catmentService = new CatmentService(authorId);
            return catmentService;
        }

        public IHttpActionResult Get(int id)
        {
            CatmentService catmentService = CreateCatmentService();
            var catments = catmentService.GetCatmentById(id);
            return Ok(catments); 
        }

        public IHttpActionResult Put(CatmentEdit catment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatmentService();

            if (!service.UpdateCatment(catment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCatmentService();

            if (!service.DeleteCatment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
