using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class Conexoes {
    private static string urlDataBase = "URI=file:bancoQuimico.db";
    private static IDbConnection _connection = null;

    public static IDataReader pegarReader(string query) {
        _connection = new SqliteConnection(urlDataBase);

        IDbCommand _command = _connection.CreateCommand();
        _connection.Open();

        _command.CommandText = query;

        IDataReader reader = _command.ExecuteReader();
        return reader;

    }

    public static void fecharConexao() {
        _connection.Close();
    }

}
