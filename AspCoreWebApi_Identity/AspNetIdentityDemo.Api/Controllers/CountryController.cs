using AspNetIdentityDemo.Api.Models;
using AspNetIdentityDemo.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentityDemo.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/Country")]
    [Authorize]
    public class CountryController : Controller
    {

        private ICountryService _repository;

        public CountryController(ICountryService repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetCountry()
        {

            var items = await _repository.GetCountryList("");


            return Ok(items);

        }

        // /api/Country/search
        [HttpGet("Search/{term}")]
        public async Task<IActionResult> GetCountryAsync(string term)
        {
            if (ModelState.IsValid)
            {
                var items = await _repository.GetCountryList(term);

                return Ok(items);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }


        // GET: api/country/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _repository.GetCountryById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/Country
        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] Country item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             await _repository.CreateCountry(item);

            //return Ok(item);
            return CreatedAtAction("GetCountry", new { id = item.CountryID }, item);
        }

        // /api/Country/subregions
        [HttpGet("Subregions/{id}")]
        public async Task<IActionResult> GetSubRegionsAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var items = await _repository.GetSubRegionList(id);

                return Ok(items);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        //[HttpGet("[action]/{orderId}")]
        //public IActionResult OrderDetails(int orderId)
        //{

        //    var _orders = _dbContext.Orders.Where(order => order.Id == orderId)
        //           .Include(order => order.OrderDetails)
        //           .ThenInclude(product => product.Product);


        //    var _orderView = _dbContext.OrdersView.Where(order => order.Id == orderId).SingleOrDefault();

        //    return Ok(new { orders = _orders, orderView = _orderView });

        //}



        // /api/Country/postsubregion
        [HttpPost("Postsubregion")]
        public async Task<IActionResult> postSubRegionAsync([FromBody] SubRegion model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            await _repository.CreateSubRegion(model);

            return Ok(model);

        }

        // /api/Country/putsubregion
        [HttpPut("Putsubregion")]
        public async Task<IActionResult> putSubRegionAsync([FromBody] SubRegion model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.UpdateSubRegion(model);

            return Ok(model);

        }

        // /api/Country/deletesubregion
        [HttpDelete("Deletesubregion/{id}")]
        public async Task<IActionResult> deleteSubRegionAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            await _repository.DeleteSubRegion(id);

            return Ok("deleted");

        }

    }
}
