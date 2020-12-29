using System;
using System.Collections.Generic;
using System.Configuration;
using laba5.Accounts;
using laba5.BankDir;
using laba5.ClientCreate;

namespace laba5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var depPercenteges = new List<(int, double)>
            {
                (50000, 3),
                (100000, 3.5),
                (Int32.MaxValue, 4)
            };
            Bank sberBank = new Bank(3.65, depPercenteges, 10, 20000, 20);
            
            ClientBuilder clientFactory = new ClientBuilder();
            Client cl1 = clientFactory.SetName("Gena").SetSurname("Bukin").SetAdress("Groove str").SetPassport("1214").Build();
            Client cl2 = clientFactory.SetName("Lena").SetSurname("Poleno").SetAdress("G2 str").SetPassport("1213").Build();

            var genAcc = sberBank.CreateDepositAccount(1000, 2);
            var lenAcc = sberBank.CreateDebitAccount(2000);
            sberBank.AddClient(cl1);
            sberBank.AddAccount(cl1, genAcc);
            sberBank.AddClient(cl2);
            sberBank.AddAccount(cl2,lenAcc);
            
            sberBank.AddMoney(genAcc, 2000);
            sberBank.TransferMoney(genAcc, lenAcc, 500);
            Console.WriteLine(genAcc.Balance);
            Console.WriteLine(lenAcc.Balance);
            
            sberBank.TransferTime(DateTime.Now.AddDays(41));
            Console.WriteLine(lenAcc.Balance);

        }
    }
}