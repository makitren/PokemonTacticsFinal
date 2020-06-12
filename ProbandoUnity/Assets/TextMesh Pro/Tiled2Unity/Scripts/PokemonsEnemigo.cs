using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonsEnemigo : MonoBehaviour
{
    public List<Pokemons> pokemons = new List<Pokemons>();
    void Start()
    {
        pokemons = ComenzarCombate.pokemonsElegidos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
