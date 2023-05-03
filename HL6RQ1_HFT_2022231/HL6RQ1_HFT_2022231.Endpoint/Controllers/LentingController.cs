using HL6RQ1_HFT_2022231.Endpoint.Services;
using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LentingController : ControllerBase
    {
        ILentingLogic logic;
        IHubContext<SignalRHub> hub;
        public LentingController(ILentingLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("LentingCreated",value);
        }

        // PUT api/<LentingController>/5
        [HttpPut]
        public void Update([FromBody] Lenting value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("LentingUpdated",value);
        }

        // DELETE api/<LentingController>/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var LentingToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("LentingDeleted", LentingToDelete);
        }
    }
}
