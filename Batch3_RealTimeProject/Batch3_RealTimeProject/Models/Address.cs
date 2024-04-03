using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch3_RealTimeProject.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 {  get; set; }
        public string City {  get; set; }
        public string State {  get; set; }
        public string PhoneNumber { get; set; }
    }
}
