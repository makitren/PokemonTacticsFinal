using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivadoMisiones : MonoBehaviour
{
    public Senial interrogacionOn;
    public Senial interrogacionOff;
    public bool jugadorEnRango;
    Queue<string> frases;
    public GameObject panelDialogo;
    public DialogoPersonajes dialogo;
    public Text salidaTexto;
    string fraseActiva;
    public float velocidadFrase;
    public QuestGiver questGiver;
    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();
    }
    void ComenzarDialogo()
    {
        frases.Clear();
        foreach (string frase in dialogo.listaFrases)
        {
            frases.Enqueue(frase);

        }

        SacarSiguienteFrase();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorEnRango && !questGiver.quest.activada && !questGiver.quest.completada)
        {
           
            questGiver.AbrirVentataQuest();
            

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && jugadorEnRango)
            {
                if (panelDialogo.activeInHierarchy)
                {
                    panelDialogo.SetActive(false);
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
            questGiver.questWindows.SetActive(false);
        }
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
        foreach (char letra in frase.ToCharArray())
        {
            salidaTexto.text += letra;
            //sonido.PlayOneShot(sonidoHabla);
            yield return new WaitForSeconds(velocidadFrase);
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
                questGiver.moverPersonaje.movimientoPersonaje = true;
                questGiver.moverPersonaje.animacion.SetBool("andando", false);
            }
            else
            {
                questGiver.moverPersonaje.movimientoPersonaje = false;
                questGiver.moverPersonaje.animacion.SetBool("andando", false);
            }
        }

    }
}
