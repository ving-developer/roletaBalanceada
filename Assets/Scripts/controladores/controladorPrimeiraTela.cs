using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controladorPrimeiraTela : MonoBehaviour {
    // Start is called before the first frame update
    void Start(){
        Debug.Log("Inicio");

        Dictionary<int, Atomo> atomos = Atomo.todosAtomos();
        atomos[1].escreverAtomo();

        Dictionary<int, Equacao>.ValueCollection equacoes =   Equacao.todasEquacoes().Values;

        Debug.Log("Inicio");
        foreach (Equacao m in equacoes){
            Debug.Log($"{m.Tipo}: {m.ToString()}");
        }




    }

    // Update is called once per frame
    void Update(){
    }

   public void Click() {
        
    }
}
