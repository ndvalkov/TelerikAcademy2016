using System.Collections.Generic;

namespace BankAccounts
{
    interface IBank
    {
        IEnumerable<Account> Accounts { get; set; }
    }
}
