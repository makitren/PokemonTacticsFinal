using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComenzarCombate : MonoBehaviour
{

    public List<Pokemons> pokemonsEnemigos = new List<Pokemons>();
    public static List<Pokemons> pokemonsElegidos = new List<Pokemons>();
    public GuardarPartida guardarPartida;
    public static bool derrotado;
    public string escenaPoner;
    public static string escena;
    public bool combt;
    public static string key;
    void Start()
    {
        if (derrotado == true)
        {
            Debug.Log("GUARDO BIEN");
            combt = true;
        }
        else if(PlayerPrefs.GetInt(guardarPartida.keyCombate) != 0 && PlayerPrefs.GetInt(guardarPartida.keyCombate) != 1)
        {
            Debug.Log("NO GUARDO BIEN");
            derrotado = false;
        }else{
            Debug.Log("Aqui me quedo");
        }

        escena = escenaPoner;
        pokemonsElegidos = pokemonsEnemigos;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void EmpezarCombate()
    {
        this.gameObject.GetComponent<ControladorDialogoPersonaje>().EmpezarCombate();
    }
}
