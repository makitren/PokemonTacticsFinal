
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject gameObject;
   public void Jugar()
    {
        if (PlayerPrefs.GetString("escena").Length!=0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("escena"));

        }
        else
        {
            SceneManager.LoadScene("PrimerMapaUnity");
        }
        
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
