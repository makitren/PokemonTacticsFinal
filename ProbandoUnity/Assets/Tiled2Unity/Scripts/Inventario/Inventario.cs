using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName ="Nuevo Item",menuName ="Inventario")]
public class Inventatio : ScriptableObject
{
    public string nombreItem;
    public string descripcionItem;
    public Sprite item;
    public int idinv;
    public bool usable;
    public bool unico;
    public UnityEvent thisEvent;

    public void Use()
    {
        thisEvent.Invoke();
    }
}
