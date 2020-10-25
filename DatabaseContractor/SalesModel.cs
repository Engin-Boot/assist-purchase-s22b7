using System.ComponentModel.DataAnnotations;

namespace DatabaseContractor
{

    public class Sales
    {
        [Key]
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public Product[] Description { get; set; }
    }
}
