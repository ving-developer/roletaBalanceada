using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreListAdapter : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform content;
    List<ScoreItemView> views = new List<ScoreItemView>();
    
    // Start is called before the first frame update
    void Start()
    {
        updateItens(loadScores());
    }

    private ScoreItemModel[] loadScores()
    {
        ScoreItemModel[] models = new ScoreItemModel[15];
        
        models[0] = new ScoreItemModel("Henrique Barros",99999);
        models[1] = new ScoreItemModel("Luiz Loja",99998);
        models[2] = new ScoreItemModel("Diego Rodrigues",99997);
        models[3] = new ScoreItemModel("Moça do TCC",99996);
        models[4] = new ScoreItemModel("Jogador",99995);
        models[5] = new ScoreItemModel("Henrique Barros",99999);
        models[6] = new ScoreItemModel("Luiz Loja",99998);
        models[7] = new ScoreItemModel("Diego Rodrigues",99997);
        models[8] = new ScoreItemModel("Moça do TCC",99996);
        models[9] = new ScoreItemModel("Jogador",99995);
        models[10] = new ScoreItemModel("Henrique Barros",99999);
        models[11] = new ScoreItemModel("Luiz Loja",99998);
        models[12] = new ScoreItemModel("Diego Rodrigues",99997);
        models[13] = new ScoreItemModel("Moça do TCC",99996);
        models[14] = new ScoreItemModel("Jogador",99995);

        return models;
    }

    private void updateItens(ScoreItemModel[] models)
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);
        
        views.Clear();

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content,false);
            views.Add(initializeItemView(instance,model));
        }
    }

    ScoreItemView initializeItemView(GameObject viewGameObject,  ScoreItemModel model)
    {
        ScoreItemView view = new ScoreItemView(viewGameObject.transform);
        view.nome.text = model.nome;
        view.pontuacao.text = model.pontuacao.ToString();

        return view;
    }

    public class ScoreItemView
    {
        public Text nome;
        public Text pontuacao;

        public ScoreItemView(Transform rootView)
        {
            nome = rootView.Find("Nome").GetComponent<Text>();
            pontuacao = rootView.Find("Pontos").GetComponent<Text>();
        }
    }

    public class ScoreItemModel
    {
        public String nome;
        public int pontuacao;

        public ScoreItemModel(String nome, int pontuacao)
        {
            this.nome = nome;
            this.pontuacao = pontuacao;
        }
    }
}
