using LBS_API.Model;
using LBS_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LBS_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Load")]
    public class LoadController : Controller
    {
        private readonly ILoadRepository _loadRepository;
        public LoadController(ILoadRepository loadRepository)
        {
            _loadRepository = loadRepository;
        }
        // GET: api/Load
        [HttpGet]
        public IActionResult Get()
        {
            var loads = _loadRepository.GetLoads();
            return new OkObjectResult(loads);

        }

        // GET api/Load/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var load = _loadRepository.GetLoadById(id);
            return new OkObjectResult(load);

        }

        // POST api/Load
        [HttpPost]
        public IActionResult Post([FromBody] Load load)
        {
            using (var scope = new TransactionScope())
            {
                _loadRepository.InsertLoad(load);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id=load.Id },load);
            }
        }

        // PUT api/Load/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Load load)
        {
            if (load != null)
            {
                using (var scope = new TransactionScope())
                {
                    _loadRepository.UpdateLoad(load);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/Load/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _loadRepository.DeleteLoad(id);
            return new OkResult();
        }
    }
}
