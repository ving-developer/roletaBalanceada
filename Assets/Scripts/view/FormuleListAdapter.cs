using System;
using System.Collections;
using System.Collections.Generic;
using controller;
using UnityEngine;
using UnityEngine.UI;

public class FormuleListAdapter : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform reagentes;
    public RectTransform produtos;
    void Start()
    {
        updateItens(loadFormules());
        reagentes.Find("ViewPort/Content").GetComponent<RectTransform>().position = new Vector3(31.90425f,-259.0114f,0);
        produtos.Find("ViewPort/Content").GetComponent<RectTransform>().position = new Vector3(183.0772f,-259.0114f,0);
    }
    
    private List<FormuleItemModel[]> loadFormules()
    {
        List<FormuleItemModel[]> result = new List<FormuleItemModel[]>();
        
        FormuleItemModel[] reagentes = new FormuleItemModel[2];
        reagentes[0] = new FormuleItemModel("Mg");
        reagentes[1] = new FormuleItemModel("HCl ");
        result.Add(reagentes);
        
        FormuleItemModel[] produtos = new FormuleItemModel[3];
        produtos[0] = new FormuleItemModel("MgCl2");
        produtos[1] = new FormuleItemModel("H2 ");
        produtos[2] = new FormuleItemModel("Fe2(SO4 )3");
        result.Add(produtos);

        Debug.Log(PrincipalController.idCor);
        
        return result;
    }
    
    private void updateItens(List<FormuleItemModel[]> models)
    {
        foreach (var reagentes in models[0])
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(this.reagentes.Find("ViewPort/Content"),false);
            initializeItemView(instance,reagentes);
        }
        
        foreach (var produtos in models[1])
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(this.produtos.Find("ViewPort/Content"),false);
            initializeItemView(instance,produtos);
        }
    }
    
    private void initializeItemView(GameObject viewGameObject,  FormuleItemModel model)
    {
        FormuleItemView view = new FormuleItemView(viewGameObject.transform);
        view.formuleName.text = model.formuleName;
    }
    
    public class FormuleItemView
    {
        public Text formuleName;

        public FormuleItemView(Transform rootView)
        {
            formuleName = rootView.Find("FormuleName").GetComponent<Text>();
        }
    }
    
    public class FormuleItemModel
    {
        public String formuleName;

        public FormuleItemModel(String formuleName)
        {
            this.formuleName = formuleName;
        }
    }
}
