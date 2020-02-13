using System;
using UnityEngine;
using UnityEngine.UI;

public class RulesListAdapter : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform content;
    
    // Start is called before the first frame update
    void Start()
    {
        updateItens(loadRules());
    }
    
    private RuleItemModel[] loadRules()
    {
        RuleItemModel[] models = new RuleItemModel[4];
        
        models[0] = new RuleItemModel("Propriedade Comutativa","a ordem dos fatores não altera o produto (resultado). No exemplo abaixo, – 3 e + 5 são os fatores.\n(- 3) . (+ 5) = - 15\n(+ 5) . (- 3) = - 15");
        models[1] = new RuleItemModel("Propriedade Associativa","A associação dos fatores não modifica o produto. Os fatores no exemplo a seguir são: - 3, + 5 e - 2.\n(- 3 . + 5) . - 2 = (- 15) . ( - 2) = + 30\n- 3 . (+ 5 . - 2) = (- 3) . ( - 10) = + 30");
        models[2] = new RuleItemModel("Elemento Neutro","Na multiplicação, o elemento neutro é o número 1. Qualquer número multiplicado por 1 resulta nele mesmo. Nesse caso, um dos fatores sempre será o número + 1. Veja exemplos:\n(+ 8) . (+ 1) = + 8\n(- 100) . (+ 1) = - 100");
        models[3] = new RuleItemModel("Propriedade distributiva","Realizamos o produto do termo externo ao parênteses com os termos internos do parênteses. Observe os exemplos abaixo:\na . (b + c) = a . b + a . c");

        return models;
    }
    
    private void updateItens(RuleItemModel[] models)
    {
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content,false);
            initializeItemView(instance,model);
        }
    }
    
    private void initializeItemView(GameObject viewGameObject,  RuleItemModel model)
    {
        RulesItemView view = new RulesItemView(viewGameObject.transform);
        view.titulo.text = model.titulo;
        view.descricao.text = model.descricao;
    }
    
    protected class RulesItemView
    {
        public Text titulo;
        public Text descricao;

        public RulesItemView(Transform rootView)
        {
            titulo = rootView.Find("Title").GetComponent<Text>();
            descricao = rootView.Find("Description").GetComponent<Text>();
        }
    }
    
    protected class RuleItemModel
    {
        public String titulo;
        public String descricao;

        public RuleItemModel(String titulo, String descricao)
        {
            this.titulo = titulo;
            this.descricao = descricao;
        }
    }
}
