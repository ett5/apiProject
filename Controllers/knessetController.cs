using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Service;
using Knesst= Solid.Core.Entities.Knesset;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnessetController : ControllerBase
    {
        static int count = 1;
        private readonly KnessetService _KourtService;
        public KnessetController(KnessetService kourtService)
        {
            _KourtService = kourtService;
        }        // GET: api/<ValuesController2>
        [HttpGet]
        public ActionResult<Knesset> Get()
        {
            return Ok(_KourtService.Getknesset());
        }

        // GET api/<ValuesController2>/5
        [HttpGet("{id}")]
        public ActionResult <Knesset> Get(int id)
        {
            var f = _KourtService.Getknesset().Find(x => x.Id == id);
            if (f == null)
                return NotFound();
            return f;
        }

        // POST api/<ValuesController2>
        [HttpPost]
        public void Post([FromBody] Knesset newKnesset )
        {
            newKnesset.Id=count++;
            _KourtService.Getknesset().Add(newKnesset);
        }

        // PUT api/<ValuesController2>/5
        [HttpPut("{id}")]
        public ActionResult <Knesset>Put( [FromBody] Knesset newKnesset)
        {
            var f = _KourtService.Getknesset().Find(x => x.Id ==newKnesset.Id);
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
            var f = _KourtService.Getknesset().Find(x => x.Id ==id);
            if (f == null)
                return NotFound();
            _KourtService.Getknesset().Remove(f);
            return Ok();
        }
    }
}
