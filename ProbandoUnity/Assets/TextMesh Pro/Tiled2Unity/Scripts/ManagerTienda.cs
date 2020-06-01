using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTienda : MonoBehaviour
{
    public Text nivel;
    public Text dinero;
    public PokemonJugador pokemonJugador;
    public List<GameObject> invPokemons = new List<GameObject>();
    public List<Image> imagenPokemons = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dinero.text = Moneda.moneda.ToString();
        nivel.text = pokemonJugador.nivel.ToString();
    }
    public void MisPokemons()
    {
        for(int c = 0; c < pokemonJugador.misPokemons.Count; c++)
        {
            invPokemons[c].SetActive(true);
            imagenPokemons[c].sprite = pokemonJugador.misPokemons[c].sprite;
        }
    }
}
