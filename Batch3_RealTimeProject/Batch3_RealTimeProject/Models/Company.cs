using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch3_RealTimeProject.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

    }
}
