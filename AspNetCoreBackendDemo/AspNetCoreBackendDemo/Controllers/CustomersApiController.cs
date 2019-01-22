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

        // Kaikkien asiakkaiden listaus SELECT GET ALL
        [HttpGet]
        [Route("")]
        public List<Customers> GetAll()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> all = context.Customers.ToList();
            return all;
        }

        // Yhden asiakkaan listaus SELECT GET 1

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

        [HttpPost]
        [Route("")]
        public Customers PostCreateNew(Customers customer)
        {
            NorthwindContext context = new NorthwindContext();

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
        } 
        // Muokkaus PUt UPDATE urlin parametri custmerid tulee string customerid arvoksi
        [HttpPut]
        [Route("{customerid}")]
        public Customers PutEdit([FromRoute] string customerid,[FromBody] Customers newData)
        {
            NorthwindContext context = new NorthwindContext();

            if (customerid != null)
            {
                Customers customer = context.Customers.Find(customerid);

                if (customer != null)
                {
                    customer.CompanyName = newData.CompanyName;
                    customer.ContactName = newData.ContactName;
                    customer.City = newData.City;
                    customer.Country = newData.Country;

                    context.SaveChanges();

                }

                return customer;
            }

            return null;
        }

        // DELETE
        [HttpDelete]
        [Route("{customerid}")]
        public Customers Delete([FromRoute] string customerid)
        {
            NorthwindContext context = new NorthwindContext();

            if (customerid != null)
            {
                Customers customer = context.Customers.Find(customerid);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
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