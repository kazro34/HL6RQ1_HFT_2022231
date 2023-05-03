using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LentingController : ControllerBase
    {
        ILentingLogic logic;
        public LentingController(ILentingLogic logic)
        {
            this.logic = logic;
        }
        // GET: api/<LentingController>
        [HttpGet]
        public IEnumerable<Lenting> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<LentingController>/5
        [HttpGet("{id}")]
        public Lenting Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<LentingController>
        [HttpPost]
        public void Create([FromBody] Lenting value)
        {
            this.logic.Create(value);
        }

        // PUT api/<LentingController>/5
        [HttpPut]
        public void Update([FromBody] Lenting value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<LentingController>/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
