using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsignarMonedas : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;
    void Start()
    {
        textoMonedas.text = "Monedas: "+Moneda.moneda.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
