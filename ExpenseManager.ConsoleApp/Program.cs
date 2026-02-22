using ExpenseManager.Services;
using ExpenseManager.UIModels;

namespace ExpenseManager.ConsoleUI
{
    internal class Program
    {
        enum AppState
        {
            Default,
            WalletDetails,
            Exit
        }

        private static AppState _appState = AppState.Default;
        private static IStorageService _storageService = null!;
        private static List<WalletUIModel> _wallets = new();
        private static WalletUIModel? _selectedWallet;

        static void Main(string[] args)
        {
            Console.WriteLine(" >> Welcome to the Expense Manager Console App! ");
            _storageService = new StorageService();

            while (_appState != AppState.Exit)
            {
                switch (_appState)
                {
                    case AppState.Default:
                        DefaultState();
                        break;

                    case AppState.WalletDetails:
                        WalletDetailsState();
                        break;
                }

                Console.WriteLine(" >> Type Exit to close application");
                var command = Console.ReadLine();
                UpdateState(command);
            }
        }

        private static void UpdateState(string? command)
        {
            command = command?.Trim().ToLowerInvariant();
            
            switch (command)
            {
                case "back":
                    _appState = AppState.Default;
                    _selectedWallet = null;
                    break;

                case "exit":
                    _appState = AppState.Exit;
                    Console.WriteLine(" Bye!");
                    break;
                
                default:
                    if (_appState == AppState.Default)
                    {
                        if (int.TryParse(command, out int number) && number >= 1 && number <= _wallets.Count)
                        {
                            _selectedWallet = _wallets[number - 1];
                            _appState = AppState.WalletDetails;
                        }
                        else
                        {
                            Console.WriteLine(" >> Invalid wallet number. Please try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" >> Unknown command. Please try again ");
                    }

                    break;
            }
        }

        private static void DefaultState()
        {
            Console.WriteLine("List of all Wallets: ");
            LoadWallets();

            for (int i = 0; i < _wallets.Count; i++)
                Console.WriteLine($"{i + 1}. {_wallets[i]}");

            Console.WriteLine(" >> Type the number of Wallet to see its Transactions");
        }

        private static void LoadWallets()
        {
            if (_wallets.Count > 0) return;

            _wallets = new List<WalletUIModel>();
            foreach (var wallet in _storageService.GetAllWallets())
            {
                var walletUIModel = new WalletUIModel(_storageService, wallet);
                _wallets.Add(walletUIModel);
            }
        }

        private static void WalletDetailsState()
        {
            if (_selectedWallet == null)
            {
                Console.WriteLine("Wallet not selected");
                return;
            }
            
            var wallet = _selectedWallet;
            wallet.LoadTransactions();
            Console.WriteLine($"{wallet}");

            Console.WriteLine($"Transactions in {wallet.Name}: ");
            if (wallet.Transactions == null || wallet.Transactions.Count == 0)
            {
                Console.WriteLine("No transactions found");
            }
            else
            {
                for (int i = 0; i < wallet.Transactions.Count; i++)
                    Console.WriteLine($"{i + 1}. {wallet.Transactions[i]}");
            }

            Console.WriteLine(" >> Type Back to get list of all Wallets");
        }
    }
}
