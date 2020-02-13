using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public GameObject playerUm;
    public GameObject playerDois;
    public RectTransform recipiente;
    
    // Start is called before the first frame update
    void Start()
    {
        Jogador jogador;
        GameObject player;
        
        if (int.Parse(NucleoController.jogadores[0].getPontuacao()) >
            int.Parse(NucleoController.jogadores[1].getPontuacao()))
        {
            player = playerUm;
            jogador = NucleoController.jogadores[0];
        }
        else
        {
            player = playerDois;
            jogador = NucleoController.jogadores[1];
        }
        
        player = Instantiate(player.gameObject) as GameObject;
        player.transform.SetParent(recipiente, false);
        player.GetComponent<RectTransform>().localScale = new Vector3(1.5f,1.5f,0);
        player.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
        player.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>().text = jogador.getPontuacao();
        player.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>().text = jogador.getTempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuar()
    {
        SceneManager.LoadScene(2);
    }
}
