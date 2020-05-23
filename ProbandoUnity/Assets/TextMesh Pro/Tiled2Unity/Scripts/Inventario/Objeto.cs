using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName ="Nuevo Item",menuName ="Objeto")]
public class Objeto : ScriptableObject
{
    public string nombreItem;
    public string descripcionItem;
    public Sprite item;
    public int idinv;
    public bool usable;
    public bool unico;
    public UnityEvent thisEvent;
    public bool esLlave;

    public void Use()
    {
        thisEvent.Invoke();
    }
}
