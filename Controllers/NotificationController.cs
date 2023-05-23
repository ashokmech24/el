using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using porthealthvis.DataBase;
using System.Net;
using System.Reflection;

namespace porthealthvis.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        public readonly DbnewContext db;
        public NotificationController(DbnewContext db)
        {
            this.db = db;   
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await db.Notification.ToListAsync();
                return Ok(data);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                return BadRequest(ex);
            }
        }
        public class otpmodel
        {
            public string name;
            public string surname;
            public long phone;
            public string email;
        }

    
    }
 
}
