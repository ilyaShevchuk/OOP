using laba5.Accounts;

namespace laba5.Operations
{
    public class WithdrawOperation : Operation
    {
        private IAccount _account;
        private int _sum;

        public WithdrawOperation(int id, IAccount account, int sum) : base(id)
        {
            _account = account;
            _sum = sum;
        }

        public override void DoOperation() => _account.Balance -= _sum;

        public override void UndoOperation() => _account.Balance += _sum;
    }
}