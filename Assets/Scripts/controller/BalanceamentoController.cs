using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{


    public GameObject ResultScreen;
    public RectTransform clock;
    private static List<GameObject> formules;
    private float tempoJogada = 0;

    public void Start() {
        tempoJogada = 0; 
    }

    private void Update(){
        NucleoController nucleo = NucleoController.instance();
        if (!ResultScreen.active){
            tempoJogada += Time.deltaTime;
            nucleo.jogadores[nucleo.jogada].addTempo(Time.deltaTime);
        }
    }

    public void sendResult(){
        ((Clock)clock.GetComponent("Clock")).stopClock();
        NucleoController nucleo = NucleoController.instance();
        nucleo.rodada++;
        
        ResultScreen.SetActive(true);
        
        if (verifyResult()){
            ResultScreen.GetComponent<ResultScreen>().showBlast();
            Debug.Log($"Tempo: {tempoJogada} porcentagem: {(((int)tempoJogada) * 100 / NucleoController.preferences["TempoConfiguracao"].getInt())} ");
            nucleo.jogadores[nucleo.jogada].addPontuacao( (nucleo.pontuacaoAcerto * (100 - (((int)tempoJogada) * 100/NucleoController.preferences["TempoConfiguracao"].getInt()))/100 ) + 5  );
        }else{
            Text titulo = ResultScreen.GetComponent<RectTransform>().Find("WhiteScreen/Title").GetComponent<Text>();
            titulo.text = "Resposta incorreta!";
            nucleo.jogadores[nucleo.jogada].addPontuacao(nucleo.pontuacaoErro);
        }
        
        
    }

    private bool verifyResult()
    {
        /* NucleoController nucleo = NucleoController.instance();
         List<MoleculaForma> reagentes = nucleo.currentEquation.Reagente;
         int i = 0;
         for (; i < reagentes.Count; i++)
         {
             if (reagentes[i].Resposta !=  int.Parse(formules[i].transform.Find("Picker/quanity").GetComponent<Text>().text))
             {
                 removeAllFormules();
                 return false;
             }
         }

         List<MoleculaForma> produtos = nucleo.currentEquation.Produto;
         for (int j = 0; j < produtos.Count; j++)
         {
             if (produtos[j].Resposta !=
                 int.Parse(formules[i].transform.Find("Picker/quanity").GetComponent<Text>().text))
             {
                 removeAllFormules();
                 return false;
             }
             i++;
         }
         removeAllFormules();*/

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
}
