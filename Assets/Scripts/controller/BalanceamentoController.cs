using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{
    private static List<GameObject> formules;

    private void Update()
    {
        if (NucleoController.jogada)
        {
            NucleoController.jogadores[0].addTempo(Time.deltaTime);
        }
        else
        {
            NucleoController.jogadores[1].addTempo(Time.deltaTime);
        }
    }

    public void sendResult()
    {
        NucleoController.rodada++;
        if (verifyResult())
        {
            if(NucleoController.jogada)
                NucleoController.jogadores[0].addPontuacao(NucleoController.reward[0]);
            else
                NucleoController.jogadores[1].addPontuacao(NucleoController.reward[0]);

            if (!verifyOver())
                SceneManager.LoadScene(5);
            else
                SceneManager.LoadScene(1);
        }
        else
        {
            if(NucleoController.jogada)
                NucleoController.jogadores[0].addPontuacao(NucleoController.reward[1]);
            else
                NucleoController.jogadores[1].addPontuacao(NucleoController.reward[1]);
            
            if (!verifyOver())
                SceneManager.LoadScene(5);
            else
                SceneManager.LoadScene(1);
        }
        
        if(NucleoController.jogadores.Count>1)
            NucleoController.jogada = !NucleoController.jogada;
    }

    private bool verifyOver()
    {
        if (NucleoController.rodada < 2)
            return false;
        return true;
    }

    private bool verifyResult()
    {
        List<MoleculaForma> reagentes = NucleoController.currentEquation.Reagente;
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
        
        List<MoleculaForma> produtos = NucleoController.currentEquation.Produto;
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
