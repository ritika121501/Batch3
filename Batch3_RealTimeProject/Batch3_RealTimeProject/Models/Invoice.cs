using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch3_RealTimeProject.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public double TotalPrice { get; set; }
        [ForeignKey("Id")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
