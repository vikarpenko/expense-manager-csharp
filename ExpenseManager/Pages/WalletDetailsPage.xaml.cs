using ExpenseManager.Services;
using ExpenseManager.UIModels;

namespace ExpenseManager.Pages;

[QueryProperty(nameof(CurrentWallet), nameof(CurrentWallet))]
public partial class WalletDetailsPage : ContentPage
{
    private readonly IStorageService _storage;
    private WalletUIModel _currentWallet;

    public WalletUIModel CurrentWallet
    {
        get => _currentWallet;
        set
        {
            _currentWallet = value;
            _currentWallet.LoadTransactions();
            BindingContext = CurrentWallet;
        }
    }

    public WalletDetailsPage(IStorageService storage)
    {
        InitializeComponent();
        _storage = storage;
    }

    private async void TransactionSelected(object sender, SelectionChangedEventArgs e)
    {
        var transaction = e.CurrentSelection.FirstOrDefault() as TransactionUIModel;
        if (transaction == null)
            return;

        if (sender is CollectionView view)
            view.SelectedItem = null;

        await Shell.Current.GoToAsync(nameof(TransactionDetailsPage),
            new Dictionary<string, object>
            {
                [nameof(TransactionDetailsPage.CurrentTransaction)] = transaction
            });
    }
}