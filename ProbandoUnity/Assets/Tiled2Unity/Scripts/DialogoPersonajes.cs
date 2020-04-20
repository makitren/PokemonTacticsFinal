
using UnityEngine;

[System.Serializable]

public class DialogoPersonajes
{
    public string nombrePersonaje;
    [TextArea(3,10)]//Determina valor minimo y maximo que puede tener cada recuadro de texto
    public string[] listaFrases;


}
