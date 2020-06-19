using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAleatorio : MonoBehaviour
{
    public List<ManagerCombate> managerCombates = new List<ManagerCombate>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActualizarTienda()
    {
        if (Moneda.moneda >= 0&&Moneda.moneda-2>=0)
        {
            Moneda.moneda = Moneda.moneda - 2;
            for (int c = 0; c < managerCombates.Count; c++)
            {
                managerCombates[c].Actualizar();
            }
        }
        else
        {

        }
        
    }
}
