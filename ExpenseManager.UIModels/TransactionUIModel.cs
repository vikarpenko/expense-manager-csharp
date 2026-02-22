using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels
{
    // UI model for transaction used for display/editing and computed fields
    public class TransactionUIModel
    {
        private TransactionDbModel? _dbModel;
        
        private readonly Guid _walletId;
        private decimal _amount;
        private TransactionCategory _category;
        private string _description;
        private DateTime _date;

        // Id is available only if transaction exists in storage
        public Guid? Id => _dbModel?.Id;
        public Guid WalletId => _walletId;

        public decimal Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public TransactionCategory Category
        {
            get => _category;
            set => _category = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value ?? string.Empty;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }
        
        public bool IsExpense => _amount < 0;

        public TransactionUIModel(Guid walletId)
        {
            _walletId = walletId;
            _amount = 0m;
            _description = string.Empty;
            _date = DateTime.Now;
            _category = TransactionCategory.Other;
        }

        public TransactionUIModel(TransactionDbModel dbModel)
        {
            _dbModel = dbModel;
            _walletId = dbModel.WalletId;
            _amount = dbModel.Amount;
            _category = dbModel.Category;
            _description = dbModel.Description ?? string.Empty;
            _date = dbModel.Date;
        }

        public void SaveChangesToDBModel()
        {
            if (_dbModel != null)
            {
                _dbModel.Amount = _amount;
                _dbModel.Category = _category;
                _dbModel.Description = _description;
                _dbModel.Date = _date;
            }
            else
            {
                _dbModel = new TransactionDbModel(Guid.NewGuid(),
                    _walletId, _amount, _category, _description, _date);
            }
        }
        
        public override string ToString()
        {
            return $"Transaction Id: {Id}\n" +
                   $"Date: {Date:dd.MM.yyyy HH:mm}\n" +
                   $"Category: {Category}\n" +
                   $"Amount: {Amount}\n" +
                   $"Type: {(IsExpense ? "Expense" : "Income")}\n" +
                   $"Description: {Description}\n";
        }
    }
}
