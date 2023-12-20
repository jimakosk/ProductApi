namespace ProductApi.Models
{
    public class Country

    { 
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public DateTime Created {  get; set; }
        public virtual ICollection<Shop> Shop { get; set; } = new HashSet<Shop>();

    }
}
