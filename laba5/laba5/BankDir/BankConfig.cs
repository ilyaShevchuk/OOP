using System.Collections.Generic;
using laba5.Accounts;
using laba5.ClientCreate;
using laba5.Operations;

namespace laba5.BankDir
{
    public class BankConfig
    {
        public double DebitPercentage { get; }
        public List<(int sum, double percentage)> DepositPercentages { get; }
        public double CreditComission { get; }
        public int CreditLimit { get; }
        public double NotCertifiedClientLimit { get; }
        public List<Operation> Operations { get; }
        public List<Client> Clients { get; }
        public Dictionary<int, List<IAccount>> ClientIdAccounts { get; }
        
        public BankConfig(double debitPercentage, List<(int, double)> depositPercentages,
            double creditComission, int creditLimit, double notCertifiedClientLimit)
        {
            DebitPercentage = debitPercentage;
            DepositPercentages = depositPercentages;
            DepositPercentages.Sort();
            CreditComission = creditComission;
            CreditLimit = creditLimit;
            NotCertifiedClientLimit = notCertifiedClientLimit;
            Operations = new List<Operation>();
            Clients = new List<Client>();
            ClientIdAccounts = new Dictionary<int, List<IAccount>>();
        }

    }
}