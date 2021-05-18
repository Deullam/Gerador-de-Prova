﻿USE [GeradorProva]
GO
INSERT INTO [dbo].[serie]
           ([numero])
     VALUES (1)
GO
INSERT INTO [dbo].[disciplina]
           ([nome])
     VALUES
           ('Matemática')
GO

INSERT INTO [dbo].[materia]
           ([nome]
           ,[id_serie]
           ,[id_disciplina])
     VALUES
           ('Adição',1,1)
GO


INSERT INTO [dbo].[questao]
           ([sintese],
		   [enunciado]
           ,[id_disciplina]
           ,[id_materia]
           ,[bimestre])
     VALUES
		   ('','Quanto é 10+0?',1,1, 3) , 
           ('','Quanto é 10+20?',1,1, 3) , 
		   ('','Quanto é 10+30?',1,1, 3),
		   ('','Quanto é 10+40?',1,1, 3),
		   ('','Quanto é 10+50?',1,1, 3),
		   ('','Quanto é 10+60?',1,1, 3),
		   ('','Quanto é 10+70?',1,1, 3),
		   ('','Quanto é 10+80?',1,1, 3),
		   ('','Quanto é 10+90?',1,1, 3),
		   ('','Quanto é 10+100?',1,1, 3),

		   ('','Quanto é 20+10?',1,1, 2), 
           ('','Quanto é 20+20?',1,1, 2) , 
		   ('','Quanto é 20+30?',1,1, 2),
		   ('','Quanto é 20+40?',1,1, 2),
		   ('','Quanto é 20+50?',1,1, 2),
		   ('','Quanto é 20+60?',1,1, 2),
		   ('','Quanto é 20+70?',1,1, 2),
		   ('','Quanto é 20+80?',1,1, 2),
		   ('','Quanto é 20+90?',1,1, 2),
		   ('','Quanto é 20+100?',1,1, 2),

		   ('','Quanto é 30+10?',1,1, 3), 
           ('','Quanto é 30+20?',1,1, 3) , 
		   ('','Quanto é 30+30?',1,1, 3),
		   ('','Quanto é 30+40?',1,1, 3),
		   ('','Quanto é 30+50?',1,1, 3),
		   ('','Quanto é 30+60?',1,1, 3),
		   ('','Quanto é 30+70?',1,1, 3),
		   ('','Quanto é 30+80?',1,1, 3),
		   ('','Quanto é 30+90?',1,1, 3),
		   ('','Quanto é 30+100?',1,1, 1)
GO

INSERT INTO [dbo].[alternativa]
           ([descricao]
           ,[correta]
           ,[id_questao])
     VALUES
           (100,0,1), (10,1,1) , (0,0,1), (310,0,1),
		   (90,0,2),  (10,0,2) , (30,1,2), (40,0,2),
		   (80,0,3),  (40,1,3) , (13,0,3), (10,0,3),
		   (70,0,4),  (50,1,4) , (13,0,4), (60,0,4),
		   (70,0,5),  (60,1,5) , (30,0,5), (50,0,5),
		   (60,0,6),  (70,1,6) , (10,0,6), (210,0,6),
		   (50,0,7),  (80,1,7) , (60,0,7), (10,0,7),
		   (40,0,8),  (90,1,8) , (38,0,8), (60,0,8),
		   (30,0,9),  (100,1,9) , (1000,0,9), (90,0,9),
		   (20,0,10),  (110,1,10) , (111,0,10), (100,0,10),
		  
		  (100,0,11), (30,1,11) , (0,0,11), (310,0,11),
		   (90,0,12),  (80,0,12) , (40,1,12), (70,0,12),
		   (80,0,13),  (50,1,13) , (13,0,13), (10,0,13),
		   (70,0,14),  (60,1,14) , (13,0,14), (90,0,14),
		   (80,0,15),  (70,1,15) , (30,0,15), (50,0,15),
		   (60,0,16),  (80,1,16) , (10,0,16), (210,0,16),
		   (50,0,17),  (90,1,17) , (60,0,17), (10,0,17),
		   (40,0,18),  (100,1,18) , (38,0,18), (60,0,18),
		   (30,0,19),  (110,1,19) , (1000,0,19), (90,0,19),
		   (20,0,20),  (120,1,20) , (111,0,20), (100,0,20),

		   (100,0,21), (40,1,21) , (0,0,21), (310,0,21),
		   (90,0,22),  (80,0,22) , (50,1,22), (40,0,22),
		   (80,0,23),  (60,1,23) , (13,0,23), (10,0,23),
		   (90,0,24),  (70,1,24) , (13,0,24), (60,0,24),
		   (70,0,25),  (80,1,25) , (30,0,25), (50,0,25),
		   (60,0,26),  (90,1,26) , (10,0,26), (210,0,26),
		   (50,0,27),  (100,1,27) , (60,0,27), (10,0,27),
		   (40,0,28),  (110,1,28) , (38,0,28), (60,0,28),
		   (30,0,29),  (120,1,29) , (1000,0,29), (90,0,29),
		   (20,0,30),  (130,1,30) , (111,0,30), (100,0,30)
GO