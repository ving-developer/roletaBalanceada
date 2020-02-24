using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace controller
{
    public class PrincipalController : MonoBehaviour
    {
        
        // Start is called before the first frame update
        void Start()
        {
            NucleoController.instance().restartAll();
        }
        
        public void umJogador()
        {
            Jogador jogadorUm = new Jogador(0,0,"Lomonosov");
            NucleoController.instance().jogadores.Add(jogadorUm);
            SceneManager.LoadScene(5);
        }
    
        public void doisJogadores()
        {
            Jogador jogadorUm = new Jogador(0,0,"Lomonosov");
            NucleoController.instance().jogadores.Add(jogadorUm);
            
            Jogador jogadorDois = new Jogador(0,0,"Lavoisier");
            NucleoController.instance().jogadores.Add(jogadorDois);
            
            SceneManager.LoadScene(5);
        }
    
        public void regras()
        {
            SceneManager.LoadScene(4);
        }
    
        public void configuracoes()
        {
            SceneManager.LoadScene(8);
        }
    
        public void pontuacao()
        {
            SceneManager.LoadScene(3);
        }
    
        public void sobre()
        {
            SceneManager.LoadScene(6);
        }
    }
}