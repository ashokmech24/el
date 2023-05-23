using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using porthealthvis.DataBase;
using porthealthvis.Models;

namespace porthealthvis.Controllers
{
    //[Consumes("multipart/form-data")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ResponseController : Controller
    {
        public readonly DbnewContext db;

        public ResponseController(DbnewContext db)
        {
            this.db = db;
        }


        // POST: ResponseController/Create
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]TransactionDetails data)
        {
            try
            {

                Console.WriteLine($"Received object: {data}");
                TrasactionModel res = new TrasactionModel()
                {
                    Amount = data.amt,
                    TransactionDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"),
                    TransactionID = data.mer_txn,
                    AppoinMentDate= data.udf4,
                    Status = "Success",
                    PaymentID = data.mmp_txn,
                    Name = data.udf1,
                    Email = data.udf2,
                    Phone = data.udf3,
                    BankName = data.bank_name,
                    BankTrasactionID = data.bank_txn,
                    AuthCode = data.auth_code,
                    TransactionType = data.discriminator,
                    Description = data.desc
                };
                await db.Transaction.AddAsync(res);
                await db.SaveChangesAsync();
                return Redirect("http://localhost:4200/payment");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return BadRequest(ex);  
            }
        } 

    }
}
