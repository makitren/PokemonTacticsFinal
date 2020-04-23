using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float suavidad;
    public Vector2 posicionMaxima;
    public Vector2 posicionMinima;

    private void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 posicionObjetivo = new Vector3(target.position.x, 
                target.position.y, transform.position.z);
             

            posicionObjetivo.x = Mathf.Clamp(posicionObjetivo.x,
                posicionMinima.x, posicionMaxima.x);

            posicionObjetivo.y = Mathf.Clamp(posicionObjetivo.y,
                posicionMinima.y, posicionMaxima.y);

            transform.position = Vector3.Lerp(transform.position,
                posicionObjetivo, suavidad);
        }
    }
    

}
