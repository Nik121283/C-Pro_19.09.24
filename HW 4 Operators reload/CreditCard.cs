using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Operators_reload
{
    public class CreditCard
    {
        private int id;

        public string NameOfCardOwner { get; set; }

        public string SurnameOfCardOwner { get; set; }

        private decimal account;

        public decimal Account 
        { 
            get { return account; } 
            set { if(value > 0) {account = value;} } 
        }


        public CreditCard(string nameOfCardOwner, string surnameOfCardOwner, decimal cashAtAccount)
        {
            NameOfCardOwner = nameOfCardOwner;
            SurnameOfCardOwner = surnameOfCardOwner;
            Account = cashAtAccount;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if(obj is CreditCard card2)
                {
                    return this.Account.Equals(card2.Account);
                }
            }

            return false;
        }

        public static CreditCard operator +(CreditCard card1, decimal addingSum)
        {
            card1.Account += addingSum;
            return card1;
        }

        public static CreditCard operator -(CreditCard card1, decimal withdrawSum)
        {
            if (card1.Account > withdrawSum)
            { card1.Account -= withdrawSum; }

            return card1;
        }

        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            return card1.Account == card2.Account;
        }

        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return !(card1.Account == card2.Account);
        }

        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.Account > card2.Account;
        }

        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.Account < card2.Account;
        }
    }
}
