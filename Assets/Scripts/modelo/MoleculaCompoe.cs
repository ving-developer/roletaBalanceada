using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;


public class MoleculaCompoe{
    private int id;
	private int sequencia;

	private int quantidade;

	private Molecula principal;

	private Molecula secundaria;

    public int Quantidade { get => quantidade; set => quantidade = value; }
    public Molecula Principal { get => principal; set => principal = value; }
    public Molecula Secundaria { get => secundaria; set => secundaria = value; }
    public int Sequencia { get => sequencia; set => sequencia = value; }
    public int Id { get => id; set => id = value; }

    public static void carregarComposicao(Dictionary<int, Molecula> moleculas) {

        List<MoleculaCompoe> moleculaCompoe = new List<MoleculaCompoe>();

        Dictionary<int, Atomo> atomos = Atomo.todosAtomos();

        IDataReader reader = Conexoes.pegarReader("select id, molecula_principal_id,molecula_secundaria_id, quantidade, sequencia from molecula_compoe order by molecula_principal_id, sequencia ");

        while (reader.Read())
        {
            MoleculaCompoe moleculaComp = new MoleculaCompoe();
            moleculaComp.Id = reader.GetInt32(0);
            moleculaComp.Principal = moleculas[reader.GetInt32(1)];
            moleculaComp.Secundaria = moleculas[reader.GetInt32(2)];
            moleculaComp.Quantidade = reader.GetInt32(3);
            moleculaComp.Sequencia = reader.GetInt32(4);
            moleculas[reader.GetInt32(1)].MoleculasCompoePrimaria.Add(moleculaComp);

        }
        Conexoes.fecharConexao();


    }

    override
    public string ToString() {
        string numero = quantidade == 1 ? "" : quantidade + "";
        return $"({Secundaria.ToString()}){numero}";
    }

}

