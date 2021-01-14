using System;
using laba5.Exceptions;

namespace laba5.Accounts
{
    public class DepositAccount : IAccount
    {
        public double Persentage { get; }
        public int Period { get; }
        private double _profit = 0;

        public DepositAccount(int id, int balance, double persentage, int period) : base(id, balance)
        {
            Persentage = persentage;
            Period = period;
        }

        public override void CalculateDayProfit()
        {
            _profit += Balance * Persentage / 365 / 100;   
        }
        public override int PayProfit()
        {
            var profitPay = _profit;
            _profit = 0;
            return (int) profitPay;
        }

        public override void ClearProfit()
        {
            _profit = 0;
        }

        public override bool IsWithdrawAvaliable(int sum){
            return Balance >= sum && Period == 0;
        }
        public override int CalcNewSum(int sum)
        {
            return sum;
        }
    }
}