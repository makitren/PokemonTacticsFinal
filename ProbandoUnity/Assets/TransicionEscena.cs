using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    public string escenaCargar;
    public Vector2 posicionJugador;
    public ValorVector memoriaJugador;
   
    bool start = false;
    bool isFadeIn = false;
    float alpha = 0;
    float fadeTime = 1f;
    GameObject mostrarArea;


    void Awake()
    {
        
        FadeOut();
    }

    IEnumerator OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player")&& !otro.isTrigger)
        {
            otro.GetComponent<Animator>().enabled = false;
            otro.GetComponent<MoverPersonaje>().enabled = false;
            FadeIn();
            yield return new WaitForSecondsRealtime(fadeTime);
            
            memoriaJugador.valorInicial = posicionJugador;
           
            SceneManager.LoadScene(escenaCargar);
            
        }
    }
    private void OnGUI()
    {
        if (!start)
            return;

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isFadeIn)
        {
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            if (alpha < 0) start = false;
        }
    }
    void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }
    void FadeOut()
    {
        isFadeIn = false;
    }

}
