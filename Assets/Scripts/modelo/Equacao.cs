using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;


public class Equacao{

    int id;
    /// Fácil
	/// Médio
	/// Difícil
	private string tipo;

	private Time tempoMedioResposta;

	private Time melhorTempoResposta;

	private List<MoleculaForma> reagente = new List<MoleculaForma>();
	
	private List<MoleculaForma> produto = new List<MoleculaForma>();

    private static Dictionary<int, Equacao> equacoes;

    public string Tipo { get => tipo; set => tipo = value; }
    public Time TempoMedioResposta { get => tempoMedioResposta; set => tempoMedioResposta = value; }
    public Time MelhorTempoResposta { get => melhorTempoResposta; set => melhorTempoResposta = value; }
    public int Id { get => id; set => id = value; }
    public List<MoleculaForma> Reagente { get => reagente; set => reagente = value; }
    public List<MoleculaForma> Produto { get => produto; set => produto = value; }

    public static Dictionary<int, Equacao> todasEquacoes() {

        if (equacoes == null){
            equacoes = new Dictionary<int, Equacao>();

            IDataReader reader = Conexoes.pegarReader("SELECT id, tipo FROM equacao");
            while (reader.Read())
            {
                Equacao equacao = new Equacao();
                equacao.Id = reader.GetInt32(0);
                equacao.Tipo = reader.GetString(1);
                equacoes[equacao.Id] = equacao;
            }
            Conexoes.fecharConexao();

            foreach (int index in equacoes.Keys){
                MoleculaForma.carregarMoleculaForma(equacoes[index]);
            }

        }

        



        return equacoes;
    }

    override
    public string ToString() {

        string equacaoReagente = "";

        foreach(MoleculaForma reagente in Reagente){
            if(equacaoReagente == ""){
                equacaoReagente += $"{reagente.Balanco}{reagente.Molecula}";
            } else{
                equacaoReagente += $" + {reagente.Balanco}{reagente.Molecula}";
            }

        }

        string equacaoProduto = "";
        foreach (MoleculaForma produto in Produto){
            if (equacaoProduto == "" ){
                equacaoProduto += $"{produto.Balanco}{produto.Molecula}";
            } else{
                equacaoProduto += $" + {produto.Balanco}{produto.Molecula}";
            }
        }

        return $"{equacaoReagente} = {equacaoProduto}";
    }

}

