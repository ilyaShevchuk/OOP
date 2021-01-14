using System;
using laba5.Accounts;

namespace laba5.Operations
{
    public class TransferOperation : IOperation
    {
        private IAccount _sender;
        private IAccount _receiver;
        private int _sum;

        public TransferOperation(int id, IAccount sender, IAccount receiver, int sum) : base(id)
        {
            _sender = sender;
            _receiver = receiver;
            _sum = sum;
        }

        public override void DoOperation(DateTime operationDate)
        {
            Date = operationDate;
            _sender.Balance -= _sum;
            _receiver.Balance += _sum;
        }
        public override void DoOperation()
        {
            Date = DateTime.Now.Date;
            _sender.Balance -= _sum;
            _receiver.Balance += _sum;
        }

        public override void UndoOperation()
        {
            Date = null;
            _sender.Balance += _sum;
            _receiver.Balance -= _sum;
        }
    }
}