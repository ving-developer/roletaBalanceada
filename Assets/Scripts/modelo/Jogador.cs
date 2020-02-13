using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;	


public class Jogador{
	private String nome;
	private int pontuacao;
	private float tempo;
	
	public Jogador(int pontuacao, int tempo, String nome)
	{
		this.pontuacao = pontuacao;
		this.tempo = tempo;
		this.nome = nome;
	}
	
	public String getTempo()
	{
		int horas = (int) tempo / 3600;
		int minutos = (int)(tempo % 3600) / 60;
		int segundos = (int)((tempo % 3600) %60);
		return horas.ToString() + ":" + minutos.ToString("D2") + ":" + segundos.ToString("D2");
	}
	
	public String addTempo(float segundos)
	{
		tempo += segundos;
		return getTempo();
	}

	public String setTempo(float segundos)
	{
		tempo = (int) segundos;
		return getTempo();
	}
	
	public String getPontuacao()
	{
		return pontuacao.ToString();
	}

	public void addPontuacao(int quantidade)
	{
		pontuacao += quantidade;
	}


	public void setNome(String nome)
	{
		this.nome = nome;
	}

	public String getNome()
	{
		return nome;
	}
}

