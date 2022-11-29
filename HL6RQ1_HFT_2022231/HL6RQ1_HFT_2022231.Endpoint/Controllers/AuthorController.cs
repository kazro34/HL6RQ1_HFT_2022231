using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;
        public AuthorController(IAuthorLogic logic)
        {
            this.logic = logic;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Create([FromBody] Author value)
        {
            this.logic.Create(value);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Author value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<BookController>/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
