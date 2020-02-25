using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext : DbContext  //DbContext is from System.Data.Entity;
    {
        //Database connection
        public RestaurantDbContext() : base("DefaultConnection")  // "DefaultConnection" must match Web.config connectionStrings  Name
        {   
        }

        // Database set 
        public DbSet <Restaurant> Restaurants { get; set; }
    }
}