
using UnityEngine;
using UnityEngine.Events;

public class EscuchadorSenial : MonoBehaviour
{
    public Senial senial;
    public UnityEvent senialEvento;
 public void SenialOn()
    {
        senialEvento.Invoke();
    }
    private void OnEnable()
    {
        senial.EscuchadorRegistro(this);
    }
    private void OnDisable()
    {
        senial.EscuchadorDesRegistrar(this);
    }
}
