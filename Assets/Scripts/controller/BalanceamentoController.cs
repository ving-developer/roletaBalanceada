using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{
    public AudioSource errou;
    public AudioSource acertou;
    public AudioSource backgroundSound;
    public SpriteRenderer estrelaEsquerda;
    public SpriteRenderer estrelaMeio;
    public SpriteRenderer estrelaDireita;

    public Text tituloResposta;
    public GameObject ResultScreen;
    public RectTransform clock;
    private static List<GameObject> formules;
    private float tempoJogada = 0;

    public void Start() {
        tempoJogada = 0; 
        playSound();
        acenderEstrelas();
    }

    private void Update(){
        NucleoController nucleo = NucleoController.instance();
        if (!ResultScreen.active){
            tempoJogada += Time.deltaTime;
            nucleo.jogadores[nucleo.jogada].addTempo(Time.deltaTime);
        }
    }

    public void sendResult(){
        stopAllSounds();
        ((Clock)clock.GetComponent("Clock")).stopClock();
        NucleoController nucleo = NucleoController.instance();
        nucleo.rodada++;
        ResultScreen.SetActive(true);
        
        if (verifyResult()){
            ResultScreen.GetComponent<ResultScreen>().showBlast();
            Debug.Log(tempoJogada);
            Debug.Log(NucleoController.preferences["TempoConfiguracao"].getInt());
            Debug.Log(((((int)tempoJogada) * 100 / NucleoController.preferences["TempoConfiguracao"].getInt())) );
            int valorPercentual = 100 - (( ((int)tempoJogada) * 100 / NucleoController.preferences["TempoConfiguracao"].getInt())) ;
            Debug.Log(valorPercentual);
            int valorPontuado = (nucleo.pontuacaoAcerto * valorPercentual/100 ) + 5;
            arrumarEstrelas(valorPercentual);
            nucleo.jogadores[nucleo.jogada].addPontuacao(valorPontuado);
            tituloResposta.text = "Parabéns!";
            acertou.Play();
        } else{
            apagarEstrelas();
            errou.Play();
            tituloResposta.text = "Errou!";
            nucleo.jogadores[nucleo.jogada].addPontuacao(nucleo.pontuacaoErro);
        }
    }


    private void arrumarEstrelas(int valorPercentual) {
        if (valorPercentual< 25){
            apagarEstrelas();
        } else if (valorPercentual < 50){
            apagarDuas();
        } else if (valorPercentual < 75){
            apagarUma();
        } 
    }

    private void apagarEstrelas() {
        estrelaDireita.GetComponent<EstrelaControlador>().apagar();
        estrelaEsquerda.GetComponent<EstrelaControlador>().apagar();
        estrelaMeio.GetComponent<EstrelaControlador>().apagar();
    }

    private void acenderEstrelas() {
        estrelaDireita.GetComponent<EstrelaControlador>().acender();
        estrelaEsquerda.GetComponent<EstrelaControlador>().acender();
        estrelaMeio.GetComponent<EstrelaControlador>().acender();
    }

    private void apagarUma() {
        estrelaDireita.GetComponent<EstrelaControlador>().apagar();
    }

    private void apagarDuas() {
        estrelaEsquerda.GetComponent<EstrelaControlador>().apagar();
        estrelaDireita.GetComponent<EstrelaControlador>().apagar();
    }


    private bool verifyResult()
    {
        return NucleoController.instance().currentEquation.verificarResultado() ;
    }

    public static void addFormule(GameObject added)
    {
        if(formules == null)
            formules = new List<GameObject>();
        formules.Add(added);
    }

    public static void removeAllFormules()
    {
        formules = new List<GameObject>();
    }

    public void playSound()
    {
        backgroundSound.Play();
    }

    private void stopAllSounds()
    {
        backgroundSound.Stop();
    }
}
