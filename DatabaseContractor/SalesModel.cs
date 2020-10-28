using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseContractor
{
    [ExcludeFromCodeCoverage]
    public class SalesInfo // ReSharper disable All
    {
        [Key]
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public Product[] Description { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SalesInput // ReSharper disable All
    {
        
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public Product[] Description { get; set; }
    }
}
