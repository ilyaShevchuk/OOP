using laba5.Accounts;

namespace laba5.Operations
{
    public class TransferOperation : Operation
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

        public override void DoOperation()
        {
            _sender.Balance -= _sum;
            _receiver.Balance += _sum;
        }

        public override void UndoOperation()
        {
            _sender.Balance += _sum;
            _receiver.Balance -= _sum;
        }
    }
}