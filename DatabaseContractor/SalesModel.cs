using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseContractor
{
    [ExcludeFromCodeCoverage]
    public class SalesInfo
    {
        [Key]
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public string Description { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SalesInput
    {
        
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public Product[] Description { get; set; }
    }
}
