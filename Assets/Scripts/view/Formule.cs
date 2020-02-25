using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Formule : MonoBehaviour
{
    public Text formuleQuanity;
    public Text formuleName;
    private int tipo;//0 para produto 1 para reagente
    
    // Start is called before the first frame update
    void Start()
    {
        formuleQuanity.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void more()
    {
        int value = int.Parse(formuleQuanity.text);
        if(value<99)
        {
            formuleQuanity.text = (value += 1).ToString();
            MoleculeQuanityAdapter.atualizarBalanco(formuleName.text,tipo,value);
        }
    }

    public void less()
    {
        int value = int.Parse(formuleQuanity.text);
        if(value>0)
        {
            formuleQuanity.text = (value -= 1).ToString();
            MoleculeQuanityAdapter.atualizarBalanco(formuleName.text,tipo,value);
        }
    }

    public int getQuanity()
    {
        return int.Parse(formuleQuanity.text);
    }

    public void setTipo(int value)
    {
        tipo = value;
    }
}
