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
            /*
             * Esta parte esta comentada porque le pone limites a la camara. Si se quiere que esta parte funcione, 
             * hay que sacar la camara del personaje y ponerla sola. En este caso, las 2 lineas de arriba comenzarian a funcionar. 
             * El problema es que la transicion entre mapas dentro de la misma escena no se queda bien, pero con la camara dentro 
             * del personaje si se queda bien. Mientras la camara este dentro del personaje, las dos primeras lineas no cumplen ninguna funcion 
             

            posicionObjetivo.x = Mathf.Clamp(posicionObjetivo.x,
                posicionMinima.x, posicionMaxima.x);

            posicionObjetivo.y = Mathf.Clamp(posicionObjetivo.y,
                posicionMinima.y, posicionMaxima.y);
                */
                //Estas lineas le ponen suavidad a la camara. Solo funciona si la camara esta fuera del personaje 
            transform.position = Vector3.Lerp(transform.position,
                posicionObjetivo, suavidad);
        }
    }
    

}
