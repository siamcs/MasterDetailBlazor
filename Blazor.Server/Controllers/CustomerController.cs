using Blazor.Server.Data;
using Blazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly AppDBContext _db;
        public CustomerController(AppDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>>Get()
        {
          return  await _db.Customers.Include(x=>x.Products).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>>Get(int id)
        {
            var Cust=await _db.Customers.Include(x=>x.Products).FirstOrDefaultAsync(x=>x.Id==id);
            if(Cust==null)
            {
                return NotFound();
            }
            return Cust;
        }

        [HttpPost]
        public async Task<ActionResult<int>>Post(Customer customer)
        {
           
             _db.Customers.Add(customer);
          await   _db.SaveChangesAsync();
            return customer.Id;
        }

        [HttpPut]
        public async Task<ActionResult>Put(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
            foreach(var products in customer.Products)
            {
                if(products.Id != 0)
                {
                    _db.Entry(products).State = EntityState.Modified;
                }
                else
                {
                    _db.Entry(products).State = EntityState.Added;
                }
            }
            var IdProd=customer.Products.Select(x=>x.Id).ToList();
            var Prodelete=await _db.Products.Where(x=>!IdProd.Contains(x.Id) && x.CustomerId== customer.Id).ToListAsync();
            _db.RemoveRange(Prodelete);
           await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            var Cus=await _db.Customers.Include(x=>x.Products).FirstOrDefaultAsync(x=>x.Id==id);
            if(Cus==null)
            {
                return NotFound ();
            }
            _db.Products.RemoveRange(Cus.Products);
            _db.Remove(Cus);
            await _db.SaveChangesAsync();
            return NoContent ();
           

        }
       
      
    }
}
