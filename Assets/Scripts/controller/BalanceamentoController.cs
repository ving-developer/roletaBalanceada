using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BalanceamentoController : MonoBehaviour
{
    private static List<GameObject> formules;
    private static Equacao currentEquation;

    public void sendResult()
    {
        if (verifyResult())
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            Debug.Log("errou");
        }
    }

    private bool verifyResult()
    {
        List<MoleculaForma> reagentes = currentEquation.Reagente;
        int i = 0;
        for (; i < reagentes.Count; i++)
        {
            if (reagentes[i].Balanco != int.Parse(formules[i].transform.Find("Picker/quanity").GetComponent<Text>().text))
                return false;
        }
        
        List<MoleculaForma> produtos = currentEquation.Produto;
        for (int j = 0; j < produtos.Count; j++)
        {
            if (produtos[j].Balanco != int.Parse(formules[i].transform.Find("Picker/quanity").GetComponent<Text>().text))
                return false;
            i++;
        }

        return true;
    }

    public static void addFormule(GameObject added)
    {
        if(formules == null)
            formules = new List<GameObject>();
        formules.Add(added);
    }

    public static Equacao CurrentEquation
    {get => currentEquation;set => currentEquation = value;}
}
