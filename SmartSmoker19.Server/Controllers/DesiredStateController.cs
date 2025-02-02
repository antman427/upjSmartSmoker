using Microsoft.AspNetCore.Mvc;
using SmartSmoker19.Server.Models.AltDbContext;
using SmartSmoker19.Server.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSmoker19.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class DesiredStateController : ControllerBase
    {
        private readonly AltAppDbContext db;
        public DesiredStateController(AltAppDbContext db)
        {
            this.db = db;
        }
        
        // GET: api/<DesiredStateController>
        [HttpGet("desiredstate")]
        public ActionResult<IEnumerable<DesiredStateVM>> Get()
        {
            if (ModelState.IsValid)
            {
                var result = db.desiredstate
                    .Select(DesiredStateVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<DesiredStateController>/5
        [HttpGet("desiredstate/{id}")]
        public ActionResult<DesiredStateVM> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var result = db.desiredstate
                    .Where(e => e.id == id)
                    .Select(DesiredStateVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound(id);
        }

        // Get current desired state
        [HttpGet("desiredstate/mostcurrent")]
        public ActionResult<DesiredStateVM> GetMostCurrent()
        {
            if (ModelState.IsValid)
            {
                var result = db.desiredstate
                    .OrderByDescending(e => e.id)
                    .Select(DesiredStateVmExts.ToVmSql)
                    .FirstOrDefault();
                return Ok(result);
            }
            return NotFound();
        }


        // POST api/<DesiredStateController>
        [HttpPost("desiredstate")]
        public ActionResult<DesiredStateVM> Post([FromBody] DesiredStateVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id == 0)
                {
                    var item = value.AsPoco();
                    db.desiredstate.Add(item);
                    db.SaveChanges();
                    var vm = item.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(value);
        }

        // PUT api/<DesiredStateController>/5
        [HttpPut("desiredstate/{id}")]
        public ActionResult<DesiredStateVM> Put([FromBody] DesiredStateVM value)
        {
            if (ModelState.IsValid)
            {
                var dbitem = db.desiredstate
                    .Where(e => e.id == value.id)
                    .FirstOrDefault();
                if (dbitem != null)
                {
                    DesiredStateVmExts.GraphVM(value, ref dbitem);
                    db.SaveChanges();
                    var vm = dbitem.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(value);
        }

        // DELETE api/<DesiredStateController>/5
        [HttpDelete("desiredstate/{id}")]
        public ActionResult<DesiredStateVM> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    var dbitem = db.desiredstate
                        .Where(e => e.id == id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        db.desiredstate.Remove(dbitem);
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
