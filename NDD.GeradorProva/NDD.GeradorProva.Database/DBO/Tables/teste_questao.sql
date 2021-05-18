CREATE TABLE [dbo].[teste_questao]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_teste] INT NOT NULL, 
    [id_questao] INT NOT NULL,
	CONSTRAINT [FK_teste_questao_questao] FOREIGN KEY ([id_questao]) REFERENCES [questao]([id]),
	CONSTRAINT [FK_teste_questao_teste] FOREIGN KEY ([id_teste]) REFERENCES [teste]([id]) ON DELETE CASCADE

)
