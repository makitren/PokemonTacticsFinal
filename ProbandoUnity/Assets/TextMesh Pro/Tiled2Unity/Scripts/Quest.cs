using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    public bool activada;
    public string titulo;
    public string desc;
    public int oroRecibido;
    public bool completada;

    public QuestGoal questGoal;

    public void Completada()
    {
        activada = false;
        completada = true;
        Debug.Log(titulo+" ha sido completada");
    }
}
