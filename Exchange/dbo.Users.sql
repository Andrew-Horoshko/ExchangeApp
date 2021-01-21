CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FromCurrency] NVARCHAR (MAX) NULL,
    [FromAmount]   FLOAT (53)     NOT NULL,
    [ToCurrency]   NVARCHAR (MAX) NULL,
    [ToAmount]     FLOAT (53)     NOT NULL,
    [Date]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

