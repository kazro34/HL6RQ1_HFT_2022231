using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;
        public BookController(IBookLogic logic)
        {
            this.logic = logic;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.logic.Create(value);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Book value)
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
