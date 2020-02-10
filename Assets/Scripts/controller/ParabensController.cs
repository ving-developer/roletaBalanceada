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
    void Start()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NamePhonePad, false, false, true);
        adjustSufix();
        adjustTitle();
    }

    private void adjustTitle()
    {
        title.text = title.text + "\n"+NucleoController.jogadores[0].getNome();
    }

    private void adjustSufix()
    {
        if (int.Parse(NucleoController.jogadores[0].getPontuacao()) < 20)
        {
            sufix.text = "Muito fraco, você precisa de aulas com o Diego.";
        }else if (int.Parse(NucleoController.jogadores[0].getPontuacao()) < 50)
        {
            sufix.text = "Está pegando o jeito!";
        }
        else
        {
            sufix.text = "Você arrasou!";
        }
    }

    public void adjustInputSize()
    {
        String text = inputText.text;
        int difference = text.Length - 19;
        
        if (difference>0)
        {
            inputText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,334.2f+14.79f*difference);
        }
    }

    public void sendName()
    {
        try
        {
            List<Jogador> jogadores = NucleoController.jogadores;
            
            verifyName();
            
            if (jogadores.Count > 1)
            {
                jogadores.RemoveAt(0);
                SceneManager.LoadScene(2);
            }
            else
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

    private void saveAndContinue()
    {
        SceneManager.LoadScene(3);
    }
    
    private void verifyName()
    {
        String name = inputText.text;

        if (name.Length < 1)
        {
            throw new System.ArgumentException("Nome não pode ficar em branco!");
        }
        else
        {
            Debug.Log(name);
        }
    }
}
