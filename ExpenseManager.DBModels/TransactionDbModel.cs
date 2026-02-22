using ExpenseManager.Common.Enums;

namespace ExpenseManager.DBModels
{
    // Database model for transaction entity
    // Contains only storage data without business logic
    public class TransactionDbModel
    {
        // Cannot be modified after creation
        public Guid Id { get; }
        public Guid WalletId { get; }
        // Allowed to set by business logic in this version
        public decimal Amount { get; set; } 
        public TransactionCategory Category { get; set; }
        // Optional transaction description
        public string? Description { get; set; }
        // Allowed to set by business logic in this version
        public DateTime Date { get; set; }

        // Needed for ORM/serialization
        private TransactionDbModel()
        {
        }

        public TransactionDbModel(Guid id, Guid walletId, decimal amount,
            TransactionCategory category, string? description, DateTime date)
        {
            Id = id;
            WalletId = walletId;
            Amount = amount;
            Category = category;
            Description = description;
            Date = date;
        }
    }
}
