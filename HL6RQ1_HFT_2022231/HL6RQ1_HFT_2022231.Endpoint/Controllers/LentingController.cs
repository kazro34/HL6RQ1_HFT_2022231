﻿using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LentingController : ControllerBase
    {
        ILentingLogic logic;
        public LentingController(ILentingLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Lenting> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Lenting Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Lenting value)
        {
            this.logic.Create(value);
        }
        [HttpPut]
        public void Put([FromBody] Lenting value)
        {
            this.logic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}