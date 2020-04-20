using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    public string escenaCargar;
    public Vector2 posicionJugador;
    public ValorVector memoriaJugador;

    public void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player")&& !otro.isTrigger)
        {
            memoriaJugador.valorInicial = posicionJugador;
            SceneManager.LoadScene(escenaCargar);
        }
    }

}
