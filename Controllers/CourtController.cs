using apiProject.Entities;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using OpenXmlPowerTools;
using Court = apiProject.Entities.Court;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiProject.Controllers
{
    [Route("GovernmentAuthorities /[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {

        static int count = 1;
        private static List<Court> court = new List<Court> { new Court { Id = 0, Name = "בית המשפט השלום", City = "Jerosulem", operatingH = new DateTime(2023, 09, 19) } };
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Court> Get()
        {
            return court;
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
            court.Add(newCourt);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Court newCourt)
        {
            var f = court.Find(x => x.Id == newCourt.Id);
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
            var f = court.Find(x => x.Id == id);
            if (f == null)
                return NotFound();
            court.Remove(f);
            return Ok(f);
        }
    }
}
