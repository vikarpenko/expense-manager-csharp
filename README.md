# ExpenseManager
ExpenseManager is an application for managing wallets and their related transactions.
The project was developed as part of Lab 1 and Lab 2 and demonstrates layered architecture, in-memory data storage, console interaction, and a .NET MAUI user interface.

At this stage, the application supports:
- Loading wallets from fake storage
- Displaying the list of wallets
- Viewing wallet details
- Loading transactions for the selected wallet
- Displaying transactions associated with the selected wallet
- Viewing transaction details
- Navigating between pages in the MAUI application
- Working with the application through both console UI and MAUI UI

## Entities
- First-level entity — Wallet
- Second-level entity — Transaction

## Solution Structure
The solution consists of the following projects:

- **Common** — class library containing shared types and enumerations
  - Enums
    - `Currency` — supported wallet currencies
    - `TransactionCategory` — used to classify transactions

- **DBModels** — class library containing data storage models
  - `WalletDbModel`
  - `TransactionDbModel`

- **UIModels** — class library containing models responsible for creating, displaying, and editing entities
  - `WalletUIModel`
  - `TransactionUIModel`

- **Services** — class library containing service logic and storage access
  - `FakeStorage` — in-memory storage with initial data
  - `StorageService`
  - `IStorageService` — interface for accessing storage data

- **ConsoleApp** — console application used for user interaction

- **ExpenseManager** — .NET MAUI application with graphical user interface
  - `WalletsPage` — displays the list of wallets
  - `WalletDetailsPage` — displays wallet details and its transactions
  - `TransactionDetailsPage` — displays transaction details

## Fake Storage
The in-memory storage contains:
- 3 wallets
- 12 transactions
- 2 wallets contain transactions
- At least 10 transactions belong to one wallet
- At least 2 transactions belong to another wallet
