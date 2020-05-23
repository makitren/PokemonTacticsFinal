using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Objeto", menuName = "Inventario/Objeto")]
public class InventarioJugador : ScriptableObject
{
    public Objeto objetoActual;
    public List<Objeto> miInventario = new List<Objeto>();
    public int numeroLlaves;

    public void AniadirObjeto(Objeto objetoParaAniadir)
    {
        if (objetoParaAniadir.esLlave)
        {
            numeroLlaves++;
        }
        else
        {
            if (!miInventario.Contains(objetoParaAniadir))
            {
                miInventario.Add(objetoParaAniadir); 
            }
        }
    }
}
