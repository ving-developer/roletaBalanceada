using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;
using System;


public class Conexoes {
    private static string filepath = Application.persistentDataPath + "/bancoQuimico.db";
    private static string urlDataBase = "URI=file:"+ filepath;
    //private static string urlDataBase = "URI=file:bancoQuimico.db";
    private static IDbConnection _connection = null;

    public static IDataReader pegarReader(string query) {
        //Debug.Log(Application.persistentDataPath);
        if (!File.Exists(filepath))
        {
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/bancoQuimico.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);

        }

        /* if (!File.Exists(filepath)){

             // if it doesn't ->

             // open StreamingAssets directory and load the db ->

             WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/bancoQuimico.db");  // this is the path to your StreamingAssets in android

             while (!loadDB.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check

             // then save to Application.persistentDataPath

             File.WriteAllBytes(filepath, loadDB.bytes);
         }*/



        _connection = new SqliteConnection(urlDataBase);

        IDbCommand _command = _connection.CreateCommand();
        _connection.Open();

        _command.CommandText = query;

        IDataReader reader = _command.ExecuteReader();
        return reader;

    }

    public static void executarDML(string query) {

        _connection = new SqliteConnection(urlDataBase);
        _connection.Open();

        IDbCommand _command = _connection.CreateCommand();

        _command.CommandText = query;

        _command.ExecuteNonQuery();
    }


    public static void fecharConexao() {
        _connection.Close();
    }

}
