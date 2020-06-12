using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CofreLlave : MonoBehaviour
{
    
    public InventarioJugador inventarioJugador;
    public bool jugadorEnRango;
    public Objeto contenido;
    public static bool estaAbierto;
    public GameObject cajaDialogo;
    public Text dialogoTexto;
    private Animator animacion;
    public Senial levantarObjeto;
    public MoverPersonaje moverPersonaje;
    public FisicasObjetosSuelo fisicaObjetosSuelo;
    
    
    void Start()
    {
        animacion = GetComponent<Animator>();

        // Update is called once per frame
       
    }
    void Update()
    {
        if (estaAbierto)
        {
            animacion.SetBool("abierto", true);
        }
        if (Input.GetKeyDown(KeyCode.E) && jugadorEnRango)
        {
            if (!estaAbierto)
            {
                abrirCofre();
            }
            else
            {
                cofreYaEstaAbierto();
            }
        }
    }
    public void abrirCofre()
    {
        
        cajaDialogo.SetActive(true);
        dialogoTexto.text = contenido.descripcionItem;
        inventarioJugador.AniadirObjeto(contenido);
        inventarioJugador.objetoActual = contenido;
        levantarObjeto.Raise();
        estaAbierto = true;
        moverPersonaje.movimientoPersonaje = true;
        animacion.SetBool("abierto", true);
        fisicaObjetosSuelo.AniadirLlave(contenido);



    }
    public void cofreYaEstaAbierto()
    {
            moverPersonaje.movimientoPersonaje = false;
            cajaDialogo.SetActive(false);
            levantarObjeto.Raise();
        
    }
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            jugadorEnRango = true;
        }

    }
    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            jugadorEnRango = false;
            StopAllCoroutines();
        }
    }
}
