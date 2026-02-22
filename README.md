# ExpenseManager (Lab1)
ExpenseManager is a console-based application for managing wallets and their related transactions.
This project was developed as part of Lab 1 and focuses on implementing the core domain model, layered architecture, and console interaction logic.

At this stage, the application supports:
- Loading wallets from fake storage
- Displaying the list of wallets
- Viewing detailed wallet information
- Loading transactions for the selected wallet
- Displaying transactions associated with the selected wallet
- Displaying transaction details in list view
- Properly exiting the application

## Entities
- First-level entity — Wallet
- Second-level entity — Transaction

## Solution Structure
The solution consists of the following projects:

- Common — class library containing shared types and enumerations
  - Enums
    - Currency — supported wallet currencies
    - TransactionCategory — used to classify transactions
    
- DBModels — class library containing data storage models
  - WalletDbModel
  - TransactionDbModel

- UIModels — class library containing models responsible for creating, displaying, and editing entities
  - WalletUIModel
  - TransactionUIModel

- Services — class library containing service logic and storage implementation 
  - FakeStorage — in-memory storage with initial data
  - StorageService
  - IStorageService — interface for accessing storage data

- ConsoleApp — console application used for user interaction

## Fake Storage
The in-memory storage contains:
- 3 first-level entities (Wallets) 
- 12 second-level entities (Transactions)
- 2 wallets contain second-level entities (Transactions)
- At least 10 transactions belong to one wallet 
- At least 2 transactions belong to another wallet
