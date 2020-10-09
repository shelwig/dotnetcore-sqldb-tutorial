using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreSqlDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSqlDb.Controllers
{
    public class HealthController : Controller
    {
        private readonly MyDatabaseContext _context;
        public DbSet<string> ServerName { get; set; }

        public HealthController(MyDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var healthStatus = new HealthStatus();

            var dbConnection = _context.Database.GetDbConnection();
            healthStatus.DbServerName = dbConnection.DataSource;

            return View(healthStatus);
        }
    }
}
