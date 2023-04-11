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
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;
        IHubContext<SignalRHub> hub;
        public AuthorController(IAuthorLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("AuthorCreated", value);
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        public void Put([FromBody] Author value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AuthorUpdated", value);
        }

        // DELETE api/<BookController>/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var AuthorToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", AuthorToDelete);
        }
    }
}
