using System;

namespace laba5.Accounts
{
    public abstract class IAccount
    {
        public int Id { get; }
        public double Balance { get; set; }

        public DateTime LastPayDate;

        public IAccount(int id, double balance)
        {
            Id = id;
            Balance = balance;
            LastPayDate = DateTime.Now;
        }
        
        public abstract bool IsWithdrawAvaliable(int sum);

        public abstract void TransferTime(DateTime newDate);

        public abstract int CalcNewSum(int sum);
    }
}