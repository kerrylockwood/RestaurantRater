using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // POST (endpoint) - receive this Restaurant and add to database
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant != null)  // ModelState is checked upon entry to this method
            {
                // this is LIKE SQL using Commitment Control!!!!!!!!!

                _context.Restaurants.Add(restaurant);  // Add does NOT save - like SQL update
                await _context.SaveChangesAsync();     // Save all changes to database. Returns an integer - like SQL Commit.

                // _context is the entire database - defined above
                // .Restaurant is the Restaurants table - defined under RestaurantDbContext.cs

                return Ok();
            }
            return BadRequest(ModelState);
        }

        // GET ALL
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        // GET BY ID
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // PUT (update)
        // DELETE BY ID

    }
}
