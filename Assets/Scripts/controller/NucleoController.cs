using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public abstract class NucleoController : MonoBehaviour
{
    public static Dictionary<String, Preference> preferences = new Dictionary<string, Preference>();
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
        if(preferences.Count==0)//podera ser removido quando adicionado um select no banco de dados pra preferencias
            updatePreferences();
        jogadores = new List<Jogador>();
        jogada = true;
        rodada = 1;
        reward = new int[2];
        idCor = -1;
    }

    public static void updatePreferences()//deve dar o select no banco de dados com as configs salvas (inicialmente as padrao)
    {
        preferences.Clear();
        preferences.Add("TempoConfiguracao",new Preference(30));//deve ser o mesmo nome dado ao objeto configuracoes add na lista de confs
        preferences.Add("TurnoConfiguracao",new Preference(2));
    }

    public static void savePreferences()
    {
        //aqui deve ser chamado um metodo que salva na memoria os atuais dados salvos no dictionary preferences
    }
}
