using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : Controller
    {
        
        private IAdultsData iAdultsData;

        public AdultController(IAdultsData iAdultsData)
        {
            this.iAdultsData = iAdultsData;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = iAdultsData.GetAdults().ToList();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            Console.WriteLine("Heeeeeeeeeeeeeeeeeeeeeere");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = iAdultsData.addAdultTwo(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> RemoveAdult([FromRoute] int id)
        {
            try
            {
                iAdultsData.RemoveAdult(id);
                return Accepted($"/{id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
    
}