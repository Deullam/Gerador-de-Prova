USE [GeradorProva]
GO
SET IDENTITY_INSERT [dbo].[disciplina] ON 
GO
INSERT [dbo].[disciplina] ([id], [nome]) VALUES (1, N'Geografia')
GO
INSERT [dbo].[disciplina] ([id], [nome]) VALUES (2, N'Matemática')
GO
INSERT [dbo].[disciplina] ([id], [nome]) VALUES (4, N'História')
GO
SET IDENTITY_INSERT [dbo].[disciplina] OFF
GO
SET IDENTITY_INSERT [dbo].[serie] ON 
GO
INSERT [dbo].[serie] ([id], [numero]) VALUES (1, 1)
GO
INSERT [dbo].[serie] ([id], [numero]) VALUES (2, 5)
GO
SET IDENTITY_INSERT [dbo].[serie] OFF
GO
SET IDENTITY_INSERT [dbo].[materia] ON 
GO
INSERT [dbo].[materia] ([Id], [nome], [id_serie], [id_disciplina]) VALUES (1, N'Capital', 1, 1)
GO
INSERT [dbo].[materia] ([Id], [nome], [id_serie], [id_disciplina]) VALUES (2, N'Relevo', 1, 1)
GO
INSERT [dbo].[materia] ([Id], [nome], [id_serie], [id_disciplina]) VALUES (3, N'Adição', 2, 2)
GO
SET IDENTITY_INSERT [dbo].[materia] OFF
GO
SET IDENTITY_INSERT [dbo].[questao] ON 
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (1, N'Capital dos EUA', N'Qual é a capital dos Estados Unidos?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (2, N'Capital do Canadá', N'Qual é a capital do Canadá?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (3, N'Capital da Alemanha', N'Qual é a capital da Alemanha?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (4, N'', N'Qual é a capital da França?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (5, N'Capital da Itália', N'Qual é a capital da Itália', 1, 1, 1)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (6, N'', N'Qual é a capital da China?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (7, N'', N'Qual é a capital da Japão?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (8, N'Capital da Argentina', N'Qual é a capital da Argentina?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (9, N'', N'Qual é a capital da Austrália?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (10, N'', N'Qual é a capital da Brasil?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (11, N'', N'Qual é a capital da África do Sul?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (12, N'', N'Qual é a capital de Bahamas?', 1, 1, 1)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (13, N'', N'Qual é a capital da Chile?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (14, N'', N'Qual é a capital da Egito?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (15, N'', N'Qual é a capital da Israel?', 1, 1, 1)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (16, N'', N'Qual é a capital de Portugal?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (17, N'', N'Qual é a capital da ReinoUnido?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (18, N'', N'Qual é a capital da República Checa?', 1, 1, 1)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (19, N'', N'Qual é a capital da Paraguai?', 1, 1, 0)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (20, N'', N'Qual é a capital da Singapura', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (21, N'', N'Qual é a capital da Síria?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (22, N'', N'Qual é a capital da Tailândia?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (23, N'', N'Qual é a capital da Ucrânia?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (24, N'', N'Qual é a capital do Vaticano?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (25, N'', N'Qual é a capital da Venezuela?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (26, N'', N'Qual é a capital da Suécia?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (27, N'', N'Qual é a capital da Suiça?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (28, N'', N'Qual é a capital da Roménia?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (29, N'', N'Qual é a capital do Senegal?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (30, N'', N'Qual é a capital da Sérvia?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (31, N'', N'Qual é a capital da Hungria?', 1, 1, 3)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (32, N'', N'Qual é a capital da Grécia?', 1, 1, 2)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (33, N'', N'teste 1', 1, 2, 1)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (34, N'', N'teste 2', 1, 2, 1)
GO
INSERT [dbo].[questao] ([Id], [sintese], [enunciado], [id_disciplina], [id_materia], [bimestre]) VALUES (35, N'', N'teste 3', 1, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[questao] OFF
GO
SET IDENTITY_INSERT [dbo].[teste] ON 
GO
INSERT [dbo].[teste] ([id], [id_disciplina], [id_materia], [titulo], [numero_questoes], [data_geracao]) VALUES (1, 1, 1, N'Avaliação de Geografia', 1, CAST(N'2018-04-05T14:57:05.543' AS DateTime))
GO
INSERT [dbo].[teste] ([id], [id_disciplina], [id_materia], [titulo], [numero_questoes], [data_geracao]) VALUES (2, 1, 1, N'Avaliação 1', 10, CAST(N'2018-04-05T15:37:14.147' AS DateTime))
GO
INSERT [dbo].[teste] ([id], [id_disciplina], [id_materia], [titulo], [numero_questoes], [data_geracao]) VALUES (3, 1, 1, N'Avaliação 2', 10, CAST(N'2018-04-05T15:38:41.683' AS DateTime))
GO
INSERT [dbo].[teste] ([id], [id_disciplina], [id_materia], [titulo], [numero_questoes], [data_geracao]) VALUES (4, 1, 1, N'Avaliação 3', 10, CAST(N'2018-04-05T15:39:28.540' AS DateTime))
GO
INSERT [dbo].[teste] ([id], [id_disciplina], [id_materia], [titulo], [numero_questoes], [data_geracao]) VALUES (5, 1, 2, N'teste 1', 3, CAST(N'2018-04-05T15:41:55.407' AS DateTime))
GO
INSERT [dbo].[teste] ([id], [id_disciplina], [id_materia], [titulo], [numero_questoes], [data_geracao]) VALUES (6, 1, 2, N'teste 2', 3, CAST(N'2018-04-05T15:42:17.817' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[teste] OFF
GO
SET IDENTITY_INSERT [dbo].[alternativa] ON 
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (1, N'Nova Iorque', 0, 1)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (2, N'Washington', 1, 1)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (3, N'Boston', 0, 1)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (4, N'Los Angeles', 0, 1)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (5, N'Miami', 0, 1)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (6, N'Montreal', 0, 2)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (7, N'Quebéc City', 0, 2)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (8, N'Ottawa', 1, 2)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (9, N'Edmonton', 0, 2)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (10, N'Toronto', 0, 2)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (11, N'Berlim', 1, 3)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (12, N'Stuttgart', 0, 3)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (13, N'Colônia', 0, 3)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (14, N'Munique', 0, 3)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (15, N'Nuremberg', 0, 3)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (16, N'Marselha', 0, 4)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (17, N'Lyon', 0, 4)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (18, N'Le Mans', 0, 4)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (19, N'Paris', 1, 4)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (20, N'Cannes', 0, 4)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (21, N'Roma', 1, 5)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (22, N'Milão', 0, 5)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (23, N'Napoles', 0, 5)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (24, N'Veneza', 0, 5)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (25, N'Turim', 0, 5)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (26, N'Xangai', 0, 6)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (27, N'Pequim', 1, 6)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (28, N'teste 1', 0, 6)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (29, N'teste 2', 0, 6)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (30, N'teste 3', 0, 6)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (31, N'Ozaka', 0, 7)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (32, N'Yokohama', 0, 7)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (33, N'Nagoia', 0, 7)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (34, N'Tóquio', 1, 7)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (35, N'Suzuka', 0, 7)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (36, N'Mendonça', 0, 8)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (37, N'Rosário', 0, 8)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (38, N'Buenos Aires', 1, 8)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (39, N'Camberra', 1, 9)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (40, N'Melbourne', 0, 9)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (41, N'Sidney', 0, 9)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (42, N'Gold Coast', 0, 9)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (43, N'Margareth River', 0, 9)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (44, N'Rio de Janeiro', 0, 10)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (45, N'Salvador', 0, 10)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (46, N'Brasília', 1, 10)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (47, N'São Paulo', 0, 10)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (48, N'Cabul', 0, 11)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (49, N'Tirana', 0, 11)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (50, N'Pretória', 1, 11)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (51, N'Nenhuma das alternativas', 0, 11)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (52, N'Viena', 0, 12)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (53, N'Nassau', 1, 12)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (54, N'Launda', 0, 12)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (55, N'Berlim', 0, 12)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (56, N'Janema', 0, 13)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (57, N'Seul', 0, 13)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (58, N'Pristina', 0, 13)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (59, N'Santiago', 1, 13)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (60, N'Suva', 0, 14)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (61, N'Paris', 0, 14)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (62, N'Banjul', 0, 14)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (63, N'Cairo', 1, 14)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (64, N'Tóqui', 0, 15)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (65, N'Roma', 0, 15)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (66, N'Jerusalém', 1, 15)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (67, N'Budapeste', 0, 15)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (68, N'Porto Moresby', 0, 16)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (69, N'Lisboa', 1, 16)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (70, N'Londres', 0, 16)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (71, N'Lisboa', 0, 17)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (72, N'Mascate', 0, 17)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (73, N'Londres', 1, 17)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (74, N'Praga', 1, 18)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (75, N'Londres', 0, 18)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (76, N'Lima', 0, 18)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (77, N'Lisboa', 0, 18)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (78, N'Lima', 0, 19)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (79, N'Lisboa', 0, 19)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (80, N'Assunção', 1, 19)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (81, N'Praga', 0, 19)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (82, N'Belgrado', 0, 20)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (83, N'Damasco', 0, 20)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (84, N'Apia', 0, 20)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (85, N'Castries', 0, 20)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (86, N'Singapura', 1, 20)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (87, N'Damasco', 1, 21)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (88, N'Dacar', 0, 21)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (89, N'São Tomé', 0, 21)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (90, N'Apia', 0, 21)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (91, N'Belgrado', 0, 22)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (92, N'Cartum', 0, 22)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (93, N'Juba', 0, 22)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (94, N'Banguecoque', 1, 22)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (95, N'Lomé', 0, 22)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (96, N'Quieve', 1, 23)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (97, N'Porto Vila', 0, 23)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (98, N'Vaticano', 0, 23)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (99, N'Ancara', 0, 24)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (100, N'Tunes', 0, 24)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (101, N'Porto Vila', 0, 24)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (102, N'Vaticano', 1, 24)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (103, N'Ancara', 0, 25)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (104, N'Campala', 0, 25)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (105, N'Porto Vila', 0, 25)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (106, N'Caracas', 1, 25)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (107, N'Juba', 0, 26)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (108, N'Estocolmo', 1, 26)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (109, N'Lomé', 0, 26)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (110, N'Damasco', 0, 27)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (111, N'Belgrado', 0, 27)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (112, N'Lobamda', 0, 27)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (113, N'Berna', 1, 27)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (114, N'Moscovo', 0, 28)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (115, N'Apia', 0, 28)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (116, N'São Tomé', 0, 28)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (117, N'Bucareste', 1, 28)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (118, N'Apia', 0, 29)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (119, N'São Tomé', 0, 29)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (120, N'São Salvador', 0, 29)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (121, N'Nenhuma das alternativas', 1, 29)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (122, N'Vitória', 0, 30)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (123, N'Dacar', 0, 30)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (124, N'Berna', 0, 30)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (125, N'Belgrado', 1, 30)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (126, N'Budapeste', 1, 31)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (127, N'Atenas', 0, 31)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (128, N'Saná', 0, 31)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (129, N'Haiti', 0, 31)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (130, N'Saná', 0, 32)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (131, N'Atenas', 1, 32)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (132, N'Jacarta', 0, 32)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (133, N'cdsfsdfsd', 0, 33)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (134, N'dasdasd', 1, 33)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (135, N'dsada', 0, 34)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (136, N'ddasdsadsaads', 1, 34)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (137, N'juyujjyuyuj', 0, 35)
GO
INSERT [dbo].[alternativa] ([id], [descricao], [correta], [id_questao]) VALUES (138, N'yjyujyu', 1, 35)
GO
SET IDENTITY_INSERT [dbo].[alternativa] OFF
GO
SET IDENTITY_INSERT [dbo].[teste_questao] ON 
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (1, 1, 1)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (2, 2, 22)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (3, 2, 5)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (4, 2, 23)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (5, 2, 18)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (6, 2, 1)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (7, 2, 13)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (8, 2, 15)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (9, 2, 29)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (10, 2, 3)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (11, 2, 25)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (12, 3, 18)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (13, 3, 16)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (14, 3, 7)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (15, 3, 27)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (16, 3, 25)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (17, 3, 15)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (18, 3, 1)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (19, 3, 12)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (20, 3, 6)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (21, 3, 11)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (22, 4, 21)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (23, 4, 24)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (24, 4, 15)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (25, 4, 7)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (26, 4, 13)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (27, 4, 2)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (28, 4, 28)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (29, 4, 18)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (30, 4, 5)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (31, 4, 3)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (32, 5, 33)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (33, 5, 35)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (34, 5, 34)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (35, 6, 35)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (36, 6, 34)
GO
INSERT [dbo].[teste_questao] ([id], [id_teste], [id_questao]) VALUES (37, 6, 33)
GO
SET IDENTITY_INSERT [dbo].[teste_questao] OFF
GO
