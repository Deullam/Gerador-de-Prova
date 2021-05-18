CREATE TABLE [dbo].[questao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [sintese] VARCHAR(100) NOT NULL, 
    [enunciado] VARCHAR(500) NOT NULL, 
	[id_disciplina] INT NOT NULL, 
    [id_materia] INT NOT NULL, 
    [bimestre] INT NOT NULL, 
    CONSTRAINT [FK_questao_disciplina] FOREIGN KEY ([id_disciplina]) REFERENCES [disciplina]([id]),
	CONSTRAINT [FK_questao_materia] FOREIGN KEY ([id_materia]) REFERENCES [materia]([id])
    
)
