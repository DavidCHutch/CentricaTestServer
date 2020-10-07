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
    //[Authorize]
    [AllowAnonymous]
    [Route("Centrica/api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly ILogger<DistrictController> _logger;

        public DistrictController(ILogger<DistrictController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets all districts
        /// </summary>
        /// <returns></returns>
        // GET: api/<DistrictController>/GetAll
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

        /// <summary>
        /// Gets a specific district by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET api/<DistrictController>/{id}
        [HttpGet("{id:guid}")]
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

        /// <summary>
        /// Gets all salesman in a specific district
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/<DistrictController>/{id}/GetAllSalesman
        [HttpGet("{id:guid}/GetAllSalesman")]
        public async Task<IActionResult> GetAllSalesman(string id)
        {
            _logger.LogDebug("Started: Getting all salesman in district");

            IEnumerable<Salesman> result;
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.GetAllSalesmanInDistrict(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Getting all salesman in district");
                return BadRequest("Failed: Getting all salesman in district");
            }
            if (result.Count() == 0)
            {
                _logger.LogInformation("No salesman in list");
            }

            _logger.LogDebug("Finished: Getting all salesman in district");
            return Ok(result);
        }

        /// <summary>
        /// Gets all salesman in a specific district
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/<DistrictController>/{id}/GetAllSalesman
        [HttpGet("{id:guid}/GetAllForeignSalesman")]
        public async Task<IActionResult> GetAllForeignSalesman(string id)
        {
            _logger.LogDebug("Started: Getting all salesman outside district");

            IEnumerable<Salesman> result;
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.GetAllSalesmanOutsideDistrict(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Getting all salesman outside district");
                return BadRequest("Failed: Getting all salesman outside district");
            }
            if (result.Count() == 0)
            {
                _logger.LogInformation("No salesman in list");
            }

            _logger.LogDebug("Finished: Getting all salesman outside district");
            return Ok(result);
        }

        /// <summary>
        /// Gets all Stores in a specific district
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/<DistrictController>/{id}/GetAllStores
        [HttpGet("{id:guid}/GetAllStores")]
        public async Task<IActionResult> GetAllStores(string id)
        {
            _logger.LogDebug("Started: Getting all stores in district");

            IEnumerable<Store> result;
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.GetAllStoresInDistrict(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Getting all stores in district");
                return BadRequest("Failed: Getting all stores in district");
            }
            if (result.Count() == 0)
            {
                _logger.LogInformation("No stores in list");
            }

            _logger.LogDebug("Finished: Getting all stores in district");
            return Ok(result);
        }

        /// <summary>
        /// Promotes a new salesman to Primary, and demotes the current primary to secondary salesman
        /// </summary>
        /// <param name="id"></param>
        /// <param name="promoteId"></param>
        /// <param name="demoteId"></param>
        /// <returns></returns>
        // Put: api/<DistrictController>/{id}/ChangePrimarySalesMan
        [HttpPut("{id:guid}/PromotePrimarySalesMan")]
        public async Task<IActionResult> PromotePrimarySalesMan(string id, [FromBody]Salesman salesmanPromote)
        {
            _logger.LogDebug("Started: Changing Promoting salesman: {salesmanPromote.ID} To Primary", salesmanPromote.ID);

            bool result; 
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.PromotePrimarySalesmanInDistrict(id, salesmanPromote);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Promoting to Primary salesman");
                return BadRequest("Failed: Promoting to Primary salesman");
            }
            if (!result)
            {
                _logger.LogInformation("Database returned a result of 0");
            }

            _logger.LogDebug("Finished: Promoting to Primary Salesman");
            return Ok(result);
        }

        /// <summary>
        /// Adds an existing salesman to a specific district
        /// </summary>
        /// <param name="id"></param>
        /// <param name="salesmanId"></param>
        /// <returns></returns>
        // POST: api/<DistrictController>/{id}/AddSalesManToDistrict/{salesmanId}
        [HttpPut("{id:guid}/AddSalesManToDistrict")]
        public async Task<IActionResult> AddSalesManToDistrict(string id, [FromBody]Salesman salesman)
        {
            _logger.LogDebug("Started: Adding Salesman: {salesman.ID} to District: {id}", salesman.ID, id);

            bool result;
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.AddSalesmanToDistrict(id, salesman);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Adding Salesman: {salesman.ID} to District: {id}", salesman.ID, id);
                return BadRequest("Failed: Adding Salesman to District");
            }
            if (!result)
            {
                _logger.LogInformation("Database returned a result of 0");
            }

            _logger.LogDebug("Finished: Adding Salesman: {salesman.ID} to District: {id}", salesman.ID, id);
            return Ok(result);
        }

        /// <summary>
        /// Removes a salesman from a specific district
        /// </summary>
        /// <param name="id"></param>
        /// <param name="salesmanId"></param>
        /// <returns></returns>
        // DELETE api/<DistrictController>/{id}/RemoveSalesmanFromDistrict
        [HttpDelete("{id}/RemoveSalesmanFromDistrict")]
        public async Task<IActionResult> RemoveSalesmanFromDistrict(string id, [FromBody]Salesman salesman)
        {
            _logger.LogDebug("Started: Removing Salesman: {salesman.ID} from District: {id}", salesman.ID, id);

            bool result;
            DistrictDAO dao = new DistrictDAO();

            try
            {
                result = await dao.RemoveSalesmanFromDistrict(id, salesman);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed: Removing Salesman: {salesmanId} from District: {id}", salesman.ID, id);
                return BadRequest("Failed: Removing Salesman from District");
            }
            if (!result)
            {
                _logger.LogInformation("Database returned a result of 0");
            }

            _logger.LogDebug("Finished: Removing Salesman: {salesmanId} from District: {id}", salesman.ID, id);
            return Ok(result);
        }

        // POST api/<DistrictController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<DistrictController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<DistrictController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
