
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject gameObject;
   public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Partidas()
    {
        this.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
