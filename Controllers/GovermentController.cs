using Microsoft.AspNetCore.Mvc;
using Solid.Service;

using Goverment = Solid.Core.Entities.Goverment;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovermentController : ControllerBase
    {
        static int count = 1;
        private readonly GovermentService _GovermentService;
        public GovermentController(GovermentService govermentService)
        {
            _GovermentService = govermentService;
        }

        // GET: api/<ValuesController1>
        [HttpGet]
        public ActionResult<Goverment> Get()
        {
            return  Ok(_GovermentService.GetGoverment()) ;
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public ActionResult<Goverment> Get(int id)
        {
            var f = _GovermentService.GetGoverment().Find(x => x.Id == id);
            if (f == null)
                return NotFound();
             return f;
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] Goverment newGoverment)
        {
            newGoverment.Id = count++;
            _GovermentService.GetGoverment().Add(newGoverment);
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Goverment newGoverment)
        {
            var f = _GovermentService.GetGoverment().Find(x => x.Id == newGoverment.Id);
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
            var f = _GovermentService.GetGoverment().Find(x => x.Id ==id);
            if (f == null)
                return NotFound();
            _GovermentService.GetGoverment().Remove(f);
            return Ok();
        }
    }
}
