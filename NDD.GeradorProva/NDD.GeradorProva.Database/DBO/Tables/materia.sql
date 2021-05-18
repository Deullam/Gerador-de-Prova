CREATE TABLE [dbo].[materia]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(50) NOT NULL, 
    [id_serie] INT NOT NULL, 
    [id_disciplina] INT NOT NULL, 
	CONSTRAINT uq_id_id_disciplina UNIQUE(id, id_disciplina),
    CONSTRAINT [FK_materia_serie] FOREIGN KEY ([id_serie]) REFERENCES [serie]([id]), 
    CONSTRAINT [FK_materia_disciplina] FOREIGN KEY ([id_disciplina]) REFERENCES [disciplina]([id])

)
