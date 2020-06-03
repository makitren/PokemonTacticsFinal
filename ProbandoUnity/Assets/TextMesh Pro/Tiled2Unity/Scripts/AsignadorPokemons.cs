using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignadorPokemons : MonoBehaviour
{
    public PokemonJugador pokemonJugador;
    public List<GameObject> pokemonJugadorPlantilla = new List<GameObject>();
    public List<PokemonsMios> pokemonsMios=new List<PokemonsMios>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EmpezarBatalla()
    {
        if (pokemonJugador.misPokemons.Count == pokemonJugador.nivel)
        {
            for (int c = 0; c < pokemonJugador.misPokemons.Count; c++)
            {
                Debug.Log(c);
                pokemonsMios[c].ataque = pokemonJugador.misPokemons[c].daño;
                pokemonsMios[c].vida = pokemonJugador.misPokemons[c].vida;
                pokemonsMios[c].anim = pokemonJugador.misPokemons[c].anmin.GetComponent<Animator>();
                pokemonsMios[c].sprite = pokemonJugador.misPokemons[c].sprite;
                pokemonJugadorPlantilla[c].SetActive(true);
            }


        }
        else
        {
            Debug.Log("Compra Pokemons");
        }
    }
}
