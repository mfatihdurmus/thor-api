using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using thor.Models;

namespace thor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Process> Get()
        {
            using (var db = new ThorContext())
            {
                var item = new Process { Name = "Test" + DateTime.Now.ToString() };
                db.Process.Add(item);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Process
                            orderby b.Name
                            select b;

                return query.ToArray();
            }
        }
    }
}
