using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    public static NoDestruir noDestruir;
    private void Awake()
    {
        if (noDestruir == null)
        {
            noDestruir = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (noDestruir != this)
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
