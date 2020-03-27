using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float suavidad;

    private void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 posicionObjetivo = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavidad);
        }
    }
    // Start is called before the first frame update

}
