
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductApi.Data;
using ProductApi.Models;
namespace ProductApi.Servises
{

    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly DataContext _db;

        public ProductService(HttpClient httpClient,DataContext db)
        {
            _httpClient = httpClient;
            _db = db;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("https://fakestoreapi.com/products");
            if (response.IsSuccessStatusCode)
            {
               var r= await _db.Products.ToListAsync();
                //var c = await _db.Products.Include(a=>a.Shop).ToListAsync();
                //var content =  JsonConvert.DeserializeObject < List <Product>> (await response.Content.ReadAsStringAsync());
                //content.ForEach(a => a.Id = new int()) ;
               
                //_db.Products.AddRange(content);
                //_db.SaveChanges();
                return r;
            }
            return null; 
        }
    }

}
