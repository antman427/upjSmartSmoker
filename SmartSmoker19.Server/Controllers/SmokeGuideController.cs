using Microsoft.AspNetCore.Mvc;
using SmartSmoker19.Server.Models.AltDbContext;
using SmartSmoker19.Server.Models.ViewModels;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSmoker19.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class SmokeGuideController : ControllerBase
    {
        private readonly AltAppDbContext db;
        public SmokeGuideController(AltAppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<SmokeGuideController>
        [HttpGet("meatsmokingguides")]
        public ActionResult<IEnumerable<MeatSmokingGuideVM>> Get()
        {
            if (ModelState.IsValid)
            {
                var result = db.meatsmokingguide
                    .Select(meatsmokingguideVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<SmokeGuideController>/5
        [HttpGet("meatsmokingguide/{id}")]
        public ActionResult<MeatSmokingGuideVM> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var result = db.meatsmokingguide
                    .Where(e => e.id == id)
                    .Select(meatsmokingguideVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound(id);
        }

        // GET api/<SmokeGuideController>/5
        [HttpGet("meatsmokingguide/{meattype}/{meatcut}")]
        public ActionResult<MeatSmokingGuideVM> GetbyMeattypeCut(string meattype, string meatcut)
        {
            if (ModelState.IsValid)
            {
                var result = db.meatwood
                    .Where(e => e.meattype == meattype && e.meatcut == meatcut)
                    .Select(MeatWoodVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound(meattype);
        }

        // POST api/<SmokeGuideController>
        [HttpPost("meatsmokingguide")]
        public ActionResult<MeatSmokingGuideVM> Post([FromBody] MeatSmokingGuideVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id == 0)
                {
                    var item = value.AsPoco();
                    db.meatsmokingguide.Add(item);
                    db.SaveChanges();
                    var vm = item.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(value);
        }

        // PUT api/<SmokeGuideController>/5
        [HttpPut("meatsmokingguide/{id}")]
        public ActionResult<MeatSmokingGuideVM> Put([FromBody] MeatSmokingGuideVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id > 0)
                {
                    var dbitem = db.meatsmokingguide
                        .Where(e => e.id == value.id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        meatsmokingguideVmExts.GraphVM(value, ref dbitem);
                        db.SaveChanges();
                        var vm = dbitem.AsVM();
                        return Ok(vm);
                    }
                }
            }
            return NotFound(value);
        }

        // DELETE api/<SmokeGuideController>/5
        [HttpDelete("meatsmokingguide/{id}")]
        public ActionResult<MeatSmokingGuideVM> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    var dbitem = db.meatsmokingguide
                        .Where(e => e.id == id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        db.meatsmokingguide.Remove(dbitem);
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
