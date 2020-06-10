using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoPuerta
{
    llave,
    boton
}
public class Puerta : MonoBehaviour
{
    [Header(" Variables de puerta")]
    public Senial interrogacionOn;
    public Senial interrogacionOff;
    public TipoPuerta tipoPuerta;
    public bool abierta = false;
    public bool jugadorEnRango = false;
    public InventarioJugador inventarioJugador;
    public SpriteRenderer spritePuerta;
    public BoxCollider2D fisicasColision;

 

    public void Abrir()
    {
        spritePuerta.enabled = false;
        abierta = true;
        fisicasColision.enabled = false;
    }
   
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (jugadorEnRango&& tipoPuerta == TipoPuerta.llave)
            {
                if (inventarioJugador.numeroLlaves > 0)
                {
                    inventarioJugador.numeroLlaves--;
                    Abrir();
                    for (int c = 0; c <= inventarioJugador.miInventario.Count; c++)
                    {
                        if (inventarioJugador.miInventario[c].esLlave)
                        {
                            inventarioJugador.miInventario.RemoveAt(c);
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            interrogacionOn.Raise();
            jugadorEnRango = true;

        }

    }
    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            interrogacionOff.Raise();
            jugadorEnRango = false;
            StopAllCoroutines();
        }
    }
}
