using System.ComponentModel.DataAnnotations;

namespace DatabaseContractor
{

    public class Sales
    {
        [Key]
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public string Description { get; set; }
    }
}
