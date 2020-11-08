using Microsoft.EntityFrameworkCore;
using Project_Vehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Vehicle.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options)
           : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Waybill> Waybill { get; set; }
    }
}
