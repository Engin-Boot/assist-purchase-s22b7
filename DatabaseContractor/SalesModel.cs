using System.ComponentModel.DataAnnotations;

namespace DatabaseContractor
{

    public class SalesInfo
    {
        [Key]
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public string Description { get; set; }
    }

    public class SalesInput
    {
        
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public Product[] Description { get; set; }
    }
}
