using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NucleoController : MonoBehaviour
{
    //array list que contem todos os jogadores do jogo atual
    public static List<Jogador> jogadores;
    //um bool indicando de quem é a vez de responder, true para player 1 false para o 2
    public static bool jogada;
    //um inteiro representando em qual rodada atual se encontra
    public static int rodada;
    //um array de duas posicoes contendo o valor ganho ao acertar na posicao 0 e o ganho ao errar na posicao 1
    public static int[] reward;
    //corresponde a cor que caiu na roleta
    public static int idCor;
    //dicionario contendo todas as equacoes mapeadas por id
    public static Dictionary<int, Equacao> enciclopediaEquacoes = Equacao.todasEquacoes();
    //equacao que foi sorteada para ser balanceada atualmente
    public static Equacao currentEquation;

    public static void restartAll()
    {
        jogadores = new List<Jogador>();
        jogada = true;
        rodada = 1;
        reward = new int[2];
        idCor = -1;
    }
}
