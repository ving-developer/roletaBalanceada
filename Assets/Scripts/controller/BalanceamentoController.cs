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
        NucleoController nucleo = NucleoController.instance();
        nucleo.rodada++;
        if (verifyResult()){
            if (nucleo.jogada){
                nucleo.jogadores[0].addPontuacao(nucleo.reward[0]);
            } else{
                nucleo.jogadores[1].addPontuacao(nucleo.reward[0]);
            }
                
        }
        else
        {
            if(nucleo.jogada)
                nucleo.jogadores[0].addPontuacao(nucleo.reward[1]);
            else
                nucleo.jogadores[1].addPontuacao(nucleo.reward[1]);
        }

        ResultScreen.SetActive(true);
    }

    private bool verifyResult()
    {
        NucleoController nucleo = NucleoController.instance();
        List<MoleculaForma> reagentes = nucleo.currentEquation.Reagente;
        int i = 0;
        for (; i < reagentes.Count; i++)
        {
            if (reagentes[i].Balanco !=
                int.Parse(formules[i].transform.Find("Picker/quanity").GetComponent<Text>().text))
            {
                removeAllFormules();
                return false;
            }
        }
        
        List<MoleculaForma> produtos = nucleo.currentEquation.Produto;
        for (int j = 0; j < produtos.Count; j++)
        {
            if (produtos[j].Balanco !=
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
