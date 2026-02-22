using System;
using System.Collections.Generic;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services
{
    public interface IStorageService
    {
        IEnumerable<WalletDbModel> GetAllWallets();
        IEnumerable<TransactionDbModel> GetTransactions(Guid walletId);
    }
}
