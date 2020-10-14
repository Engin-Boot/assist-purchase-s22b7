using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Models
{
    public class AlertDataModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmailId { get; set; }
        public string SelectedProduct { get; set; }
        public string RequirementMessage { get; set; }
        //public string ReplyFromSalesPerson { get; set; }
    }
}
