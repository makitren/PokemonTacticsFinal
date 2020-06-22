using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonJugador : MonoBehaviour
{
    public int nivel;
    public List<Pokemons> misPokemons = new List<Pokemons>();
    public int monedas = Moneda.moneda;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("nivel") + nivel > 1)
        {
            nivel = PlayerPrefs.GetInt("nivel");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
