namespace Atomiv.Template.Lite.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsListed { get; set; }
    }
}