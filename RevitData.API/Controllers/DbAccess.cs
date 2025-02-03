using Microsoft.AspNetCore.Mvc;
using RevitData.Infrastructure;
using Newtonsoft.Json;

namespace RevitData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbAccess : ControllerBase
    {
        private readonly DataAccess _dataAccess;

        public DbAccess(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/<DbAccess>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DbAccess>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DbAccess>
        [HttpPost]
        public void Post([FromBody] Test value)
        {
            _dataAccess.InsertDocumentAsync("testt", value).Wait();
        }

        // PUT api/<DbAccess>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DbAccess>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
