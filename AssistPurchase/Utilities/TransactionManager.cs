using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Utilities
{
    public class TransactionManager : ITransactionManager
    {
        public string OnTransaction()
        {
            return "default Transaction";
        }
        public TransactionManager()
        {

        }
    }
}
