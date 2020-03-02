using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ParabensController : MonoBehaviour
{
    public InputField inputText;
    public Text sufix;
    public Text title;
    
    // Start is called before the first frame update
    void Start(){
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NamePhonePad, false, false, true);
        adjustSufix();
        adjustTitle();
    }

    private void adjustTitle(){
        title.text = title.text + "\n"+NucleoController.instance().jogadores[0].Nome;
    }

    private void adjustSufix(){
        if (int.Parse(NucleoController.instance().jogadores[0].getPontuacao()) < 20){
            sufix.text = "Não foi desta vez, você precisa estudar mais.";
        }else if (int.Parse(NucleoController.instance().jogadores[0].getPontuacao()) < 50){
            sufix.text = "Está pegando o jeito!";
        }else{
            sufix.text = "Você arrasou!";
        }
    }

    public void adjustInputSize()
    {
        String text = inputText.text;
        int difference = text.Length - 19;
        
        if (difference>0){
            inputText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,334.2f+14.79f*difference);
        }
    }

    public void sendName()
    {
        try
        {
            List<Jogador> jogadores = NucleoController.instance().jogadores;
            
            verifyName();
            
            saveAndContinue();
        }
        catch (ArgumentException e)
        {
            inputText.placeholder.GetComponent<Text>().text = e.Message;
            inputText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,509.1f);
            inputText.placeholder.GetComponent<Text>().color = new Color(255,0,0,128);
            Console.WriteLine(e);
        }
    }

    private void saveAndContinue(){
        List<Jogador> jogadores = NucleoController.instance().jogadores;
        //salva o jogador da tela atual
        NucleoController.instance().salvarJogador(inputText.text);
        //caso o array de jogadores seja maior que um, ele ira excluir o jogador atual e renderizar a mesma tela com o prox jogador
        //decrementando o array de jogadores
        if (jogadores.Count > 1)
        {
            jogadores.RemoveAt(0);
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
    
    private void verifyName()
    {
        String name = inputText.text;

        if (name.Length < 1)
        {
            throw new System.ArgumentException("Nome não pode ficar em branco!");
        }else{
            Debug.Log(name);
        }
    }
}
