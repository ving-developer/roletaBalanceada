using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;


public class Jogador{
    private int id;
	private string nome;
	private int pontuacao;
	private int tempo;

    public string Nome { get => nome; set => nome = value; }
    public int Pontuacao { get => pontuacao; set => pontuacao = value; }
    public int Id { get => id; set => id = value; }
    public int Tempo { get => tempo; set => tempo = value; }

    public Jogador(int pontuacao, int tempo, String nome)
	{
		this.Pontuacao = pontuacao;
		this.Tempo = tempo;
		this.Nome = nome;
	}
    public Jogador() {

    }
	
	public String getTempo()
	{
		int horas = (int) Tempo / 3600;
		int minutos = (int)(Tempo % 3600) / 60;
		int segundos = (int)((Tempo % 3600) %60);
		return horas.ToString() + ":" + minutos.ToString("D2") + ":" + segundos.ToString("D2");
	}
	
	public String addTempo(float segundos)
	{
		tempo += (int) segundos;
		return getTempo();
	}

	public String setTempo(float segundos)
	{
		Tempo = (int) segundos;
		return getTempo();
	}
	
	public String getPontuacao()
	{
		return Pontuacao.ToString();
	}

	public void addPontuacao(int quantidade)
	{
		Pontuacao += quantidade;
	}



    public static List<Jogador> pegarTodosJogador() {
        List<Jogador> jogadores = new List<Jogador>();
        IDataReader reader = Conexoes.pegarReader($"SELECT id, nome, pontuacao, tempo FROM jogador order by pontuacao desc");
        while (reader.Read())
        {
            Jogador jogador = new Jogador();
            jogador.Id = reader.GetInt32(0);
            jogador.Nome = reader.GetString(1);
            jogador.pontuacao = reader.GetInt32(2);
            jogador.Tempo = reader.GetInt32(3);
            jogadores.Add(jogador);
        }
        Conexoes.fecharConexao();
        return jogadores;
    }

    public void salvar() {
        Conexoes.executarDML($"insert into jogador (nome, pontuacao, tempo) values ('{this.Nome}','{this.Pontuacao}','{this.Tempo}');");
        Conexoes.fecharConexao();
    }

}

