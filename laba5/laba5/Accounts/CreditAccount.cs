using System;
using laba5.Accounts;

namespace Lab5.Accounts
{
    public class CreditAccount : IAccount
    {
        public int Limit { get; }
        public double Comission { get; }
        private double _comissionSum = 0;

        public CreditAccount(int id, int balance, int limit, double comission) : base(id, balance)
        {
            Limit = limit;
            Comission = comission;
        }
        public int CalculateComission(int sum) =>  (int) (sum * Comission / 100);
        public override void ClearProfit() {}

        public override bool IsWithdrawAvaliable(int sum) => Math.Abs(Balance - sum) < Limit;
        public override void CalculateDayProfit()
        {
            return;
        }

        public override int PayProfit()
        {
            return 0;
        }

        public override int CalcNewSum(int sum)
        {
            return CalculateComission(sum);
        }
    }
}