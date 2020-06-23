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
    public MoverPersonaje personaje;
    public Vector2 pocJug;
    public static Vector2 psjug;
     void Awake()
    {
        psjug = pocJug;
        if (derrotado == true)
        {
            Debug.Log("GUARDO BIEN");
            combt = true;
            guardarPartida.Guardar();
            derrotado = false;
        }

        escena = escenaPoner;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void EmpezarCombate()
    {
        if (personaje != null)
        {
            Debug.Log("Entro Aqui");
            guardarPartida.Guardar();
            pokemonsElegidos = pokemonsEnemigos;
            this.gameObject.GetComponent<ControladorDialogoPersonaje>().EmpezarCombate();
        }
        if (personaje.quest.activada)
        {

        }
        else
        {
            guardarPartida.Guardar();
            pokemonsElegidos = pokemonsEnemigos;
            this.gameObject.GetComponent<ControladorDialogoPersonaje>().EmpezarCombate();
        }
        
    }
}
