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
    public Slider sliderValor;
    public RectTransform valorSliderAcima;
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

     void mostrarValor(PointerEventData data) {

    }

     public void showQuanity()
     {
         Vector3 handlePosition = sliderValor.GetComponent<RectTransform>().Find("Handle Slide Area/Handle")
             .GetComponent<RectTransform>().position;
         valorSliderAcima.position = new Vector3(handlePosition.x,valorSliderAcima.position.y,valorSliderAcima.position.z);
         valorSliderAcima.GetComponent<Text>().text = getQuanity().ToString();
         valorSliderAcima.GetComponent<Animator>().SetTrigger("show");
     }

    public void more()
    {
        int value = getQuanity();
        if(value<50)
        {
            sliderValor.value = sliderValor.value + 1;
        }
    }

    public void less()
    {
        int value = getQuanity();
        if (value > 0)
        {
            sliderValor.value = sliderValor.value - 1;
        }
    }

    public void atualizarBalanco() {
        MoleculeQuanityAdapter.atualizarBalanco(formuleName.text, tipo, getQuanity());
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
