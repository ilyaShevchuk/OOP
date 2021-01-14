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
        public static void Main()
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

            var genAcc = sberBank.CreateDepositAccount(100000, 2);
            var lenAcc = sberBank.CreateDebitAccount(200000);
            Console.WriteLine($"Gena balance = {genAcc.Balance}, Lena balance = {lenAcc.Balance}");
            sberBank.AddClient(cl1);
            sberBank.AddAccount(cl1, genAcc);
            sberBank.AddClient(cl2);
            sberBank.AddAccount(cl2,lenAcc); ;
            sberBank.TransferTime(DateTime.Now.AddDays(19));
            Console.WriteLine("21 days ago");
            //была одна выплата 31ого числа
            Console.WriteLine($"Gena balance = {genAcc.Balance}, Lena balance = {lenAcc.Balance}");
            sberBank.TransferTime(DateTime.Now);
            Console.WriteLine("Return to today");
            Console.WriteLine($"Gena balance = {genAcc.Balance}, Lena balance = {lenAcc.Balance}");
            Console.WriteLine("Transfer money : Gena to Lena");
            var id1 = sberBank.TransferMoney(genAcc, lenAcc, 50000);
            Console.WriteLine($"Gena balance = {genAcc.Balance}, Lena balance = {lenAcc.Balance}");
            Console.WriteLine("Undo operation by ID");
            sberBank.UndoOperation(id1);
            Console.WriteLine($"Gena balance = {genAcc.Balance}, Lena balance = {lenAcc.Balance}");
            sberBank.TransferTime(DateTime.Now.AddDays(51));
            Console.WriteLine("65 days ago");
            //было две выплаты , последнего числа каждого месяца
            Console.WriteLine($"Gena balance = {genAcc.Balance}, Lena balance = {lenAcc.Balance}");

        }
    }
}