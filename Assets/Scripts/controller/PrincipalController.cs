using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace controller
{
    public class PrincipalController : MonoBehaviour
    {
        public static List<Jogador> jogadores;
        public static bool jogada = false;
        public static int idCor = -1;
        
        // Start is called before the first frame update
        void Start()
        {
            jogadores = new List<Jogador>();
        }
        
        public void umJogador()
        {
            Jogador jogadorUm = new Jogador(0,0);
            jogadores.Add(jogadorUm);
            SceneManager.LoadScene(5);
        }
    
        public void doisJogadores()
        {
            Jogador jogadorUm = new Jogador(0,0);
            jogadores.Add(jogadorUm);
            
            Jogador jogadorDois = new Jogador(0,0);
            jogadores.Add(jogadorDois);
            
            SceneManager.LoadScene(5);
        }
    
        public void regras()
        {
            SceneManager.LoadScene(4);
        }
    
        public void balanceamento()
        {
            SceneManager.LoadScene(0);
        }
    
        public void pontuacao()
        {
            SceneManager.LoadScene(2);
        }
    
        public void sobre()
        {
            SceneManager.LoadScene(6);
        }
    }
}