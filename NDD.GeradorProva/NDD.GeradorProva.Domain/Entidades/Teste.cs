using NDD.GeradorProva.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Domain.Entidades
{
    public class Teste : Entidade
    {

        public string Titulo { get; set; }
        public int QuantidadeQuestoes { get; set; }
        public DateTime DataGeracao { get; set; }
        public Materia Materia { get; set; }
        public Disciplina Disciplina{ get; set; }
        public List<Questao> Questoes { get; set; }




        public override void Validar()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (String.IsNullOrEmpty(Titulo))
            {
                mensagem += "O Titulo deve ser informado.\n";
                camposInvalidos.Add("Titulo");
            }
            else if (Titulo.Length < 5)
            {
                mensagem += "O Titulo do teste deve conter no minimo 5 caracteres.\n";
                camposInvalidos.Add("Titulo");
            }
            else if (Titulo.Length > 50)
            {
                mensagem += "O Titulo do teste de conter no maximo 50 caracteres.";
                camposInvalidos.Add("Titulo");
            }

            if (QuantidadeQuestoes < 1)
            {
                mensagem += "O teste deve contem pelo menos 1 questão.\n";
                camposInvalidos.Add("QuantidadeQuestoes");
            }
            else if (QuantidadeQuestoes > 30)
            {
                mensagem += "O teste deve conter no maximo 30 questões.\n";
                camposInvalidos.Add("QuantidadeQuestoes");
            }

            if (Disciplina == null)
            {
                mensagem += "A disciplina deve ser informada.\n";
                camposInvalidos.Add("Disciplina");
            }

            if (Materia == null)
            {
                mensagem += "A matéria deve ser informada.\n";
                camposInvalidos.Add("Materia");
            }

            if (camposInvalidos.Count > 0)
            {
                throw new ValidacaoExcecao(mensagem, camposInvalidos);
            }
        }

        public void GerarQuestoesAleatorias(List<Questao> questoes)
        {
            if (questoes.Count < QuantidadeQuestoes)
            {
                throw new ValidacaoExcecao("Não existem questões suficientes cadastradas para este teste. Cadastre mais questões ou altere a quantidade de questões solicitadas.");
            }

            Questoes = new List<Questao>();

            List<Questao> primeiroBimestre = questoes.FindAll(x => x.Bimestre == Bimestre.PRIMEIRO);
            List<Questao> segundoBimestre = questoes.FindAll(x => x.Bimestre == Bimestre.SEGUNDO);
            List<Questao> terceiroBimestre = questoes.FindAll(x => x.Bimestre == Bimestre.TERCEIRO);
            List<Questao> quartoBimestre = questoes.FindAll(x => x.Bimestre == Bimestre.QUARTO);

            Random random = new Random();
            for (int i = 0; i < QuantidadeQuestoes; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        if (primeiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(primeiroBimestre, random));
                        else if (segundoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(segundoBimestre, random));
                        else if (terceiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(terceiroBimestre, random));
                        else if (quartoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(quartoBimestre, random));
                        break;
                    case 1:
                        if (segundoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(segundoBimestre, random));
                        else if (primeiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(primeiroBimestre, random));
                        else if (terceiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(terceiroBimestre, random));
                        else if (quartoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(quartoBimestre, random));
                        break;
                    case 2:
                        if (terceiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(terceiroBimestre, random));
                        else if (primeiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(primeiroBimestre, random));
                        else if (segundoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(segundoBimestre, random));
                        else if (quartoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(quartoBimestre, random));
                        break;
                    case 3:
                        if (quartoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(quartoBimestre, random));
                        else if (primeiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(primeiroBimestre, random));
                        else if (segundoBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(segundoBimestre, random));
                        else if (terceiroBimestre.Count > 0)
                            Questoes.Add(ObterQuestaoAleatoria(terceiroBimestre, random));
                        break;
                }
            }

            Questoes.Embaralhar();
            
        }

        private Questao ObterQuestaoAleatoria(List<Questao> questoes, Random random)
        {
            int indice = random.Next(0, questoes.Count);
            Questao questao = questoes[indice];
            questoes.RemoveAt(indice);

            return questao;
        }

        public override string ToString()
        {
            return string.Format("Titulo: {0}   -   Disciplina:{1}  -   Matéria:{2}    -   {3}ªSérie    -   {4} Questões    -   Criado em: {5} ",Titulo, Disciplina.Nome,Materia.Nome, Materia.Serie.Numero, QuantidadeQuestoes, DataGeracao);
        }
    }
}
