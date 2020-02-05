using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteioMotor : MonoBehaviour
{
    public RectTransform canvas;
    public GameObject playerSelector;
    private int numJogadores = 2;
    public GameObject jogadorUm;
    public GameObject jogadorDois;
    private bool jogada = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (numJogadores == 1)
        {
            var instance = GameObject.Instantiate(jogadorUm.gameObject) as GameObject;
            instance.transform.SetParent(canvas,false);
        }
        else
        {
            var jogadorUm = GameObject.Instantiate(this.jogadorUm.gameObject) as GameObject;
            jogadorUm.transform.SetParent(canvas,false);
            
            var JogadorDois = GameObject.Instantiate(this.jogadorDois.gameObject) as GameObject;
            JogadorDois.transform.SetParent(canvas,false);
        }
    }

    void Update()
    {
        #region Organizar de quem é a jogada
        if (jogada)
        {
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-221,-1078,-1005.874f);
        }
        else
        {
            playerSelector.GetComponent<RectTransform>().anchoredPosition = new Vector3(197,-1078,-1005.874f);
        }

        #endregion
    }

    public void passarJogada()
    {
        jogada = !jogada;
    }
}
