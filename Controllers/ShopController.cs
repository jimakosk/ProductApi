using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly DataContext _db;

        public ShopController(DataContext db) 
        {
            this._db = db;

        }
        [HttpGet("GetAll/{IsEnabled}")]
        public async Task<IActionResult> GetAll(bool IsEnabled)
        {
            var shop= await _db.Shops.ToListAsync();
            if (shop != null)
            {
                return  new JsonResult(shop);
            }
            return null;
        }
        [HttpGet("AddOne/{id}/{Name}")]
        public async Task<IActionResult> AddOne(int id,string Name) {

            await _db.Shops.AddAsync(new Shop()
            {
            //               Id = id,
                ShopName = Name
            });
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("FindOne/{id}")]
        public async Task<IActionResult> FindOne(Guid id)
        {

           
            var tes =await _db.Shops.Where(a=>a.Id==id).FirstOrDefaultAsync();
            return Ok(tes);
        }
    }
}
