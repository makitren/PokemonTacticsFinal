using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsignadorPokemons : MonoBehaviour
{
    public List<GameObject> tipos = new List<GameObject>();
    public AsignarPokemonEnemigo asignarPokemon;
    public PokemonJugador pokemonJugador;
    public List<GameObject> pokemonJugadorPlantilla = new List<GameObject>();
    public List<PokemonsMios> pokemonsMios=new List<PokemonsMios>();
    public int vidaAdicional;
    public int dañoAdicional;
    private int fuego, agua, planta, electrico;
    public Text nombreTipo;
    public Text descTipo;
    public GameObject tiendaDesaparece;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EmpezarBatalla()
    {
        tiendaDesaparece.SetActive(false);
        if (pokemonJugador.misPokemons.Count <= pokemonJugador.nivel)
        {
            for (int c = 0; c < pokemonJugador.misPokemons.Count; c++)
            {
                switch (pokemonJugador.misPokemons[c].tipo)
                {
                    case "Fuego":
                        fuego++;
                        break;
                    case "Agua":
                        agua++;
                        break;
                    case "Planta":
                        planta++;
                        break;
                    case "Electrico":
                        electrico++;
                        break;

                }
            }
            if (fuego == 2)
            {
                Debug.Log("Fuego");
                dañoAdicional = 10;
                tipos[0].SetActive(true);
                
            }else if (agua == 2)
            {
                Debug.Log("Agua");
                vidaAdicional =50;
                tipos[1].SetActive(true);

            }
            else if (planta == 2)
            {
                Debug.Log("planta");
                tipos[2].SetActive(true);

            }
            else if (electrico == 2)
            {
                Debug.Log("planta");
                tipos[3].SetActive(true);

            }

            for (int c = 0; c < pokemonJugador.misPokemons.Count; c++)
            {
                Debug.Log(c);
                pokemonsMios[c].ataque = pokemonJugador.misPokemons[c].daño+dañoAdicional;
                pokemonsMios[c].vida = pokemonJugador.misPokemons[c].vida+vidaAdicional;
                pokemonsMios[c].anim = pokemonJugador.misPokemons[c].anmin.GetComponent<Animator>();
                pokemonsMios[c].sprite = pokemonJugador.misPokemons[c].sprite;
                pokemonJugadorPlantilla[c].SetActive(true);
            }

            asignarPokemon.AparecerPokemon();
        }
        else
        {
            Debug.Log("Compra Pokemons");
        }
    }
    public void DescTipoFuego()
    {
        nombreTipo.text = "";
        nombreTipo.text = "Fuego";
        descTipo.text = "";
        descTipo.text = "Al tener varios pokemons tipo fuego el daño de todos tus pokemons se incrementan\n" +
            "2 Pokemons tipo fuego= +10\n" +
            "4 Pokemons tipo fuego= +20";
    }
    public void DescTipoAgua()
    {
        nombreTipo.text = "";
        nombreTipo.text = "Agua";
        descTipo.text = "";
        descTipo.text = "Al tener varios pokemons de tipo agua tu vida aumenta\n" +
            "2 Pokemons tipo Agua= +50\n" +
            "4 Pokemons tipo Agua= +100";
    }
    public void DescTipoPlanta()
    {
        nombreTipo.text = "";
        nombreTipo.text = "Planta";
        descTipo.text = "";
        descTipo.text = "Al tener varios pokemons de planta su tiempo de invelcibilidad aumenta\n" +
            "2 Pokemons tipo Agua= +1\n" +
            "4 Pokemons tipo Agua= +1.5";
    }
    public void DescTipoElectrico()
    {
        nombreTipo.text = "";
        nombreTipo.text = "Electrico";
        descTipo.text = "";
        descTipo.text = "Al tener varios pokemons tipo electrico aumenta tando el ataque como la vida\n" +
            "2 Pokemons tipo Electrico= +5-AD 20 Vida\n" +
            "4 Pokemons tipo Electrico= +10-AD 45 Vida";
    }
}
