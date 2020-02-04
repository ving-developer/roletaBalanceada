using UnityEngine;
using UnityEngine.SceneManagement;
namespace controller
{
    public class PrincipalController : MonoBehaviour
    {
        // Start is called before the first frame update
        public void umJogador()
        {
            SceneManager.LoadScene(5);
        }
    
        public void doisJogadores()
        {
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