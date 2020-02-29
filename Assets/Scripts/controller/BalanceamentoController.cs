using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{
    public GameObject ResultScreen;
    private static List<GameObject> formules;

    private void Update(){
        NucleoController nucleo = NucleoController.instance();
        if (nucleo.jogada && !ResultScreen.active){
            nucleo.jogadores[0].addTempo(Time.deltaTime);
        }else if(!ResultScreen.active){
            nucleo.jogadores[1].addTempo(Time.deltaTime);
        }
    }

    public void sendResult()
    {
        int index;
        NucleoController nucleo = NucleoController.instance();
        nucleo.rodada++;
        
        ResultScreen.SetActive(true);
        
        if (verifyResult()){
            index = 0;
            ResultScreen.GetComponent<ResultScreen>().showBlast();
        }else{
            Text titulo = ResultScreen.GetComponent<RectTransform>().Find("WhiteScreen/Title").GetComponent<Text>();
            titulo.text = "Resposta incorreta!";
            index = 1;
        }
        
        if(nucleo.jogada)
            nucleo.jogadores[0].addPontuacao(index);
        else
            nucleo.jogadores[1].addPontuacao(index);
    }

    private bool verifyResult()
    {
        NucleoController nucleo = NucleoController.instance();
        List<MoleculaForma> reagentes = nucleo.currentEquation.Reagente;
        int i = 0;
        for (; i < reagentes.Count; i++)
        {
            if (reagentes[i].Resposta !=
                int.Parse(formules[i].transform.Find("Picker/quanity").GetComponent<Text>().text))
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
        removeAllFormules();
        return true;
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
