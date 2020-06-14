﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Build.Content;
using UnityEngine.SceneManagement;

public class GuardarPartida : MonoBehaviour
{
    public QuestGiver questGiver;
    public CofreLlave cofreLlave;
    public Puerta puerta;
    //Ubicacion del archivo data
    public string keyMisiones;
    public string keyCofres;
    public string keyPuertas;
    public InventarioJugador inventarioJugador;
    public GameObject mensajeGuardado;
    public string escenaGuardar;
    private void Start()
    {
        Cargar();
    }
    private void Update()
    {
    }
    public void Guardar()
    {
        PlayerPrefs.SetString("escena", escenaGuardar);   
        PlayerPrefs.SetInt("monedas", Moneda.moneda);
        PlayerPrefs.SetInt("llaves", inventarioJugador.numeroLlaves);
        if (questGiver != null)
        {
            if (questGiver.quest.completada)
            {
                PlayerPrefs.SetInt(keyMisiones, 1);
            }
            else
            {
                PlayerPrefs.SetInt(keyMisiones, 0);
            }
        }
        if (cofreLlave != null)
        {
            if (cofreLlave.estaAbierto)
            {
                PlayerPrefs.SetInt(keyCofres, 1);
            }
            else
            {
                PlayerPrefs.SetInt(keyCofres, 0);
            }
        }
        if (puerta != null)
        {
            if (puerta.abierta)
            {
                PlayerPrefs.SetInt(keyPuertas, 1);
            }
            else
            {
                PlayerPrefs.SetInt(keyPuertas, 0);
            }
        }
        PlayerPrefs.Save();
        StartCoroutine(mensajeGuardar());

    }
    public void Cargar()
    {
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
        inventarioJugador.numeroLlaves = PlayerPrefs.GetInt("llaves");
    }
    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();

    }
    IEnumerator mensajeGuardar()
    {
        Debug.Log("entro");
        mensajeGuardado.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        mensajeGuardado.SetActive(false);
    }
}
