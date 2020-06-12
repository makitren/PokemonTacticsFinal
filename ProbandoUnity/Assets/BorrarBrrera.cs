using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarBrrera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Quest.completada)
        {
            gameObject.SetActive(false);
        }
    }
}
