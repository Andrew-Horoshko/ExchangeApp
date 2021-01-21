CREATE TABLE [dbo].[ExhangeHistory]
(
	[Id] INT NOT NULL  IDENTITY  PRIMARY KEY ,
	[FromCurrency] VARCHAR(3) NOT NULL ,
	[FromAmount] DECIMAL(15,2) NOT NULL,
	[ToCurrency] VARCHAR(3) NOT NULL ,
	[ToAmount] DECIMAL(15,2) NOT NULL,
	[Date] DATE NOT NULL
)
