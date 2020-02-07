using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;


public class Grupo{
	
	private string nome;

	private int id;

    private static Dictionary<int, Grupo> grupos;

    public string Nome { get => nome; set => nome = value; }
    public int Id { get => id; set => id = value; }



    public static Dictionary<int, Grupo> todosGrupos() {
        if(grupos == null){
            grupos = new Dictionary<int, Grupo>();

            IDataReader reader = Conexoes.pegarReader("select  id, nome from grupo");
            while (reader.Read())
            {
                Grupo grupo = new Grupo();

                grupo.id = reader.GetInt32(0);
                grupo.Nome = reader.GetString(1);
                grupos[grupo.Id] = grupo;

            }

            Conexoes.fecharConexao();

        }
        return grupos;
    }

}

