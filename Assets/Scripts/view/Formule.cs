using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formule : MonoBehaviour
{
    public Text formuleQuanity;
    
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
        if(int.Parse(formuleQuanity.text.ToString())<99)
            formuleQuanity.text = (int.Parse(formuleQuanity.text.ToString())+1).ToString();
    }

    public void less()
    {
        if(int.Parse(formuleQuanity.text.ToString())>0)
            formuleQuanity.text = (int.Parse(formuleQuanity.text.ToString())-1).ToString();
    }
}
