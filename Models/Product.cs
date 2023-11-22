using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Shop")]
        public int ShopID { get; set; } = 2;
        public string Title { get; set; }=string.Empty;
        public double Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public virtual Shop Shop { get; set; }
    }

}
