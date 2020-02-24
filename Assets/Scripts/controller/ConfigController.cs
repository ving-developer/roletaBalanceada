using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{
    public GameObject[] pickers;
    // Start is called before the first frame update
    void Start()
    {
        loadConfigs();
    }

    private void OnDestroy()
    {
        NucleoController.instance().savePreferences();
    }

    public void principal()
    {
        SceneManager.LoadScene(0);
    }
    
#region Configuracoes de Tempo de Resposta  

    public void lessTime()
    {
        GameObject timeObject = findInArray("TempoConfiguracao");
            
        if(int.Parse(timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text) >
           5)
        {
            timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text =
                (NucleoController.preferences[timeObject.gameObject.name].getLess(5)).ToString();
        }
    }

    public void moreTime()
    {
        GameObject timeObject = findInArray("TempoConfiguracao");
        if(int.Parse(timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text) <
           90)
        {
            timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text =
                (NucleoController.preferences[timeObject.gameObject.name].getPlus(5)).ToString();
        }
    }
    
#endregion


#region Configuracoes de Numero de Rodadas

    public void lessTurn()
    {
        GameObject timeObject = findInArray("TurnoConfiguracao");
                
        if(int.Parse(timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text) >
           2)
        {
            timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text =
                (NucleoController.preferences[timeObject.gameObject.name].getLess(2)).ToString();
        }
    }

    public void moreTurn()
    {
        GameObject timeObject = findInArray("TurnoConfiguracao");
        if(int.Parse(timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text) <
           10)
        {
            timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text =
                (NucleoController.preferences[timeObject.gameObject.name].getPlus(2)).ToString();
        }
    }
    
#endregion

    
    

    private GameObject findInArray(String find)//mesmo nome do gameobject add no array pickers
    {
        foreach (var picker in pickers)
        {
            if (picker.name == find)
                return picker;
        }

        return null;
    }
    
    private void loadConfigs()
    {
        foreach (GameObject config in pickers)
        {
            config.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text =
                NucleoController.preferences[config.gameObject.name].Value.ToString();
        }
    }
}
