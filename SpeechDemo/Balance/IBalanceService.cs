using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balance.Entities;

namespace Balance
{
    public interface IBalanceService
    {
        BalanceInformation GetCardBalance(string cardNumber);
        BalanceInformation UpdateBalance(BalanceInformation newBalance);
    }
}
