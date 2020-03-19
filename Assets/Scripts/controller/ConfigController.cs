using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{
    public GameObject[] pickers;
    private ScenesMaintenerController maintenerInstance = ScenesMaintenerController.Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        maintenerInstance.stopAllSounds();
        maintenerInstance.playMainSecondSound();
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
           60)
        {
            timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text =
                (NucleoController.preferences[timeObject.gameObject.name].getLess(5)).ToString();
        }
    }

    public void moreTime()
    {
        GameObject timeObject = findInArray("TempoConfiguracao");
        if(int.Parse(timeObject.GetComponent<RectTransform>().Find("Picker/quanity").GetComponent<Text>().text) <
           180)
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
           16)
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
