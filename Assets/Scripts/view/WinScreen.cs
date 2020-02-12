using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public RectTransform screen;
    public GameObject playerUm;
    public GameObject playerDois;
    private GameObject currentPlayer;
    private int current;
    private Text scoreText;
    private Text timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (NucleoController.jogada)//invertido pq 
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
        currentPlayer.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,684,0);
        
        scoreText = currentPlayer.GetComponent<RectTransform>().Find("Pontos").GetComponent<Text>();
        scoreText.text = NucleoController.jogadores[current].getPontuacao();
        
        timeText = currentPlayer.GetComponent<RectTransform>().Find("Tempo").GetComponent<Text>();
        timeText.text = NucleoController.jogadores[current].getTempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void continuar()
    {
        if (!verifyOver())
        {
            if(NucleoController.jogadores.Count>1)
                NucleoController.jogada = !NucleoController.jogada;
            SceneManager.LoadScene(5);
        }
        else
            SceneManager.LoadScene(2);
    }
    
    private bool verifyOver()
    {
        if (NucleoController.rodada < 3)
            return false;
        return true;
    }
}
