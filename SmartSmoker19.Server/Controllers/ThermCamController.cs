using Microsoft.AspNetCore.Mvc;
using SmartSmoker19.Server.Models.AltDbContext;
using SmartSmoker19.Server.Models.ViewModels;

namespace SmartSmoker19.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class ThermCamController : Controller
    {
        private readonly AltAppDbContext db;
        public ThermCamController(AltAppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<ThermCamController>
        [HttpGet("thermcams")]
        public ActionResult<IEnumerable<ThermCamVM>> Get()
        {
            if (ModelState.IsValid)
            {
                var result = db.thermcam
                    .Select(thermcamVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<ThermCamController>/5
        [HttpGet("thermcam/{id}")]
        public ActionResult<ThermCamVM> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var result = db.thermcam
                    .Where(e => e.id == id)
                    .Select(thermcamVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<ThermCamController>
        [HttpPost("thermcam")]
        public ActionResult<ThermCamVM> Post([FromBody] ThermCamVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id == 0)
                {
                    var item = value.AsPoco();
                    db.thermcam.Add(item);
                    db.SaveChanges();
                    var vm = item.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(value);
        }

        // PUT api/<ThermCamController>/5
        [HttpPut("thermcam/{id}")]
        public ActionResult<ThermCamVM> Put(int id, [FromBody] ThermCamVM value)
        {
            if (ModelState.IsValid)
            {
                var dbitem = db.thermcam
                    .Where(e => e.id == value.id)
                    .FirstOrDefault();
                if (dbitem != null)
                {
                    thermcamVmExts.GraphVM(value, ref dbitem);
                    db.SaveChanges();
                    var vm = dbitem.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(value);
        }

        // DELETE api/<ThermCamController>/5
        [HttpDelete("thermcam/{id}")]
        public ActionResult<ThermCamVM> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var dbitem = db.thermcam
                    .Where(e => e.id == id)
                    .FirstOrDefault();
                if (dbitem != null)
                {
                    db.thermcam.Remove(dbitem);
                    db.SaveChanges();
                    var vm = dbitem.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(id);
        }
    }
}
