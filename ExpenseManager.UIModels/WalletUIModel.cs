using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

namespace ExpenseManager.UIModels
{
    // UI model for wallet used for display/editing and computed fields
    public class WalletUIModel
    {
        private readonly IStorageService _storage;
        private WalletDbModel? _dbModel;
        
        private string _name;
        private Currency _currency;
        private List<TransactionUIModel>? _transactions;

        // Null if wallet is not saved yet
        public Guid? Id => _dbModel?.Id;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        // Currency can be set only before saving
        public Currency Currency
        {
            get => _currency;
            set
            {
                if (_dbModel != null)
                    return;
                _currency = value;
            }
        }

        public IReadOnlyList<TransactionUIModel>? Transactions => _transactions;
        // Returns "Not Loaded" until transactions are loaded
        public int TransactionCount => _transactions?.Count ?? -1;
        public string TransactionCountDesc => TransactionCount == -1 ? "Not Loaded" : TransactionCount.ToString();
        
        public decimal TotalAmount => _transactions?.Sum(t => t.Amount) ?? 0m;
        // Returns "Not Loaded" until transactions are loaded
        public string TotalAmountDesc => _transactions == null ? "Not Loaded" : TotalAmount.ToString("0.00");

        // Constructor for creating new wallet
        public WalletUIModel(IStorageService storage, Currency currency)
        {
            _storage = storage;
            _transactions = null;
            _currency = currency;
            _name = string.Empty;
        }

        // Constructor for loading existing wallet
        public WalletUIModel(IStorageService storage, WalletDbModel dbModel)
        {
            _storage = storage;
            _dbModel = dbModel;
            _name = dbModel.Name;
            _currency = dbModel.Currency;
            _transactions = null;
        }

        public void SaveChangesToDBModel()
        {
            if (_dbModel != null)
            {
                _dbModel.Name = _name;
            }
            else
            {
                _dbModel = new WalletDbModel(Guid.NewGuid(), _name, _currency);
            }
        }

        // Lazy-load transactions from storage
        public void LoadTransactions()
        {
            if (Id == null || _transactions != null) return;
            
            _transactions = new List<TransactionUIModel>();
            foreach (var transaction in _storage.GetTransactions(Id.Value))
            {
                _transactions.Add(new TransactionUIModel(transaction));
            }
        }

        public override string ToString()
        {
            return $"Wallet: {Name} ({Currency}), Transactions: {TransactionCountDesc}, Balance: {TotalAmountDesc}";
        }
    }
}
