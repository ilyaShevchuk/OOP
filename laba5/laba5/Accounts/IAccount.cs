using System;

namespace laba5.Accounts
{
    public abstract class IAccount
    {
        public int Id { get; }
        public double Balance { get; set; }
        public IAccount(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }

        public abstract void ClearProfit();
        public abstract bool IsWithdrawAvaliable(int sum);

        public abstract void CalculateDayProfit();
        public abstract int PayProfit();
        public abstract int CalcNewSum(int sum);
    }
}