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

        public abstract bool IsWithdrawAvaliable(int sum);
    }
}