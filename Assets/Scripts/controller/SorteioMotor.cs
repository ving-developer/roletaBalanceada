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
    void Start(){
        ScenesMaintenerController.Instance.playMainSound();
        NucleoController nucleo = NucleoController.instance();
        nucleo.zerarPontuacoes();
        rodada.text = nucleo.rodada.ToString();

        if (nucleo.jogadores.Count==1){
            jogadorUm = Instantiate(jogadorUm.gameObject) as GameObject;
            jogadorUm.transform.SetParent(canvas, false);
            jogadorUm.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 199, 0);
            jogadorUm.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text = nucleo.jogadores[0].getPontuacao();
            jogadorUm.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text = nucleo.jogadores[0].addTempo(Time.deltaTime);
        }else{
            jogadorUm = GameObject.Instantiate(jogadorUm.gameObject) as GameObject;
            jogadorUm.transform.SetParent(canvas, false);
            jogadorUm.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text = nucleo.jogadores[0].getPontuacao();
            jogadorUm.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text = nucleo.jogadores[0].addTempo(Time.deltaTime);

            jogadorDois = GameObject.Instantiate(this.jogadorDois.gameObject) as GameObject;
            jogadorDois.transform.SetParent(canvas, false);
            jogadorDois.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text = nucleo.jogadores[1].getPontuacao();
            jogadorDois.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text = nucleo.jogadores[1].addTempo(Time.deltaTime);
        }
        
        if(nucleo.jogadores.Count == 1) {
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 202, -1005.874f);
        } else if (nucleo.jogada == 0){//0 corresponde ao jogador um
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-215, 202, -1005.874f);
        }else{
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(197, 202, -1005.874f);
        }
    }
}
