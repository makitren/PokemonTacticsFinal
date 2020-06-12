using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComenzarCombate : MonoBehaviour
{

    public List<Pokemons> pokemonsEnemigos = new List<Pokemons>();
    public static List<Pokemons> pokemonsElegidos = new List<Pokemons>();
    public static bool derrotado;
    public string escenaPoner;
    public static string escena;
    void Start()
    {
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
