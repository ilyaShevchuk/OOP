using System;
using System.Collections.Generic;
using System.Linq;
using Lab5.Accounts;
using laba5.Accounts;
using laba5.ClientCreate;
using laba5.Exceptions;
using laba5.Operations;

namespace laba5.BankDir
{
    public class Bank
    {
        private BankConfig BankConfig { get; }
        private static int _idCounter=0;

        public Bank(double debitPercentage, List<(int, double)> depositPercentages,
            double creditComission, int creditLimit, double incompleteClientRightsLimit)
        {
            BankConfig = new BankConfig(debitPercentage, depositPercentages, creditComission, creditLimit,
                incompleteClientRightsLimit);
        }

        public void AddClient(Client client)
        {
            BankConfig.Clients.Add(client);
            BankConfig.ClientIdAccounts[client.Id] = new List<IAccount>();
        }
        public void AddAccount(Client client, IAccount account)
        {
            if (!BankConfig.ClientIdAccounts.ContainsKey(client.Id))
                throw new WrongIdEx("Client Id " + client.Id + " don't exists");
            BankConfig.ClientIdAccounts[client.Id].Add(account);
        }

        public DebitAccount CreateDebitAccount(int sum)
        {
            return new DebitAccount(_idCounter++, sum, BankConfig.DebitPercent);
        }


        public DepositAccount CreateDepositAccount(int sum, int period)
        {
            double percentage = 0;
            foreach (var depositPercentage in BankConfig.DepositPercentages)
            {
                if (sum < depositPercentage.sum)
                {
                    percentage = depositPercentage.percentage;
                    break;
                }
            }

            if (percentage == 0) 
                percentage = BankConfig.DepositPercentages[1].percentage;
            return new DepositAccount(_idCounter++, sum, percentage, period);
        }

        public CreditAccount CreateCreditAccount(int sum)
        {
            return new CreditAccount(_idCounter++, sum, BankConfig.CreditLimit, BankConfig.CreditComission);
        }

        private void _profitClear(DateTime newDate, DateTime lastUpdateDate)
        {
            if (newDate.Year == lastUpdateDate.Year && (newDate.Month != lastUpdateDate.Month)
                || newDate.Year != lastUpdateDate.Year)
            {
                foreach (var accounts in BankConfig.ClientIdAccounts.Values)
                {
                    foreach (var account in accounts)
                    {
                        account.ClearProfit();
                    }
                }
            }
        }
        public void TransferTime(DateTime newDate)
        {
            DateTime currentDate = BankConfig.LastUpdateDate;
            newDate = newDate.Date;
            if (newDate < currentDate)
            {
                List<IOperation> localOperations = new List<IOperation>();
                localOperations.AddRange(BankConfig.Operations);
                foreach (var operation in localOperations)
                {
                    if (operation.Date > newDate)
                    {
                        operation.UndoOperation();
                        BankConfig.Operations.Remove(operation);
                    }
                }
                _profitClear(newDate, currentDate);
                BankConfig.LastUpdateDate = newDate;
                return;
            }

            while (currentDate != newDate)
            {
                    foreach (var clientAccounts in BankConfig.ClientIdAccounts.Values)
                    {
                        foreach (var account in clientAccounts)
                        {
                            if (currentDate.AddDays(1).Day == 1)
                            {
                                var operation = new AddOperation(_idCounter++, account, account.PayProfit());
                                operation.DoOperation(currentDate);
                                BankConfig.Operations.Add(operation);
                            }

                            account.CalculateDayProfit();
                            
                        }
                    }
                    currentDate = currentDate.AddDays(1);
            }

            BankConfig.LastUpdateDate = currentDate;
        }

        private bool CheckClient(Client client) =>
            !String.IsNullOrEmpty(client.Adress) || !String.IsNullOrEmpty(client.Passport);

        private Client GetClient(int id)
        {
            return BankConfig.Clients.Find(client => client.Id == id);
        }

        public int GetLastOperationId()
        {
            var last = BankConfig.Operations.Last();
            return last.Id;
        }

        private bool TryGetClientAccount(int id, out Client client, out IAccount acc)
        {
            foreach (var clientAccount in BankConfig.ClientIdAccounts)
            {
                foreach (var account in clientAccount.Value)
                {
                    if (account.Id == id)
                    {
                        client = GetClient(clientAccount.Key);
                        acc = account;
                        return true;
                    }
                }
            }

            client = default;
            acc = default;
            return false;
        }
        private bool TryGetClientAccount(int id)
        {
            foreach (var clientAccount in BankConfig.ClientIdAccounts)
            {
                foreach (var account in clientAccount.Value)
                    if (account.Id == id)
                        return true;
            }
            return false;
        }

        public int AddMoney(IAccount depositor, int sum)
        {
            if (!TryGetClientAccount(depositor.Id, out var client, out var account))
                throw new WrongIdEx("Account Id " + account.Id + " don't exists");
            var operation = new AddOperation(_idCounter, account, sum);
            operation.DoOperation();
            BankConfig.Operations.Add(operation);
            return _idCounter++;
        }

        public int WithdrawMoney(IAccount master, int sum)
        {
            if (!TryGetClientAccount(master.Id, out var client, out var account)
                && !CheckClient(client)
                && sum > BankConfig.IncompleteClientRightsLimit
                && !account.IsWithdrawAvaliable(sum))
                throw new UnsuccessfulWithdrawalExc("Can't withdraw from account " + account.Id);
            sum = account.CalcNewSum(sum);
            var withdrawOperation = new WithdrawOperation(_idCounter, account, sum);
            withdrawOperation.DoOperation();
            BankConfig.Operations.Add(withdrawOperation);
            return _idCounter++;
        }

        public int TransferMoney(IAccount sender, IAccount recipient, int sum)
        {
            var id1 = sender.Id;
            var id2 = recipient.Id;
            if (!TryGetClientAccount(id1, out var client1, out var account1)
                && !account1.IsWithdrawAvaliable(sum) && !TryGetClientAccount(id2)
                && !CheckClient(client1) && sum > BankConfig.IncompleteClientRightsLimit)
            {
                throw new UnsuccessfulWithdrawalExc("Can't transfer from this account " + account1.Id);
            }
            var transferOperation = new TransferOperation(_idCounter, sender, recipient, sum);
            transferOperation.DoOperation();
            BankConfig.Operations.Add(transferOperation);
            return _idCounter++;
        }

        public void UndoOperation(int id)
        {
            int pos = BankConfig.Operations.FindIndex(operation => operation.Id == id);
            if (pos == -1) 
                throw new WrongIdEx("Operation Id " + id + " don't exists");
            BankConfig.Operations[pos].UndoOperation();
            BankConfig.Operations.RemoveAt(pos);
        }
    }
}