using System;
using System.Collections.Generic;
using laba5.Accounts;
using laba5.ClientCreate;
using laba5.Exceptions;
using laba5.Operations;

namespace laba5.BankDir
{
    public class BankConfig
    {
        public double DebitPercent { get; }
        public List<(int sum, double percentage)> DepositPercentages { get; }
        public double CreditComission { get; }

        public DateTime LastUpdateDate = DateTime.Now.Date;
        public double IncompleteClientRightsLimit { get; }
        public List<IOperation> Operations { get; }
        public List<Client> Clients { get; }
        public Dictionary<int, List<IAccount>> ClientIdAccounts { get; }
        public int CreditLimit { get; }

        public BankConfig(double debitPercent, List<(int, double)> depositPercentages,
            double creditComission, int creditLimit, double incompleteClientRightsLimit)
        {
            DebitPercent = debitPercent;
            CreditComission = creditComission;
            CreditLimit = creditLimit;
            IncompleteClientRightsLimit = incompleteClientRightsLimit;
            DepositPercentages = depositPercentages;
            DepositPercentages.Sort();
            Operations = new List<IOperation>();
            Clients = new List<Client>();
            ClientIdAccounts = new Dictionary<int, List<IAccount>>();
        }

    }
}