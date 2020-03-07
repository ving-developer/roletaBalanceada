using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleoController 
{
    public static Dictionary<String, Preference> preferences = new Dictionary<string, Preference>();

    private static NucleoController nucleoController = new NucleoController();

    private NucleoController() {
        currentEquation = ControladorEquacoes.instance().pegarEquacao("Facil");
        List<AtomoQuantificado> atomos =  currentEquation.quantidadeAtomosReagente();
        
       
    }

    public static NucleoController instance() {
        return nucleoController;
    }

    //array list que contem todos os jogadores do jogo atual
    public List<Jogador> jogadores;

    //um int indicando de quem é a vez de responder, 0 pro player um e sucessivamente
    public int jogada;

    //um inteiro representando em qual rodada atual se encontra
    public int rodada;


    //variavel que soma a pontuacao ao jogador acertar uma questao
    public int pontuacaoAcerto;
    
    
    //variavel que soma a pontuacao ao jogador errar uma questao
    public int pontuacaoErro;



    //dicionario contendo todas as equacoes mapeadas por id
    public Dictionary<int, Equacao> enciclopediaEquacoes = Equacao.todasEquacoes();


    //equacao que foi sorteada para ser balanceada atualmente
    public Equacao currentEquation;


    public void acaoAmarelo(){
        currentEquation = ControladorEquacoes.instance().pegarEquacao("Médio");
        pontuacaoAcerto = 30;
        pontuacaoErro = 0;
    }

    public void acaoAzul() {
        currentEquation = ControladorEquacoes.instance().pegarEquacao("Facil");
        pontuacaoAcerto = 10;
        pontuacaoErro = 0;
    }

    public void acaoVermelho() {
        currentEquation = ControladorEquacoes.instance().pegarEquacao("Dificil");
        pontuacaoAcerto = 40;
        pontuacaoErro = 0;
    }

    public void acaoVerde() {
        executarAcao(new System.Random().Next(1, 7));
        pontuacaoAcerto = 50;
        pontuacaoErro = -20;
    }


    public void executarAcao(int acao) {
        if (acao == 1 || acao == 5){
            acaoVermelho();
        } else if (acao == 2 || acao == 6){
            acaoAmarelo();
        } else if (acao == 3 || acao == 7){
            acaoAzul();
        } else if (acao == 4 || acao == 8){
            acaoVerde();
        }
    }

    public void restartAll(){
        ControladorEquacoes controladorEquacoes = ControladorEquacoes.instance();

        if(preferences.Count==0)//podera ser removido quando adicionado um select no banco de dados pra preferencias
            updatePreferences();
        jogadores = new List<Jogador>();
        jogada = 0;
        rodada = 1;
        controladorEquacoes.resetarEquacoes();
    }

    public void updatePreferences()//deve dar o select no banco de dados com as configs salvas (inicialmente as padrao)
    {
        preferences.Clear();
        preferences.Add("TempoConfiguracao",new Preference(3*60));//deve ser o mesmo nome dado ao objeto configuracoes add na lista de confs
        preferences.Add("TurnoConfiguracao",new Preference(10));
    }

    public void salvarJogador(string name) {
        Jogador jogador = jogadores[0];
        jogador.Nome = name;
        jogador.salvar();
    }

    public void passarJogada()
    {
        if (jogada > 0)
            jogada = 0;
        else
            jogada = 1;

    }


    public void savePreferences(){
        //aqui deve ser chamado um metodo que salva na memoria os atuais dados salvos no dictionary preferences
    }
}
