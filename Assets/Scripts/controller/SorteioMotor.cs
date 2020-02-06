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
    
    // Start is called before the first frame update
    void Start()
    {
        PrincipalController.jogada = !PrincipalController.jogada;
        if (2 == 1)
        {
            var instance = GameObject.Instantiate(jogadorUm.gameObject) as GameObject;
            instance.transform.SetParent(canvas,false);
        }
        else
        {
            jogadorUm = GameObject.Instantiate(jogadorUm.gameObject) as GameObject;
            jogadorUm.transform.SetParent(canvas,false);
            
            jogadorDois = GameObject.Instantiate(this.jogadorDois.gameObject) as GameObject;
            jogadorDois.transform.SetParent(canvas,false);
        }
    }

    void Update()
    {
        if (!Roulette.isRotate)
        {
            if (PrincipalController.jogada)
            {
                playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-221,-1078,-1005.874f);
                jogadorUm.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text = PrincipalController.jogadores[0].getPontuacao();
                jogadorUm.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text = PrincipalController.jogadores[0].addTempo(Time.deltaTime);
            }
            else
            {
                playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-221,-1078,-1005.874f);
                jogadorDois.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text = PrincipalController.jogadores[1].getPontuacao();
                jogadorDois.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text = PrincipalController.jogadores[1].addTempo(Time.deltaTime);
            }
        }
    }
}
