using ExpenseManager.UIModels;

namespace ExpenseManager.Pages;

[QueryProperty(nameof(CurrentTransaction), nameof(CurrentTransaction))]
public partial class TransactionDetailsPage : ContentPage
{
    private TransactionUIModel _currentTransaction;

    public TransactionUIModel CurrentTransaction
    {
        get => _currentTransaction;
        set
        {
            _currentTransaction = value;
            BindingContext = _currentTransaction;
        }
    }

    public TransactionDetailsPage()
    {
        InitializeComponent();
    }
}