using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.Model
{
    public class Account
    {
        public Account ()
        {
            AccountTransactions = new HashSet<AccountTransaction>();
        }

        public int Id { get; set; }
        public string AccountCode { get; set; }
        public Decimal CurrentBalance { get; set; }

        // FKs
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public IEnumerable<AccountTransaction> AccountTransactions { get; set; }
    }
}
