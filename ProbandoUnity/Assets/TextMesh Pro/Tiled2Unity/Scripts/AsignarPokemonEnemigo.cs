using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarPokemonEnemigo : MonoBehaviour
{
    public PokemonsEnemigo pokemonsEnemigo;
    public PokemonJugador pokemonJugador;
    public List<GameObject> pokemonEnemigoPlantilla = new List<GameObject>();
    public List<PokemonEnemigosDatos> pokemonEnemigosList = new List<PokemonEnemigosDatos>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AparecerPokemon()
    {
         for (int c = 0; c < pokemonsEnemigo.pokemons.Count; c++)
         {
                Debug.Log(c);
                pokemonEnemigosList[c].ataque = pokemonsEnemigo.pokemons[c].daño;
                pokemonEnemigosList[c].vida = pokemonsEnemigo.pokemons[c].vida;
                pokemonEnemigosList[c].anm = pokemonsEnemigo.pokemons[c].anmin.GetComponent<Animator>();
                pokemonEnemigosList[c].sprite = pokemonsEnemigo.pokemons[c].sprite;
            pokemonEnemigosList[c].name = pokemonsEnemigo.pokemons[c].name;
           
         }
        for (int c = 0; c < pokemonJugador.nivel; c++)
        {

            pokemonEnemigoPlantilla[c].SetActive(true);
        }
    }
}
