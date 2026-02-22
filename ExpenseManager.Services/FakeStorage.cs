using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManager.DBModels;
using ExpenseManager.Common.Enums;

namespace ExpenseManager.Services 
{
    internal static class FakeStorage
    {
        private static readonly List<WalletDbModel> _wallets;
        private static readonly List<TransactionDbModel> _transactions;

        // Returns shallow copy of wallets to prevent external modification
        internal static IEnumerable<WalletDbModel> Wallets => _wallets.ToList();
        internal static IEnumerable<TransactionDbModel> Transactions => _transactions.ToList();

        static FakeStorage()
        {
            var cash = new WalletDbModel(Guid.NewGuid(), "Cash", Currency.UAH);
            var mono = new WalletDbModel(Guid.NewGuid(), "Monobank Card", Currency.UAH);
            var usd = new WalletDbModel(Guid.NewGuid(), "USD Account", Currency.USD);

            _wallets = new List<WalletDbModel> { cash, mono, usd };
            _transactions = new List<TransactionDbModel>
            {
                new TransactionDbModel(Guid.NewGuid(), cash.Id, -850.00m, TransactionCategory.Groceries,  "ATB groceries",new DateTime(2026, 2, 10, 18, 30, 0)),
                new TransactionDbModel(Guid.NewGuid(), cash.Id, -165.50m, TransactionCategory.Cafe, "Coffee and pastry", new DateTime(2026, 2, 11, 9, 15, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -320.00m, TransactionCategory.Transport, "Taxi ride", new DateTime(2026, 2, 11, 21, 5, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -1200.00m, TransactionCategory.Utilities, "Internet payment", new DateTime(2026, 2, 12, 12, 0, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -499.99m, TransactionCategory.Entertainment, "Movie + snacks", new DateTime(2026, 2, 13, 19, 40, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -275.00m, TransactionCategory.Health, "Pharmacy", new DateTime(2026, 2, 14, 14, 20, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, 25000.00m, TransactionCategory.Salary, "Salary (February)", new DateTime(2026, 2, 15, 9, 0, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -900.00m, TransactionCategory.Education, "Online course subscription", new DateTime(2026, 2, 16, 8, 45, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -650.00m, TransactionCategory.Car, "Fuel", new DateTime(2026, 2, 17, 17, 10, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, 500.00m, TransactionCategory.Gift, "Birthday gift received", new DateTime(2026, 2, 18, 20, 0, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -140.00m, TransactionCategory.Transport, "Metro tickets", new DateTime(2026, 2, 9, 8, 10, 0)),
                new TransactionDbModel(Guid.NewGuid(), mono.Id, -60.00m, TransactionCategory.Cafe, "Street coffee", new DateTime(2026, 2, 9, 8, 35, 0)),
            };
        }
    }
}
