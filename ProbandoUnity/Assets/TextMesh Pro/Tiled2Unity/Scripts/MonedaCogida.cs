using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaCogida : MonoBehaviour
{
    public GameObject moneda;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(moneda);
    
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
