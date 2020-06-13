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
    //Ubicacion del archivo data
    private string filePath;
    public string keyMisiones;
    public string keyCofres;
    public string keyPuertas;

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
        Moneda.moneda = oro;
    }
    public void BorrarDatos()
    {
        Debug.Log(filePath);
        File.Delete(filePath);
        Moneda.moneda = 0;
        questGiver.quest.completada = false;
        cofreLlave.estaAbierto = false;
    }
}
