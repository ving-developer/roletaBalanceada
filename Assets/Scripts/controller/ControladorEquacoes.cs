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

    public void retirarQuestao(Equacao equacao) {

    }

    public void retirarQuestao(int equacaoId) {
        equacoes[equacaoId].Utilizada = true;
    }


    public void resetarEquacoes() {
        foreach (int index in equacoes.Keys){
            equacoes[index].Utilizada = false;
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

        return listaEquacao[count-1];
    }


}
