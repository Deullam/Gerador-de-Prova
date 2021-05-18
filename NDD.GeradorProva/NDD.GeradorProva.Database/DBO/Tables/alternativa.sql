CREATE TABLE [dbo].[alternativa]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,  
    [descricao] VARCHAR(50) NOT NULL, 
    [correta] BIT NOT NULL,
	[id_questao] INT NOT NULL,
    CONSTRAINT [FK_alternativa_questao] FOREIGN KEY ([id_questao]) REFERENCES [questao]([id]) ON DELETE CASCADE, 
)
