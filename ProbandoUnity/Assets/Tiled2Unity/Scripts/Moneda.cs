
using UnityEngine;
using TMPro;
using System.Data.Common;
using System.Threading;

public class Moneda : MonoBehaviour
{
    static public int moneda = 0;
    public TextMeshProUGUI textoMonedas;
    public GameObject mision;
    public MoverPersonaje moverPersonaje;

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        
          
        if (otro.CompareTag("Monedas"))
            {
            moneda++;
            textoMonedas.text = "Monedas: "+moneda.ToString();
            otro.gameObject.SetActive(false);
            if (moverPersonaje.quest.activada)
            {
                moverPersonaje.quest.questGoal.CojerMonedas();
                if (moverPersonaje.quest.questGoal.IsReached())
                {
                    moneda++;
                    moverPersonaje.quest.Completada();
                    textoMonedas.text = "Monedas: " + moneda.ToString();
                    mision.SetActive(true);
                }
            }
        }
    }

}
