using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class Molecula
{
    private int id;
	private string nome;

    private static Dictionary<int, Molecula> moleculas;

    private List<AtomoQuantificado> atomosQuantificados;
	
	private List<MoleculaCompoe> moleculasCompoePrimaria = new List<MoleculaCompoe>();

    public string Nome { get => nome; set => nome = value; }
    public int Id { get => id; set => id = value; }
    public List<AtomoQuantificado> AtomosQuantificados { get => atomosQuantificados; set => atomosQuantificados = value; }
    public List<MoleculaCompoe> MoleculasCompoePrimaria { get => moleculasCompoePrimaria; set => moleculasCompoePrimaria = value; }

    public static Dictionary<int, Molecula> todasMoleculas() {
        if (moleculas == null)
        {
            moleculas = new Dictionary<int, Molecula>();

            IDataReader reader = Conexoes.pegarReader("SELECT id, nome FROM molecula");
            while (reader.Read())
            {
                Molecula molecula = new Molecula();
                molecula.Id = reader.GetInt32(0);
                molecula.Nome = reader.GetString(1);
                moleculas[molecula.Id] = molecula;
            }
            Conexoes.fecharConexao();

            foreach (int index in moleculas.Keys){
                moleculas[index].AtomosQuantificados = AtomoQuantificado.carregar(moleculas[index]);
            }

        }

        MoleculaCompoe.carregarComposicao(moleculas);



        return moleculas;
    }

    override
    public string ToString() {
        string nomeMolecula = "";

        for(int i=0,seqAtomo=0, seqMolecula =0; i < AtomosQuantificados.Count + MoleculasCompoePrimaria.Count;i++){
            if(AtomosQuantificados.Count > seqAtomo &&   i == AtomosQuantificados[seqAtomo].Sequencia){
                nomeMolecula += AtomosQuantificados[seqAtomo].ToString();
                seqAtomo++;
            } else if (MoleculasCompoePrimaria.Count > seqMolecula && i == MoleculasCompoePrimaria[seqMolecula].Sequencia){
                nomeMolecula += this.moleculasCompoePrimaria[seqMolecula].ToString();
                seqMolecula++;
            }
        }
        return nomeMolecula;
    }

}

