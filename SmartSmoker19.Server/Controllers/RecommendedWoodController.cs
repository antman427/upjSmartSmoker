using Microsoft.AspNetCore.Mvc;
using SmartSmoker19.Server.Models.AltDbContext;
using SmartSmoker19.Server.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSmoker19.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class RecommendedWoodController : ControllerBase
    {
        private readonly AltAppDbContext db;
        public RecommendedWoodController(AltAppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<RecommendedWoodController>
        [HttpGet("recommendedwood")]
        public ActionResult<IEnumerable<RecommendedWoodVM>> Get()
        {
            if (ModelState.IsValid)
            {
                var result = db.recommendedwood
                    .Select(RecommendedWoodVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<RecommendedWoodController>/5
        [HttpGet("recommendedwood/{id}")]
        public ActionResult<RecommendedWoodVM> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var result = db.recommendedwood
                    .Where(e => e.id == id)
                    .Select(RecommendedWoodVmExts.ToVmSql)
                    .AsEnumerable();
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<RecommendedWoodController>
        [HttpPost("recommendedwood")]
        public ActionResult<RecommendedWoodVM> Post([FromBody] RecommendedWoodVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id == 0)
                {
                    var item = value.AsPoco();
                    db.recommendedwood.Add(item);
                    db.SaveChanges();
                    var vm = item.AsVM();
                    return Ok(vm);
                }
            }
            return NotFound(value);
        }

        // PUT api/<RecommendedWoodController>/5
        [HttpPut("recommendedwood/{id}")]
        public ActionResult<RecommendedWoodVM> Put([FromBody] RecommendedWoodVM value)
        {
            if (ModelState.IsValid)
            {
                if (value.id > 0)
                {
                    var dbitem = db.recommendedwood
                        .Where(e => e.id == value.id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        RecommendedWoodVmExts.GraphVM(value, ref dbitem);
                        db.SaveChanges();
                        var vm = dbitem.AsVM();
                        return Ok(vm);
                    }
                }
            }
            return NotFound(value);
        }

        // DELETE api/<RecommendedWoodController>/5
        [HttpDelete("recommendedwood/{id}")]
        public ActionResult<RecommendedWoodVM> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    var dbitem = db.recommendedwood
                        .Where(e => e.id == id)
                        .FirstOrDefault();
                    if (dbitem != null)
                    {
                        db.recommendedwood.Remove(dbitem);
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
