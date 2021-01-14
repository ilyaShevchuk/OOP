using System;
using laba5.Accounts;

namespace laba5.Operations
{
    public class WithdrawOperation : IOperation
    {
        private IAccount _account;
        private int _sum;

        public WithdrawOperation(int id, IAccount account, int sum) : base(id)
        {
            Date = DateTime.Now.Date;
            _account = account;
            _sum = sum;
        }

        public override void DoOperation(DateTime operationDate)
        {
            Date = operationDate;
            _account.Balance -= _sum;
        }
        public override void DoOperation()
        {
            Date = DateTime.Now;
            _account.Balance -= _sum;
        }

        public override void UndoOperation()
        {
            Date = null;
            _account.Balance += _sum;
        }
    }
}