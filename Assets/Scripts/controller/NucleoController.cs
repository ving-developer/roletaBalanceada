using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NucleoController : MonoBehaviour
{
    //array list que contem todos os jogadores do jogo atual
    public static List<Jogador> jogadores = new List<Jogador>();
    //um bool indicando de quem é a vez de responder, true para player 1 false para o 2
    public static bool jogada = true;
    //um inteiro representando em qual rodada atual se encontra
    public static int rodada = 1;
    //um array de duas posicoes contendo o valor ganho ao acertar na posicao 0 e o ganho ao errar na posicao 1
    public static int[] reward = new int[2];
    //corresponde a cor que caiu na roleta
    public static int idCor = -1;
    //dicionario contendo todas as equacoes mapeadas por id
    public static Dictionary<int, Equacao> enciclopediaEquacoes = Equacao.todasEquacoes();
    //equacao que foi sorteada para ser balanceada atualmente
    public static Equacao currentEquation;
}
