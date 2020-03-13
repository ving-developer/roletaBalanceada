using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrelaControlador : MonoBehaviour
{

    public SpriteRenderer estrelaApagada;
    public SpriteRenderer estrelaAcesa;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acender() {
        estrelaAcesa.gameObject.SetActive(true);
    }

    public void apagar() {
        estrelaAcesa.gameObject.SetActive(false);
    }

}
