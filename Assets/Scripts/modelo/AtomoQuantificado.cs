using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class AtomoQuantificado{
    private int id;
	private int quantidade;

	private int sequencia;

	private Atomo atomo;
	
	private Molecula molecula;

    public int Quantidade { get => quantidade; set => quantidade = value; }
    public int Sequencia { get => sequencia; set => sequencia = value; }
    public Atomo Atomo { get => atomo; set => atomo = value; }
    public Molecula Molecula { get => molecula; set => molecula = value; }
    public int Id { get => id; set => id = value; }

    public static List<AtomoQuantificado> carregar(Molecula molecula) {

        List<AtomoQuantificado> atomosQuantificados = new List<AtomoQuantificado>();

        Dictionary<int, Atomo> atomos = Atomo.todosAtomos();

        IDataReader reader = Conexoes.pegarReader("select   id,atomo_id, quantidade, sequencia from atomo_quantificado where molecula_id = " + molecula.Id + " order by sequencia");
        
        while (reader.Read()){
            AtomoQuantificado atomoQuantificado = new AtomoQuantificado();
            atomoQuantificado.Molecula = molecula;
            atomoQuantificado.Id = reader.GetInt32(0);
            atomoQuantificado.Atomo = atomos[reader.GetInt32(1)];
            atomoQuantificado.Quantidade = reader.GetInt32(2);
            atomoQuantificado.Sequencia = reader.GetInt32(3);
            atomosQuantificados.Add(atomoQuantificado);

            }
            Conexoes.fecharConexao();



     
        return atomosQuantificados;

    }

    override
    public string ToString() {
        string numero = quantidade == 1 ? "" : quantidade+"";
        return $"{Atomo.Sigla}{numero}";
    }

}

