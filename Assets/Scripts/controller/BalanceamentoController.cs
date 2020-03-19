using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{
    public GameObject starPrefab;

    public Text tituloResposta;
    public GameObject ResultScreen;
    public RectTransform clock;
    private static List<GameObject> formules;
    private float tempoJogada;
    private int numberOfStars;
    private int starsSpawned;
    private ScenesMaintenerController maintenerInstance = ScenesMaintenerController.Instance;

    public void Start() {
        tempoJogada = 0; 
        maintenerInstance.playBalanceamentoSound();
    }

    private void Update(){
        NucleoController nucleo = NucleoController.instance();
        
        if (!ResultScreen.active){//antes da tela de resultado
            tempoJogada += Time.deltaTime;
            nucleo.jogadores[nucleo.jogada].addTempo(Time.deltaTime);
        }
        else//depois da tela de resultado
        {
            if (showStars())
            {
                tempoJogada += Time.deltaTime;
            }
        }
    }
    /**
     * Verifica se ainda não foram renderizada todas as estrelas
     *     indicadas no parâmetro numberOfStars.
     *     Caso já tenham sido renderizadas, retorna falso.
     *     Caso ainda não tenham sido renderizdas, cria sequencialmente
     *     uma por uma das estrelas, em um intervalo de tempo
     *     indicado por tempoJogada.
     */
    private bool showStars()
    {
        if (numberOfStars > 0)
        {
            if (tempoJogada > 2 && starsSpawned==2) //aparece a estrela da direita
            {
                spawnStar(new Vector3(93, 262.24f, 0));
            }
            else
            {
                if (tempoJogada > 1.5f && starsSpawned==1) //aparece a estrela do meio
                {
                    spawnStar(new Vector3(0, 305, 0));
                }
                else if (tempoJogada > 1 && starsSpawned==0) //aparece a estrela da esquerda
                {
                    spawnStar(new Vector3(-92, 262.24f, 0));
                }
            }

            return true;
        }
        
        return false;

    }
    /**
     * Instancia o prefab de estrelas na tela, na posição em que for passada
     *     como parâmetro (dentro da ResultScreen). Ao renderizar uma estrela,
     *     diminui o saldo de estrelas "numberOfStars".
     */
    private void spawnStar(Vector3 position)
    {
        GameObject star = GameObject.Instantiate(starPrefab.gameObject);
        star.transform.SetParent(ResultScreen.transform,false);
        star.GetComponent<RectTransform>().anchoredPosition = position;
        numberOfStars--;//diminuiu o "saldo" de spawn de estrelas
        starsSpawned++;//aumenta o numero de estrelas que apareceram
    }

    public void sendResult()
    {
        maintenerInstance.stopBalanceamentoSound();
        ((Clock)clock.GetComponent("Clock")).stopClock();
        NucleoController nucleo = NucleoController.instance();
        nucleo.rodada++;
        ResultScreen.SetActive(true);
        
        if (verifyResult()){
            ResultScreen.GetComponent<ResultScreen>().showBlast();
            Debug.Log(tempoJogada);
            Debug.Log(NucleoController.preferences["TempoConfiguracao"].getInt());
            Debug.Log(((((int)tempoJogada) * 100 / NucleoController.preferences["TempoConfiguracao"].getInt())) );
            int valorPercentual = 100 - (( ((int)tempoJogada) * 100 / NucleoController.preferences["TempoConfiguracao"].getInt())) ;
            Debug.Log(valorPercentual);
            int valorPontuado = (nucleo.pontuacaoAcerto * valorPercentual/100 ) + 5;
            arrumarEstrelas(valorPercentual);
            nucleo.jogadores[nucleo.jogada].addPontuacao(valorPontuado);
            tituloResposta.text = "Parabéns!";
            maintenerInstance.playAcertouSound();
        } else{
            maintenerInstance.playErrouSound();
            tituloResposta.text = "Errou!";
            nucleo.jogadores[nucleo.jogada].addPontuacao(nucleo.pontuacaoErro);
        }
        tempoJogada = 0;//zerou o tempo para ser usado na contagem da tela de resultado
    }


    private void arrumarEstrelas(int valorPercentual) {
        if (valorPercentual< 25)
            numberOfStars = 0;//nenhuma estrela
        else if (valorPercentual < 50)
            numberOfStars = 1;//uma estrela
        else if (valorPercentual < 75)
            numberOfStars = 2;//duas estrela
        else
            numberOfStars = 3;//tres estrela

        Debug.Log("numero de estrelas "+numberOfStars);
    }
    private bool verifyResult()
    {
        return NucleoController.instance().currentEquation.verificarResultado() ;
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
