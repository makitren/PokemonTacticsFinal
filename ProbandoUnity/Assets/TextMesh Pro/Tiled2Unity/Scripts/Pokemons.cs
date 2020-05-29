using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Nuevo Pokemon", menuName = "Pokemon")]

public class Pokemons:ScriptableObject
{
    public string nombre;
    public int vida;
    public int daño;
    public int precio;
    public Sprite sprite;
    public string tipo;
}
