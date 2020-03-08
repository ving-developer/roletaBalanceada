using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{
    public AudioSource errou;
    public AudioSource acertou;
    public AudioSource backgroundSound;

    public Text tituloResposta;
    public GameObject ResultScreen;
    public RectTransform clock;
    private static List<GameObject> formules;
    private float tempoJogada = 0;

    public void Start() {
        tempoJogada = 0; 
        playSound();
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
            Debug.Log("Cheguei 2.5");
            ResultScreen.GetComponent<ResultScreen>().showBlast();
            Debug.Log($"Tempo: {tempoJogada} porcentagem: {(((int)tempoJogada) * 100 / NucleoController.preferences["TempoConfiguracao"].getInt())} ");
            nucleo.jogadores[nucleo.jogada].addPontuacao( (nucleo.pontuacaoAcerto * (100 - (((int)tempoJogada) * 100/NucleoController.preferences["TempoConfiguracao"].getInt()))/100 ) + 5  );
            tituloResposta.text = "Parabéns!";
            acertou.Play();
        } else{
            errou.Play();
            tituloResposta.text = "Errou!";
            nucleo.jogadores[nucleo.jogada].addPontuacao(nucleo.pontuacaoErro);
        }
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
