using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovermentController : ControllerBase
    {
        static int count = 1;
        static List<Goverment> goverment = new List<Goverment>{new Goverment {Id=0,Name="משה גפני",party="דגל התורה",IdParty=0 } };
        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<Goverment> Get()
        {
            return goverment;
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public ActionResult< Goverment>Get(int id)
        {
            var f = goverment.Find(x => x.Id == id);
            if (f == null)
                return NotFound();
             return f;
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] Goverment newGoverment)
        {
            newGoverment.Id = count++;
            goverment.Add(newGoverment);
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Goverment newGoverment)
        {
            var f = goverment.Find(x => x.Id == newGoverment.Id);
            if (f == null)
                return NotFound();
            f.Name=newGoverment.Name;
            f.IdParty=newGoverment.IdParty;
            f.party=newGoverment.party;
            return Ok();
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var f = goverment.Find(x => x.Id ==id);
            if (f == null)
                return NotFound();
           goverment.Remove(f);
            return Ok();
        }
    }
}
