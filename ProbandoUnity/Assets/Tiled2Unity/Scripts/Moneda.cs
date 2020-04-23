
using UnityEngine;
using TMPro;

public class Moneda : MonoBehaviour
{
    public int moneda = 0;
    public TextMeshProUGUI textoMonedas;

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(textoMonedas);
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        
            if (otro.CompareTag("Monedas"))
            {
            moneda++;
            textoMonedas.text = "Monedas: "+moneda.ToString();
           
            Destroy(otro.gameObject);
           
            
        }
    }
}
