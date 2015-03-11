using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Balance.Entities;

namespace Balance
{
    public class BalanceService:IBalanceService
    {
        ObjectCache cache = MemoryCache.Default;
        public BalanceInformation GetCardBalance(string cardNumber)
        {
            string cacheName = "CardBalance_" + cardNumber;
            BalanceInformation balance = null;
            try
            {
                balance = (BalanceInformation)cache.Get(cacheName);
                if (balance == null)
                {
                    balance = new BalanceInformation();
                    var rnd = new Random();
                    double bal = rnd.Next(1, 150);
                    balance.CurrentBalance = bal;
                    balance.CardNumber = cardNumber;
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120.0);
                    cache.Add(cacheName, balance, policy);
                }
            }
            catch
            {
                balance = new BalanceInformation();
                var rnd = new Random();
                double bal = rnd.Next(1, 150);
                balance.CurrentBalance = bal;
                balance.CardNumber = cardNumber;
            }

            return balance;
        }

        public BalanceInformation UpdateBalance(BalanceInformation newBalance)
        {
            string cacheName = "CardBalance_" + newBalance.CardNumber;
            BalanceInformation balance = null;
            try
            {
                balance = (BalanceInformation)cache.Get(cacheName);
                if (balance != null)
                {
                    cache.Remove(cacheName);
                }
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120.0);
                cache.Add(cacheName, newBalance, policy);

            }
            catch
            {
                balance = newBalance;
            }

            return newBalance;
        }
    }
}
