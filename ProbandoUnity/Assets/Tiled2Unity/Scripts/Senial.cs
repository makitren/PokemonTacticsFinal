
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Senial : ScriptableObject
{
    public List<EscuchadorSenial> escuchadores = new List<EscuchadorSenial>();

    public void Raise()
    {
        for(int i = escuchadores.Count - 1; i >= 0; i--)
        {
            escuchadores[i].SenialOn();
        }
    }
    public void EscuchadorRegistro(EscuchadorSenial escuchador)
    {
        escuchadores.Add(escuchador);
    }
    public void EscuchadorDesRegistrar(EscuchadorSenial escuchador)
    {
        escuchadores.Remove(escuchador);
    }
}
