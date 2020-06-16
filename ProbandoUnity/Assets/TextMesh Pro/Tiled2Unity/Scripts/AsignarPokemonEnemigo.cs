using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsignarPokemonEnemigo : MonoBehaviour
{
    public PokemonsEnemigo pokemonsEnemigo;
    public PokemonJugador pokemonJugador;
    public GuardarPartida guardarPartida;
    public List<GameObject> pokemonEnemigoPlantilla = new List<GameObject>();
    public List<PokemonEnemigosDatos> pokemonEnemigosList = new List<PokemonEnemigosDatos>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pokemonsEnemigo.pokemons.Count == 0)
        {
            ComenzarCombate.derrotado = true;
            pokemonJugador.nivel++;
            guardarPartida.Guardar();
            SceneManager.LoadScene(ComenzarCombate.escena);
        }
    }
    public void AparecerPokemon()
    {
         for (int c = 0; c < pokemonsEnemigo.pokemons.Count; c++)
         {
                Debug.Log(pokemonsEnemigo.pokemons[c].name);
                pokemonEnemigosList[c].nombre = pokemonsEnemigo.pokemons[c].name;
                pokemonEnemigosList[c].ataque = pokemonsEnemigo.pokemons[c].daño;
                pokemonEnemigosList[c].vida = pokemonsEnemigo.pokemons[c].vida;
                pokemonEnemigosList[c].anm = pokemonsEnemigo.pokemons[c].anmin.GetComponent<Animator>();
                pokemonEnemigosList[c].sprite = pokemonsEnemigo.pokemons[c].sprite;
                pokemonEnemigoPlantilla[c].SetActive(true);
                Debug.Log(pokemonEnemigosList[c].name);

        }
    }
}
