INSERT INTO [dbo].[TransactionTable] 
	([TransactionID]
          ,[TransactionDate]
          ,[TransactionAmount]
          ,[Vendor]
          ,[Product]
          ,[PaymentMode])
    VALUES 
    (
     	NEWID(),
        GETDATE(),
        5000,
        'Flipkart',
        'Laptop Stand',
        0   
    ),
    (
     	NEWID(),
        GETDATE(),
        5000,
        'Amazon',
        'Book',
        7   
    ),    
    (
     	NEWID(),
        GETDATE(),
        5000,
        'Tata Cliq',
        'TShirt',
        5  
    ),
        (
     	NEWID(),
        GETDATE(),
        5000,
        'Ajio',
        'TShirt',
        6  
    );


    Select * from [dbo].[TransactionTable] 
