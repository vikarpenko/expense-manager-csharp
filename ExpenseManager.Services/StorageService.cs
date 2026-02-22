using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services
{
    public class StorageService : IStorageService
    {
        private List<WalletDbModel> _wallets;
        private List<TransactionDbModel> _transactions;

        private void LoadIfRequired()
        {
            if (_wallets != null && _transactions != null)
                return;
            _wallets = FakeStorage.Wallets.ToList();
            _transactions = FakeStorage.Transactions.ToList();
        }

        public IEnumerable<TransactionDbModel> GetTransactions(Guid walletId)
        {
            LoadIfRequired();
            var resultList = new List<TransactionDbModel>();
            foreach (var transaction in _transactions)
            {
                if (transaction.WalletId == walletId)
                    resultList.Add(transaction);
            }
            return resultList;
        }
        
        public IEnumerable<WalletDbModel> GetAllWallets()
        {
            LoadIfRequired();
            var resultList = new List<WalletDbModel>();
            foreach (var wallet in _wallets)
            {
                resultList.Add(wallet);
            }
            return resultList;
        }
    }
}
