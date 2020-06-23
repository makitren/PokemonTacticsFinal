using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardarPosicion : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    public float y;
    public Vector2 vector;
    public static bool cargado;
    void Start()
    {
        if (cargado == false)
        {
            x = PlayerPrefs.GetFloat("x");
            y = PlayerPrefs.GetFloat("y");
            CargarDatos();
            cargado = true;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GuardarDatos()
    {
        x = transform.position.x;
        y = transform.position.y;
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
    }
    public void CargarDatos()
    {
        if (PlayerPrefs.GetFloat("y") != 0 && PlayerPrefs.GetFloat("x") != 0)
        {
            x = PlayerPrefs.GetFloat("x");
            y = PlayerPrefs.GetFloat("y");
            vector.x = x;
            vector.y = y;
            transform.position = vector;
        }
    }
}
