using System;
using System.Collections;
using System.Collections.Generic;
using controller;
using UnityEngine;
using UnityEngine.UI;

public class SorteioMotor : MonoBehaviour
{
    public RectTransform canvas;
    public GameObject playerSelector;
    public GameObject jogadorUm;
    public GameObject jogadorDois;
    public Text rodada;

    // Start is called before the first frame update
    void Start()
    {
        rodada.text = NucleoController.rodada.ToString();

        if (NucleoController.jogadores.Count==1)
        {
            jogadorUm = GameObject.Instantiate(jogadorUm.gameObject) as GameObject;
            jogadorUm.transform.SetParent(canvas, false);
            jogadorUm.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -1082, 0);
            jogadorUm.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text =
                NucleoController.jogadores[0].getPontuacao();
            jogadorUm.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text =
                NucleoController.jogadores[0].addTempo(Time.deltaTime);
        }
        else
        {
            jogadorUm = GameObject.Instantiate(jogadorUm.gameObject) as GameObject;
            jogadorUm.transform.SetParent(canvas, false);
            jogadorUm.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text =
                NucleoController.jogadores[0].getPontuacao();
            jogadorUm.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text =
                NucleoController.jogadores[0].addTempo(Time.deltaTime);

            jogadorDois = GameObject.Instantiate(this.jogadorDois.gameObject) as GameObject;
            jogadorDois.transform.SetParent(canvas, false);
            jogadorDois.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text =
                NucleoController.jogadores[1].getPontuacao();
            jogadorDois.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text =
                NucleoController.jogadores[1].addTempo(Time.deltaTime);
        }
        
        if(NucleoController.jogadores.Count == 1)
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -1078, -1005.874f);
        else if (NucleoController.jogada)
        {
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-221, -1078, -1005.874f);
        }
        else
        {
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(197, -1078, -1005.874f);
        }
    }
}
