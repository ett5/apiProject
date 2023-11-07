using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnessetController : ControllerBase
    {
        static int count = 1;
        static List<Knesset> knesset = new List<Knesset> { new Knesset { Id = 0, name = "דגל התורה", IsCoalition = true } };
        // GET: api/<ValuesController2>
        [HttpGet]
        public IEnumerable<Knesset> Get()
        {
            return knesset;
        }

        // GET api/<ValuesController2>/5
        [HttpGet("{id}")]
        public ActionResult <Knesset> Get(int id)
        {
            var f = knesset.Find(x => x.Id == id);
            if (f == null)
                return NotFound();
            return f;
        }

        // POST api/<ValuesController2>
        [HttpPost]
        public void Post([FromBody] Knesset newKnesset )
        {
            newKnesset.Id=count++;
            knesset.Add(newKnesset);
        }

        // PUT api/<ValuesController2>/5
        [HttpPut("{id}")]
        public ActionResult <Knesset>Put( [FromBody] Knesset newKnesset)
        {
            var f = knesset.Find(x => x.Id ==newKnesset.Id);
            if (f == null)
                return NotFound();
            f.IsCoalition = newKnesset.IsCoalition;
            f.name = newKnesset.name;

            return Ok();
        }

        // DELETE api/<ValuesController2>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var f = knesset.Find(x => x.Id ==id);
            if (f == null)
                return NotFound();
            knesset.Remove(f);
            return Ok();
        }
    }
}
