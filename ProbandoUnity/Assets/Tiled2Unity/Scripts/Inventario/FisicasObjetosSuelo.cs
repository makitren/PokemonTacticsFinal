
using UnityEngine;

public class FisicasObjetosSuelo : MonoBehaviour
{
    [SerializeField] private InventarioJugador inventarioJugador;
    [SerializeField] private Inventatio thisItems;
    // Start is called before the first frame update 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!collision.isTrigger){
            AddItemInventory();
            Destroy(this.gameObject);
        }
    }
    void AddItemInventory()
    {
        if (inventarioJugador && thisItems)
        {
            if (inventarioJugador.miInventario.Contains(thisItems))
            {
                thisItems.idinv += 1;
            }
            else
            {
                inventarioJugador.miInventario.Add(thisItems);
                thisItems.idinv += 1;
            }
        }
    }
}
