using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadoMisiones : MonoBehaviour
{
    public Senial interrogacionOn;
    public Senial interrogacionOff;
    public bool jugadorEnRango;
    public QuestGiver questGiver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorEnRango)
        {
            questGiver.AbrirVentataQuest();
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
