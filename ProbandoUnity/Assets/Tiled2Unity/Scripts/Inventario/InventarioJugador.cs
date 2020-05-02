using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Inventario", menuName = "Inventario/Jugador")]
public class InventarioJugador : ScriptableObject
{
    public List<Inventatio> miInventario = new List<Inventatio>();
}
