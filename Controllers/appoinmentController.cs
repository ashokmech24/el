//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using porthealthvis.DataBase;
//using porthealthvis.Models;

//namespace porthealthvis.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AppoinmentController : ControllerBase
//    {
//        private readonly DbnewContext db;

//        public AppoinmentController(DbnewContext db)
//        {   
//            this.db = db;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Getdata()
//        {
//            var data = await db.Appoinments.ToListAsync();
//            return Ok(data);
//        }
//        [HttpPost]
//        public async Task<IActionResult> Createdata([FromBody] Appoinment data)
//        {
              
//                var datas = await db.Appoinments.AddAsync(data);
//                await db.SaveChangesAsync();
//            return Ok();

//        }

//        [HttpPut]
//        public async Task<IActionResult> Updatedata([FromBody] Appoinment data)
//        {
//            var datas = await db.Appoinments.FirstOrDefaultAsync(a => a.Id == data.Id);
//            if (datas != null)
//            {
//                datas.Id = data.Id;
//                datas.Name = data.Name;
//                datas.Surname = data.Surname;
//                datas.Email = data.Email;
//                datas.Phone = data.Phone;
//                datas.Add = data.Add;
//                datas.Expdate = data.Expdate;
//                datas.Age = data.Age;
//                datas.Amount = data.Amount;
//                datas.City = data.City;
//                datas.Countrytovisit = data.Countrytovisit;
//                datas.Gender = data.Gender;
//                datas.Expdate = data.Expdate;
//                datas.Egg_allergic = data.Egg_allergic;
//                datas.Passportno = data.Passportno;
//                datas.Pincode = data.Pincode;
//                datas.TransuctionID = data.TransuctionID;
//                await db.SaveChangesAsync();
//                return Ok(datas);
//            }
//            else
//            {
//                return NotFound("update err");
//            }
//        }
//        [HttpDelete]
//        public async Task<IActionResult> Deletedata([FromBody] Appoinment data)
//        {
//            var datas = await db.Appoinments.FirstOrDefaultAsync(a => a.Id == data.Id);
//            if (datas != null)
//            {
//                db.Appoinments.Remove(datas); 
//                await db.SaveChangesAsync();
//                return Ok(datas);
//            }
//            else
//            {
//                return NotFound();
//            }
//        }


//    }
//}
