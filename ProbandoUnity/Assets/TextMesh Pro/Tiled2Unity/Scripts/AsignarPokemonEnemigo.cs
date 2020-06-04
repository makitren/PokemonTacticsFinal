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
        if (pokemonsEnemigo.pokemons.Count == pokemonJugador.nivel)
        {
            for (int c = 0; c < pokemonsEnemigo.pokemons.Count; c++)
            {

                pokemonEnemigosList[c].ataque = pokemonsEnemigo.pokemons[c].daño;
                pokemonEnemigosList[c].vida = pokemonsEnemigo.pokemons[c].vida;
                pokemonEnemigosList[c].anm = pokemonsEnemigo.pokemons[c].anmin.GetComponent<Animator>();
                pokemonEnemigosList[c].sprite = pokemonsEnemigo.pokemons[c].sprite;
            }


        }
        Debug.Log("Entro");
        for (int c = 0; c < pokemonsEnemigo.pokemons.Count; c++)
        {

            pokemonEnemigoPlantilla[c].SetActive(true);
        }
    }
}
