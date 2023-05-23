using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using porthealthvis.DataBase;
using porthealthvis.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace porthealthvis.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NewAppoinMentController : ControllerBase
    {
        public readonly DbnewContext db;

        public NewAppoinMentController(DbnewContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var data = await db.NewAppoinments.ToListAsync();
            Console.WriteLine(data);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> SaveData(NewAppointMent details)
        {
            Console.WriteLine(details);
            await db.NewAppoinments.AddAsync(details);
            await db.SaveChangesAsync();

            var Trackid = details.TransactionID;
            var Amount = 5 ;
            var Name = details.Name;
            var Email = details.Email;  
            var PhoneNo = details.Phone;
            var AppoinmentDate = details.Appdate;
            var date = DateTime.Now.ToString();

            var product_id = "VERINDON";
            var BookDate = DateTime.Now.ToString();
            string MerchantLogin;
            string MerchantPass;
            //string MerchantDiscretionaryData = "DD";
            string ProductID;
            string ClientCode = "007";
            string CustomerAccountNo = "11261354419";
            string TransactionType;
            string TransactionAmount;
            string TransactionCurrency;
            string TransactionServiceCharge = "0";
            string TransactionID;
            string TransactionDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            string strClientCode, strClientCodeEncoded;
            byte[] b;

            MerchantLogin = "23997";
            MerchantPass = "VERINDON@123";
            TransactionType = "NBFundTransfer";
            ProductID = product_id.ToString();
            TransactionID = Trackid.ToString();
            TransactionAmount = Amount.ToString();
            TransactionCurrency = "INR";

            b = Encoding.UTF8.GetBytes(ClientCode);
            strClientCode = Convert.ToBase64String(b);
            strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);
            string strURL = "https://payment.atomtech.in/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]ttype=[TransactionType]prodid=[ProductID]amt=[TransactionAmount]txncurr=[TransactionCurrency]txnscamt=[TransactionServiceCharge]clientcode=[ClientCode]txnid=[TransactionID]date=[TransactionDateTime]custacc=[CustomerAccountNo]udf1=[udf1]udf2=[udf2]udf3=[udf3]udf4=[udf4]&signature=[signature]";
            strURL = strURL.Replace("[MerchantLogin]", MerchantLogin + "&");
            strURL = strURL.Replace("[MerchantPass]", MerchantPass + "&");
            strURL = strURL.Replace("[TransactionType]", TransactionType + "&");
            strURL = strURL.Replace("[ProductID]", ProductID + "&");
            strURL = strURL.Replace("[TransactionID]", TransactionID + "&");
            strURL = strURL.Replace("[TransactionAmount]", TransactionAmount + "&");
            strURL = strURL.Replace("[TransactionCurrency]", TransactionCurrency + "&");
            strURL = strURL.Replace("[TransactionServiceCharge]", TransactionServiceCharge + "&");
            strURL = strURL.Replace("[ClientCode]", strClientCodeEncoded + "&");
            strURL = strURL.Replace("[TransactionDateTime]", TransactionDateTime + "&");
            strURL = strURL.Replace("[CustomerAccountNo]", CustomerAccountNo + "&");

            strURL = strURL.Replace("[udf1]", Name + "&");
            strURL = strURL.Replace("[udf2]", Email + "&");
            strURL = strURL.Replace("[udf3]", PhoneNo + "&");
            strURL = strURL.Replace("[udf4]", AppoinmentDate + "&");

            string reqHashKey = "97bb23a3f23bacb698"; // VERINDON
              
            string signature = "";
            string strsignature = MerchantLogin + MerchantPass + TransactionType + ProductID + TransactionID + TransactionAmount + TransactionCurrency;
            byte[] bytes = Encoding.UTF8.GetBytes(reqHashKey);
            byte[] bt = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
            //signature = byteToHexString(bt).ToLower();
            signature = BitConverter.ToString(bt).Replace("-", string.Empty).ToLower();

            strURL = strURL.Replace("[signature]", signature + "&");

 

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


              news datas = new news()
            {
                Trackid = details.TransactionID,
                PaymentUrl= strURL,
               
              };
            return Ok(datas);
        }

      
        
    }
  
    class news
    {
       public string Trackid;
       public int Amount;
       public string PaymentUrl;
    }
}
