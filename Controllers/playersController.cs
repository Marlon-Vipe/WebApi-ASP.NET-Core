using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_players.Context;
using WebApi_players.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_players.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class playersController : ControllerBase
    {

        private readonly AppDBContext context;

        public playersController(AppDBContext context)
        {

            this.context = context;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.players.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetPlayers")]
        public ActionResult Get(int id)
        {
            try
            {
                var players = context.players.FirstOrDefault(f => f.id == id);
                return Ok(players); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<playersController>
        [HttpPost]
        public ActionResult Post([FromBody]players players)
        {
            try
            {
                context.players.Add(players);
                context.SaveChanges();
                return CreatedAtRoute("GetPlayers", new {id = players.id }, players);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]players players)
        {
             try
            {
                if(players.id == id)
                {
                    context.Entry(players).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPlayers", new { id = players.id }, players);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var players = context.players.FirstOrDefault(f => f.id == id);
                if(players != null)
                {
                    context.players.Remove(players);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
