﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    public ComenzarCombate comenzarCombate;
    public string escenaGuardar;
    public string keyCombate;
    public PokemonJugador pokemonJugador;
    public GuardarInventario guardarInventario;
    public guardarPosicion guardarPosicion;
    private void Start()
    {
        if (ComenzarCombate.derrotado == true)
        {
            Guardar();
            ComenzarCombate.derrotado = false;
        }
        Cargar();
    }
    private void Update()
    {
    }
    public void Guardar()
    {
        guardarPosicion.GuardarDatos();
        PlayerPrefs.SetString("escena", escenaGuardar);   
        PlayerPrefs.SetInt("monedas", Moneda.moneda);
        PlayerPrefs.SetInt("llaves", inventarioJugador.numeroLlaves);
        if (guardarInventario != null)
        {
            guardarInventario.SaveScriptable();
        }
        if (pokemonJugador!=null)
        {
            PlayerPrefs.SetInt("nivel", pokemonJugador.nivel);
        }
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
        if (comenzarCombate != null)
        {
            if (comenzarCombate.combt)
            {
                Debug.Log("Guardo");
                PlayerPrefs.SetInt(keyCombate, 1);
            }
            else
            {
                PlayerPrefs.SetInt(keyCombate, 0);
            }
        }
            
        
        PlayerPrefs.Save();
        if (mensajeGuardado != null)
        {
            StartCoroutine(mensajeGuardar());
        }

    }
    public void Cargar()
    {
        if (questGiver != null)
        {
            if (PlayerPrefs.GetInt(keyMisiones) == 1)
            {
                questGiver.quest.completada = true;
            }
            else
            {
                questGiver.quest.completada = false;
            }
        }
        if (cofreLlave != null)
        {
            if (PlayerPrefs.GetInt(keyCofres) == 1)
            {
                cofreLlave.estaAbierto = true;
            }
            else
            {
                cofreLlave.estaAbierto = false;
            }
        }
        if (puerta != null)
        {
            if (PlayerPrefs.GetInt(keyPuertas) == 1)
            {
                puerta.abierta = true;
            }
            else
            {
                puerta.abierta = false;
            }
        }
        if (comenzarCombate!=null)
        {
            if (PlayerPrefs.GetInt(keyCombate) == 1)
            {
                Debug.Log("Guardo Combate");
                comenzarCombate.combt = true;
            }
            else if(PlayerPrefs.GetInt(keyCombate)==0)
            {
                Debug.Log("No guarda combate");
                comenzarCombate.combt = false;
            }
        }
        if (pokemonJugador != null&&pokemonJugador.nivel!=1)
        {
            pokemonJugador.nivel = PlayerPrefs.GetInt("nivel");
        }
        inventarioJugador.numeroLlaves = PlayerPrefs.GetInt("llaves");
    }
    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();

    }
    IEnumerator mensajeGuardar()
    {
        mensajeGuardado.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        mensajeGuardado.SetActive(false);
    }
}
