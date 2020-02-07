using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class Atomo{
	
	private int id;
	
	private string nome;

	private int numeroAtomico;

	private float pesoAtomico;

	private string sigla;

	private Grupo grupo;

    private static Dictionary<int, Atomo> atomos = null; 

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public int NumeroAtomico { get => numeroAtomico; set => numeroAtomico = value; }
    public float PesoAtomico { get => pesoAtomico; set => pesoAtomico = value; }
    public string Sigla { get => sigla; set => sigla = value; }
    public Grupo Grupo { get => grupo; set => grupo = value; }


    public static Dictionary<int, Atomo> todosAtomos() {

        if(atomos == null){
            atomos = new Dictionary<int, Atomo>();

            Dictionary<int, Grupo> grupos = Grupo.todosGrupos();

            IDataReader reader = Conexoes.pegarReader("select id,nome, sigla, numero_atomico, grupo_id from atomo");
            while (reader.Read()){
                Atomo atomo = new Atomo();
                atomo.Id = reader.GetInt32(0);
                atomo.Nome = reader.GetString(1);
                atomo.Sigla = reader.GetString(2);
                atomo.NumeroAtomico = reader.GetInt32(3);
                atomo.grupo = grupos[reader.GetInt32(4)];
                atomos[atomo.NumeroAtomico] = atomo;


            }

            Conexoes.fecharConexao();
        }

        return atomos;

    }

    public void escreverAtomo(){
        Debug.Log("Numero: " + this.NumeroAtomico + " Atomo: " + this.Nome + " Sigla: " + this.Sigla + " Grupo: " + this.grupo.Nome);
    }

}

