using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBackendDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBackendDemo.Controllers
{
 
    [Route("api/customers")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {

        // Kaikkien asiakkaiden listaus
        [HttpGet]
        [Route("")]
        public List<Customers> GetAll()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> all = context.Customers.ToList();
            return all;
        }

        // Yhden asiakkaan listaus

        [HttpGet]
        [Route("{customerid}")]
        public Customers GetSingle(string customerid)
        {
            NorthwindContext context = new NorthwindContext();

            if (customerid != null)
            {
                Customers customer = context.Customers.Find(customerid);
                return customer;
            }
  
            return null;
        }


        // päivämäärällä testaus
        //muutettu     [Route("api/[controller]")]

        //eli lisää Postmaniin api/customers/pvm
        [HttpGet]
        [Route("pvm")]
        public string Päivämäärä()
        {
            string pvm = DateTime.Now.ToString();
            return pvm;
        }






    }
}