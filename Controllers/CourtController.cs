
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Solid.Service;

using Court = Solid.Core.Entities.Court;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiProject.Controllers
{
    [Route("GovernmentAuthorities /[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {

        static int count = 1;
        private readonly CourtService _courtService;
        public CourtController(CourtService courtService)
        {
            _courtService = courtService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<Court> Get()
        {
            return Ok(_courtService.GetCourts());
        }

        // GET api/<ValuesController>/5
        //[HttpGet("{city}")]
        // public IEnumerable<Court> Get(string city)
        ///{
        //  List<Court> courtCity = new List<Court>;
        // return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Court newCourt)
        {newCourt.Id = count++;
            _courtService.GetCourts().Add(newCourt);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Court newCourt)
        {
            var f = _courtService.GetCourts().Find(x => x.Id == newCourt.Id);
            if (f == null)
                return NotFound();
            f.City = newCourt.City;
            f.Name = newCourt.Name;

            return Ok(f);

        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var f = _courtService.GetCourts().Find(x => x.Id == id);
            if (f == null)
                return NotFound();
            _courtService.GetCourts().Remove(f);
            return Ok(f);
        }
    }
}
