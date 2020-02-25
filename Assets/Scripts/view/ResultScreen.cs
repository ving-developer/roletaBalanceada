using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public RectTransform screen;
    public GameObject playerUm;
    public GameObject playerDois;
    public GameObject blast;
    private GameObject currentPlayer;
    private int current;
    private Text scoreText;
    private Text timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        //define quem é o jogador atual, que será instanciado no centro da tela de resultado
        if (NucleoController.instance().jogada)
        {
            currentPlayer = playerUm;
            current = 0;
        }
        else
        {
            currentPlayer = playerDois;
            current = 1;
        }
        
        currentPlayer = Instantiate(currentPlayer.gameObject) as GameObject;
        currentPlayer.transform.SetParent(screen,false);
        currentPlayer.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        currentPlayer.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        currentPlayer.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
        currentPlayer.GetComponent<RectTransform>().localScale = new Vector3(1.5f,1.5f,0);
        
        scoreText = currentPlayer.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>();
        scoreText.text = NucleoController.instance().jogadores[current].getPontuacao();
        
        timeText = currentPlayer.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>();
        timeText.text = NucleoController.instance().jogadores[current].getTempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //este metodo deve ser chamado ao acertar uma questao, mostrando os canhoes de confetti que começam desabilitados
    public void showBlast()
    {
        blast.active = true;
    }
    
    
    public void continuar(){
        NucleoController nucleo = NucleoController.instance();
        if (!verifyOver())
        {
            if(nucleo.jogadores.Count>1)
                nucleo.jogada = !nucleo.jogada;
            SceneManager.LoadScene(5);
        }
        else if (nucleo.jogadores.Count > 1)
            SceneManager.LoadScene(7);
        else
            SceneManager.LoadScene(2);
    }
    
    private bool verifyOver()
    {
        if (NucleoController.instance().rodada <= NucleoController.preferences["TurnoConfiguracao"].getInt())
            return false;
        return true;
    }
}
