using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cartel : MonoBehaviour
{
    // Start is called before the first frame update
    public Senial interrogacionOn;
    public Senial interrogacionOff;
    public GameObject cajaDialogo;
    public Text textoDialogo;
    public string dialogo;
    public bool jugadorEnRango;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&jugadorEnRango)
        {
            if (cajaDialogo.activeInHierarchy)
            {
                cajaDialogo.SetActive(false);
            }
            else
            {
                
                cajaDialogo.SetActive(true);
                interrogacionOff.Raise();
                textoDialogo.text = dialogo;
               
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
            cajaDialogo.SetActive(false);
        }
    }
}
