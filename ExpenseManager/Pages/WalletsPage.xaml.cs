using System.Collections.ObjectModel;
using ExpenseManager.Services;
using ExpenseManager.UIModels;

namespace ExpenseManager.Pages;
public partial class WalletsPage : ContentPage
{
    private readonly IStorageService _storage;
    public ObservableCollection<WalletUIModel> Wallets { get; }
        = new ObservableCollection<WalletUIModel>();
    
    public WalletsPage(IStorageService storage)
    {
        InitializeComponent();
        _storage = storage;
        LoadWallets();
        BindingContext = this;
    }

    private void LoadWallets()
    {
        Wallets.Clear();
        var wallets = _storage.GetAllWallets();
        foreach (var wallet in wallets)
        {
            Wallets.Add(new WalletUIModel(_storage, wallet));
        }
    }

    private async void WalletSelected(object sender, SelectionChangedEventArgs e)
    {
        var wallet = e.CurrentSelection.FirstOrDefault() as WalletUIModel;
        if (wallet == null) 
            return;
        
        if (sender is CollectionView view) 
            view.SelectedItem = null;

        await Shell.Current.GoToAsync(nameof(WalletDetailsPage),
            new Dictionary<string, object>
            {
                [nameof(WalletDetailsPage.CurrentWallet)] = wallet
            });
    }
}