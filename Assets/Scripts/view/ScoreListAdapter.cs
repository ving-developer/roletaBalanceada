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

    private List<ScoreItemModel> loadScores()
    {
        List<ScoreItemModel> models = new List<ScoreItemModel>();
        List<Jogador> jogadores = Jogador.pegarTodosJogador();
        foreach (Jogador j in jogadores){
            models.Add(new ScoreItemModel(j.Nome,j.Pontuacao));
        }
        return models;
    }

    private void updateItens(List<ScoreItemModel> models)
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
