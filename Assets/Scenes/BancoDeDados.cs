using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class BancoDeDados : MonoBehaviour
{
    string urlDataBase = "URI=file:MasterSQLite.db";

    void Iniciar() {

        IDbConnection _connection = new SqliteConnection(urlDataBase);

        IDbCommand _command = _connection.CreateCommand();

        string sql;

        _connection.Open();

        // assim só criaremos a tabela uma vez

         sql = "CREATE TABLE IF NOT EXISTS highscores(name VARCHAR(20), score INT)";

        _command.CommandText = sql;

        _command.ExecuteNonQuery();

        Debug.Log("Cheguei");

    }


    public void Inserir() {

        IDbConnection _connection = new SqliteConnection(urlDataBase);

        IDbCommand _command = _connection.CreateCommand();

        string sql = "INSERT INTO highscores(name, score) VALUES(‘Me’, 3000)";

        _command.CommandText = sql;

        _command.ExecuteNonQuery();

    }


    void Recuperar() {

        IDbConnection _connection = new SqliteConnection(urlDataBase);

        IDbCommand _command = _connection.CreateCommand();

        string sqlQuery = "SELECT value, name, randomSequence ” + “FROM PlaceSequence";

        _command.CommandText = sqlQuery;

        IDataReader reader = _command.ExecuteReader();

        while (reader.Read())

        {

            int value = reader.GetInt32(0);

            string name = reader.GetString(1);

            int rand = reader.GetInt32(2);

            Debug.Log( "value = "+value +" name ="+name +" random ="+rand);

        }

    }


    // Start is called before the first frame update
    void Start(){
        Debug.Log("Inicio");
        Iniciar();

    }

    // Update is called once per frame
    void Update(){
        
    }
}
