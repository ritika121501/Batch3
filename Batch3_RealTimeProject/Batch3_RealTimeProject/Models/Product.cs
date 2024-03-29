namespace Batch3_RealTimeProject.Models
{
    public class Product
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get;set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
    }
}
