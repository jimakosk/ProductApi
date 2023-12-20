using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        public bool IsEnabled { get; set; }  
        public string ShopName { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
