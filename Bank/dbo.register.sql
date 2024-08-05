CREATE TABLE [dbo].[register] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [full_name]          NVARCHAR (50)  NULL,
    [sex]                NCHAR (10)     NULL,
    [transaction_pin]    NVARCHAR (50)  NULL,
    [contact]            NVARCHAR (50)  NULL,
    [adress]             NVARCHAR (50)  NULL,
    [next_of_king]       NVARCHAR (50)  NULL,
    [password]           NVARCHAR (50)  NULL,
    [email]              NVARCHAR (50)  NULL,
    [id_number]          INT            NULL,
    [DOB]                NVARCHAR (50)  NULL,
    [addess_type]        NVARCHAR (50)  NULL,
    [other_descriptions] NVARCHAR (100) NULL,
    [account_type]       NCHAR (10)     NULL,
    [picture] IMAGE NULL, 
    [id_scan] IMAGE NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

