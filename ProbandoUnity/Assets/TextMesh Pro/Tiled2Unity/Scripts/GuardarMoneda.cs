using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarMoneda : MonoBehaviour
{
    public bool cogida;
    public string nombreMoneda;
    void Start()
    {
        CargarMonedas();
        if (cogida)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GuardarMonedaMapa()
    {
        if (cogida)
        {
            PlayerPrefs.SetInt(nombreMoneda, 1);
        }
        else
        {
            PlayerPrefs.SetInt(nombreMoneda, 0);
        }
    }
    public void CargarMonedas()
    {
        if (PlayerPrefs.GetInt(nombreMoneda) == 1)
        {
            cogida = true;
        }else if (PlayerPrefs.GetInt(nombreMoneda) == 0)
        {
            cogida = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cogida = true;
            GuardarMonedaMapa();
        }
    }
}
