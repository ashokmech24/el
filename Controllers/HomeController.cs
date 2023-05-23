using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using porthealthvis.DataBase;
using porthealthvis.Models;

namespace porthealthvis.Controllers
{
    //[Consumes("multipart/form-data")]
    [Route("api/[Controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public readonly DbnewContext db;

            public HomeController(DbnewContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetData(string TransactionID)
        {
            Console.WriteLine(TransactionID);
            var query = db.Transaction.AsQueryable();
            if (!string.IsNullOrEmpty(TransactionID))
                query = query.Where(t => t.TransactionID == TransactionID);
            var data = await query.ToListAsync();
            return Ok(data);
        }


        [HttpPost]

        public async Task<IActionResult> FaildTransuction([FromForm]TransactionDetails data)
        {
            try
            {
                TrasactionModel res = new TrasactionModel()
                {
                    Amount = data.amt,
                    TransactionDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"),
                    TransactionID = data.mer_txn,
                    Status = "Failed",
                    PaymentID= data.mmp_txn,
                    Name = data.udf1,
                    Email = data.udf2,
                    Phone = data.udf3,
                    AppoinMentDate= data.udf4,
                    BankName = data.bank_name,
                    BankTrasactionID = data.bank_txn,
                    AuthCode = data.auth_code,
                    TransactionType = data.discriminator,
                    Description = data.desc
                };
                await db.Transaction.AddAsync(res);
                Console.WriteLine(data.ToString());
                await db.SaveChangesAsync();
               // return Ok(data);
                return Redirect("http://localhost:4200/paymentFaild");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
