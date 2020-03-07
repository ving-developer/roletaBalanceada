using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;


public class MoleculaForma
{
    private int id;
	private string tipo; //Reagente ou Produto

	private int sequencia;

	private int balanco;

    private int resposta;

	private Molecula molecula;

    public string Tipo { get => tipo; set => tipo = value; }
    public int Sequencia { get => sequencia; set => sequencia = value; }
    public int Balanco { get => balanco; set => balanco = value; }
    
    public int Resposta { get => resposta; set => resposta = value; }
    public Molecula Molecula { get => molecula; set => molecula = value; }
    public int Id { get => id; set => id = value; }


  

    public static void carregarMoleculaForma(Equacao equacao) {

        Dictionary<int, Molecula> moleculas = Molecula.todasMoleculas();

            IDataReader reader = Conexoes.pegarReader($"SELECT id, molecula_id, tipo, sequencia, balanco FROM molecula_forma where equacao_id = {equacao.Id} order by sequencia");
            while (reader.Read())
            {
                MoleculaForma moleculaForma = new MoleculaForma();
                moleculaForma.Id = reader.GetInt32(0);
                moleculaForma.Molecula = moleculas[reader.GetInt32(1)];
                moleculaForma.Tipo = reader.GetString(2);
                moleculaForma.Sequencia = reader.GetInt32(3);
                moleculaForma.Resposta = reader.GetInt32(4);
                moleculaForma.Balanco = 0;
                if(moleculaForma.Tipo == "reagente"){
                    equacao.Reagente.Add(moleculaForma);
                } else{
                    equacao.Produto.Add(moleculaForma);
            }

            }
            Conexoes.fecharConexao();

    }

    public List<AtomoQuantificado> quantidadeAtomos() {
        return molecula.quantidadeAtomos(balanco);
    }


    public bool taCerto() {
        return this.Balanco == this.Resposta;
    }

    public void resetarMolecula()
    {
        Balanco = 0;
    }
}

