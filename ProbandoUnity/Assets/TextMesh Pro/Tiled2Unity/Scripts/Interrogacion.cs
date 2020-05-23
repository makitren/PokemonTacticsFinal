using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrogacion : MonoBehaviour
{
    public GameObject interrogacion;
    public void Enable()
    {
        interrogacion.SetActive(true);
    }
    public void Disable()
    {
        interrogacion.SetActive(false);
    }
}
