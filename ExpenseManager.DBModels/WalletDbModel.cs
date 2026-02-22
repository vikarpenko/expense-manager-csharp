using ExpenseManager.Common.Enums;

namespace ExpenseManager.DBModels
{
    // Database model for wallet entity
    // Contains only storage data without business logic
    public class WalletDbModel
    {
        public Guid Id { get; }
        public string Name { get; set; }
        // Immutable after creation to ensure financial consistency
        public Currency Currency { get; } 

        // Needed for ORM/serialization
        private WalletDbModel()
        {
        }

        public WalletDbModel(Guid id, string name, Currency currency)
        {
            Id = id;
            Name = name;
            Currency = currency;
        }
    }
}
