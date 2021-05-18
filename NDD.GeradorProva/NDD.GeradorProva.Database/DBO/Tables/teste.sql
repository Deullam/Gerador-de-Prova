CREATE TABLE [dbo].[teste]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_disciplina] INT NOT NULL, 
    [id_materia] INT NOT NULL, 
    [titulo] VARCHAR(50) NOT NULL, 
    [numero_questoes] INT NOT NULL, 
    [data_geracao] DATETIME NOT NULL, 
    CONSTRAINT [FK_teste_materia] FOREIGN KEY ([id_materia], [id_disciplina]) REFERENCES [materia]([id], [id_disciplina]) ON UPDATE CASCADE
)
