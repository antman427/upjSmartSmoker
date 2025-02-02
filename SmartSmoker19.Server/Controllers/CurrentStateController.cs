using Microsoft.AspNetCore.Mvc;
using SmartSmoker19.Server.Models.AltDbContext;
using SmartSmoker19.Server.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSmoker19.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class CurrentStateController : ControllerBase
    {
        private readonly AltAppDbContext db;
        public CurrentStateController(AltAppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<CurrentStateController>
        [HttpGet("currentstate")]
        public ActionResult<IEnumerable<CurrentStateVM>> Get()
        {
            if (ModelState.IsValid)
            {
                var result = db.currentstate
                    .Select(CurrentStateVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<CurrentStateController>/5
        [HttpGet("currentstate/{id}")]
        public ActionResult<CurrentStateVM> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var result = db.currentstate
                    .Where(e => e.id == id)
                    .Select(CurrentStateVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<CurrentStateController>
        [HttpPost("currentstate")]
        public ActionResult<CurrentStateVM> Post([FromBody] CurrentStateVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id == 0)
                {
                    var item = value.AsPoco();
                    db.currentstate.Add(item);
                    db.SaveChanges();
                    var vm = item.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound();
        }

        // PUT api/<CurrentStateController>/5
        [HttpPut("currentstate{id}")]
        public ActionResult<CurrentStateVM> Put([FromBody] CurrentStateVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id > 0)
                {
                    var dbitem = db.currentstate
                        .Where(e => e.id == value.id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        CurrentStateVmExts.GraphVM(value, ref dbitem);
                        db.SaveChanges();
                        var vm = dbitem.AsVM();
                        return Ok(vm);
                    }
                }
            }
            return NotFound(value);
        }

        // DELETE api/<CurrentStateController>/5
        [HttpDelete("currentstate/{id}")]
        public ActionResult<CurrentStateVM> Delete(int id)
        {
            if (ModelState.IsValid) {
                if (id > 0)
                {
                    var dbitem = db.currentstate
                        .Where(e => e.id == id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        db.currentstate.Remove(dbitem);
                        db.SaveChanges();
                        var vm = dbitem.AsVM();
                        return Ok(vm);
                    }
                }
            }
            return NotFound(id);
        }
    }
}
