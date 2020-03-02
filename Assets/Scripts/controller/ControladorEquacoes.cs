using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEquacoes {

    private static ControladorEquacoes controlador = new ControladorEquacoes();
    private Dictionary<int, Equacao> equacoes;
    private Dictionary<string, List<Equacao>> equacoesDivididas = new Dictionary<string, List<Equacao>>();
    // Start is called before the first frame update


    private ControladorEquacoes() {
        equacoes = Equacao.todasEquacoes();

        equacoesDivididas.Add("Facil", new List<Equacao>());
        equacoesDivididas.Add("Médio", new List<Equacao>());
        equacoesDivididas.Add("Dificil", new List<Equacao>());

        foreach (int index in equacoes.Keys){
            Equacao equacao = equacoes[index];
            equacoesDivididas[equacao.Tipo].Add(equacao);
        }
    }


    public static ControladorEquacoes instance() {
        return controlador;
    }
    /**
     * Recebe uma equacao como parametro, iguala o attr Utilizada como verdadeiro, impossibilitando esta equacao de ser
     *     selecionada novamente enquanto for verdadeiro e por fim retorna esta equacao para ser utilizada.
     */
    public Equacao retirarQuestao(Equacao equacao)
    {
        equacao.Utilizada = true;
        return equacao;
    }
    /**
     * recebe um id correspondente ao dicionario de equacoes, iguala o attr Utilizada como verdadeiro,
     * impossibilitando esta equacao de ser selecionada novamente e retorna a equacao correspondente.
     */
    public Equacao retirarQuestao(int equacaoId)
    {
        return retirarQuestao(equacoes[equacaoId]);
    }


    public void resetarEquacoes() {
        foreach (int index in equacoes.Keys){
            equacoes[index].resetarEquacao();
        }
    }

    public Equacao pegarEquacao(string tipo) {
        List<Equacao> listaEquacao = equacoesDivididas[tipo];
        int quantidade = listaEquacao.Count;
        System.Random random = new System.Random();
        int count = 0;
        while(count < 30){
            int indice = random.Next(0, quantidade - 1); //Quantidade tem um a mais que o vetor
            if (!listaEquacao[indice].Utilizada){
                return listaEquacao[indice];
            } 
            count++;
        }
        count = 0;
        while (listaEquacao[count++].Utilizada);
        
        return retirarQuestao(listaEquacao[count-1]);
    }


}
