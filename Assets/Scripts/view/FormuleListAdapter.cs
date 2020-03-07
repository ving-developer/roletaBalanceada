using System;
using System.Collections;
using System.Collections.Generic;
using controller;
using UnityEngine;
using UnityEngine.UI;

public class FormuleListAdapter : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform plusSing;
    public RectTransform reagentes;
    public RectTransform produtos;

    void Start(){
        updateItens(NucleoController.instance().currentEquation);
        reagentes.Find("ViewPort/Content").GetComponent<RectTransform>().position = new Vector3(31.90425f,-259.0114f,0);
        produtos.Find("ViewPort/Content").GetComponent<RectTransform>().position = new Vector3(183.0772f,-259.0114f,0);
    }

    private void updateItens(Equacao equacao){
        

        foreach (var reagentes in equacao.Reagente){
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(this.reagentes.Find("ViewPort/Content"),false);
            initializeItemView(instance,reagentes, 1);
            BalanceamentoController.addFormule(instance);
            Debug.Log(reagentes.Resposta);

            if (!reagentes.Equals(equacao.Reagente[equacao.Reagente.Count - 1])){
                var plusSing = GameObject.Instantiate(this.plusSing.gameObject) as GameObject;
                plusSing.transform.SetParent(this.reagentes.Find("ViewPort/Content"),false);
            }
        }

        //Debug.Log("Produtos:");
        foreach (var produtos in equacao.Produto){
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(this.produtos.Find("ViewPort/Content"),false);
            initializeItemView(instance,produtos, 0);
            Debug.Log(produtos.Resposta);

            BalanceamentoController.addFormule(instance);
            if (!produtos.Equals(equacao.Produto[equacao.Produto.Count - 1])){
                var plusSing = GameObject.Instantiate(this.plusSing.gameObject) as GameObject;
                plusSing.transform.SetParent(this.produtos.Find("ViewPort/Content"),false);
            }
        }
    }
    
    private void initializeItemView(GameObject viewGameObject,  MoleculaForma molecula, int tipo){
        //viewGameObject.transform.Find("FormuleName").GetComponent<Text>().text=molecula.Molecula.ToString() ;
        viewGameObject.transform.Find("FormuleName").GetComponent<Text>().text = molecula.Molecula.moleculaParaInterface();
        viewGameObject.GetComponent<Formule>().setTipo(tipo);
    }
}
