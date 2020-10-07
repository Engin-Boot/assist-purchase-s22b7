using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistAPurchase.Utility
{
    public class TransactionManager:ITransactionManager
    {
        public string GetTransaction()
        {
            return "default Transaction";
        }
        public TransactionManager()
        {

        }
    }
}
