using System.Collections.Generic;

namespace ContaCorrente.Model
{
    public class Client
    {

        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts;

    }
}
