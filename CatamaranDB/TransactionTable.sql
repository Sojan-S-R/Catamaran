CREATE TABLE [dbo].[TransactionTable]
(
	[TransactionID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [TransactionDate] DATE NOT NULL, 
    [TransactionAmount] MONEY NOT NULL, 
    [Vendor] NVARCHAR(50) NULL, 
    [Product] NVARCHAR(50) NULL, 
    [PaymentMode] NVARCHAR(50) NULL
)
