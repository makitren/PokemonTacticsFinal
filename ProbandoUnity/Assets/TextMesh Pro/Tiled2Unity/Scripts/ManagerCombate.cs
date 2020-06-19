
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCombate : MonoBehaviour
{
    public Pokemons pokemons;
    public Button boton;
    public List<Pokemons> tiendaPokemon = new List<Pokemons>();
    public PokemonJugador pokemonJugador;
    public PokemonsEnemigo pokemonsEnemigo;
    public Image image;
    public Text text;
    public Text precio;
    public ManagerTienda manager;
    void Awake()
    {
        int numRndom = UnityEngine.Random.Range(0, tiendaPokemon.Count);
        image.sprite = tiendaPokemon[numRndom].sprite;
        text.text = tiendaPokemon[numRndom].nombre;
        precio.text = tiendaPokemon[numRndom].precio.ToString();
        pokemons = tiendaPokemon[numRndom];
        Debug.Log(pokemons.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
     public void Comprar()
    {
        if (pokemonJugador.nivel > pokemonJugador.misPokemons.Count&&Moneda.moneda>=0&&Moneda.moneda-pokemons.precio>=0)
        {
            Moneda.moneda = Moneda.moneda - pokemons.precio;
            pokemonJugador.misPokemons.Add(pokemons);
            manager.MisPokemons();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Necesitas mas nivel o no tienes dinero suficiente");
        }


    }
    public void Actualizar()
    {
        int numRndom = UnityEngine.Random.Range(0, tiendaPokemon.Count);
        image.sprite = tiendaPokemon[numRndom].sprite;
        text.text = tiendaPokemon[numRndom].nombre;
        precio.text = tiendaPokemon[numRndom].precio.ToString();
        pokemons = tiendaPokemon[numRndom];
        Debug.Log(pokemons.name);
    }
}
