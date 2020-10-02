using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CentricaTestServer.DataAccess.DataAccessObjects;
using CentricaTestServer.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentricaTestServer.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly ILogger<DistrictController> _logger;

        public DistrictController(ILogger<DistrictController> logger)
        {
            _logger = logger;
        }

        // GET: api/<DistrictController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogDebug("Started: Getting all districts");

            IEnumerable<District> result;
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Getting all districts");
                return BadRequest("Failed: Getting all districts");
            }
            if (result.Count() == 0)
            {
                _logger.LogInformation("No districts in list");
            }

            _logger.LogDebug("Finished: Getting all districts");
            return Ok(result);
        }

        // GET api/<DistrictController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogDebug("Started: Getting district by ID: {id}", id);

            District result;
            DistrictDAO dao = new DistrictDAO();

            Guid tempId;

            if (!Guid.TryParse(id, out tempId)) 
            {
                _logger.LogWarning("{id} is not a valid Guid type", id);
                return BadRequest();
            }
            try
            {
                result = await dao.Get(id.ToString());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Getting district {id}", id);
                return BadRequest("Failed: Getting district");
            }
            if (result == null)
            {
                _logger.LogWarning("No district exists with that ID: {id}", id);
                return NotFound(result);
            }

            _logger.LogDebug("Finished: Getting district by ID: {id}", id);
            return Ok(result);
        }

        // POST api/<DistrictController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DistrictController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DistrictController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
