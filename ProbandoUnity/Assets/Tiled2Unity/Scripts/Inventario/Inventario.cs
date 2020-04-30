using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Nuevo Item",menuName ="Inventario")]
public class NewBehaviourScript : ScriptableObject
{
    public string nombreItem;
    public string descripcionItem;
    public Sprite item;
    public int idinv;
    public bool usable;
    public bool unico;
}
