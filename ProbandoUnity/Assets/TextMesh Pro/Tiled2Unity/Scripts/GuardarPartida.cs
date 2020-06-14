using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GuardarPartida : MonoBehaviour
{
    public QuestGiver questGiver;
    public int oro;
    public CofreLlave cofreLlave;
    public Puerta puerta;
    //Ubicacion del archivo data
    public string keyMisiones;
    public string keyCofres;
    public string keyPuertas;
    public InventarioJugador inventarioJugador;

    private void Start()
    {
        Debug.Log(questGiver.quest.activada);
        Cargar();
    }
    private void Update()
    {
        oro = Moneda.moneda;
    }
    public void Guardar()
    {
        PlayerPrefs.SetInt("monedas", oro);
        PlayerPrefs.SetInt("llaves", inventarioJugador.numeroLlaves);
        if (questGiver.quest.completada)
        {
            PlayerPrefs.SetInt(keyMisiones, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyMisiones, 0);
        }
        if (cofreLlave.estaAbierto)
        {
            PlayerPrefs.SetInt(keyCofres, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyCofres, 0);
        }
        if (puerta.abierta)
        {
            PlayerPrefs.SetInt(keyPuertas, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyPuertas, 0);
        }
        PlayerPrefs.Save();

    }
    public void Cargar()
    {
        oro = PlayerPrefs.GetInt("monedas");
        if (PlayerPrefs.GetInt(keyMisiones) == 1)
        {
            questGiver.quest.completada = true;
        }
        else
        {
            questGiver.quest.completada = false;
        }
        if(PlayerPrefs.GetInt(keyCofres) == 1)
        {
            cofreLlave.estaAbierto = true;
        }
        else
        {
            cofreLlave.estaAbierto = false;
        }
        if (PlayerPrefs.GetInt(keyPuertas) == 1)
        {
            puerta.abierta = true;
        }
        else
        {
            puerta.abierta = false;
        }
        Moneda.moneda = oro;
        inventarioJugador.numeroLlaves = PlayerPrefs.GetInt("llaves");
    }
    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();

    }
}
