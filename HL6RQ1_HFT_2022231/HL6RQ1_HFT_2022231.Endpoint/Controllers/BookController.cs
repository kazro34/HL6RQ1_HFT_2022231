using HL6RQ1_HFT_2022231.Endpoint.Services;
using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;
        IHubContext<SignalRHub> hub;
        public BookController(IBookLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public void Update([FromBody] Book value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);
        }

        // DELETE api/<BookController>/5
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BookToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", BookToDelete);
        }
    }
}
