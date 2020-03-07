using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormulaController : MonoBehaviour
{

    Text valorDigitado;
    // Start is called before the first frame update
    void Start()
    {
        valorDigitado = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textUpdate(float value) {
        valorDigitado.text = Mathf.RoundToInt(value).ToString();
    }
}

