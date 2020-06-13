using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDialogoPersonaje : MonoBehaviour
{
    public DialogoPersonajes dialogo;
    public Senial interrogacionOn;
    public Senial interrogacionOff;
    Queue<string> frases;
    public GameObject panelDialogo;
    public Text salidaTexto;
    string fraseActiva;
    public float velocidadFrase;
    public bool jugadorEnRango;
    public MoverPersonaje moverPersonaje;
    public QuestGiver questGiver;
    void Start()
    {
        frases = new Queue<string>();

    }
    void ComenzarDialogo()
    {
        frases.Clear();
        foreach(string frase in dialogo.listaFrases)
        {
            frases.Enqueue(frase);

        }

        SacarSiguienteFrase();
    }
    void SacarSiguienteFrase()
    {
        if (frases.Count <= 0)
        {
            salidaTexto.text = fraseActiva;
            return;
        }
        fraseActiva = frases.Dequeue();
        salidaTexto.text = fraseActiva;

        StopAllCoroutines();
        StartCoroutine(SonidoFrase(fraseActiva));
       
    }

    IEnumerator SonidoFrase(string frase)
    {
        salidaTexto.text = "";
        foreach(char letra in frase.ToCharArray())
        {
            salidaTexto.text += letra;
           //sonido.PlayOneShot(sonidoHabla);
            yield return new WaitForSeconds(velocidadFrase);
        }
    }

    
    void Update()
    {
        if (questGiver.quest.completada)
        {
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E) && jugadorEnRango)
        {
            if (panelDialogo.activeInHierarchy)
            {
                panelDialogo.SetActive(false);
                if (this.gameObject.GetComponent<ComenzarCombate>() != null&&! ComenzarCombate.derrotado)
                {
                    this.gameObject.GetComponent<ComenzarCombate>().EmpezarCombate();
                }
            }
            else
            {
                panelDialogo.SetActive(true);
                ComenzarDialogo();
                interrogacionOff.Raise();
                //salidaTexto.text = frases.ToString();

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
            panelDialogo.SetActive(false);
            StopAllCoroutines();
            
        }
    }
    private void OnTriggerStay2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return) && salidaTexto.text == fraseActiva)
            {
                SacarSiguienteFrase();
            }
        }
        else
        {

            if (panelDialogo.activeInHierarchy == true)
            {
                moverPersonaje.movimientoPersonaje = true;
                moverPersonaje.animacion.SetBool("andando", false);
            }
            else
            {
                moverPersonaje.movimientoPersonaje = false;
                moverPersonaje.animacion.SetBool("andando", false);
            }
        }

    }
    public void EmpezarCombate()
    {
        SceneManager.LoadScene("Combate");
    }
}
