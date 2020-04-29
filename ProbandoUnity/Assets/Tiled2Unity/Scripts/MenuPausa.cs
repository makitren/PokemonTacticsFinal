using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private bool enPausa;
    public GameObject panelPausa;
    public string menuPrincipal;
    void Start()
    {
        enPausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pausa"))
        {
            Continuar();
        }
    }
    public void Continuar()
    {
        enPausa = !enPausa;
        if (enPausa)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void SalirAMenu()
    {
        SceneManager.LoadScene(menuPrincipal);
        Time.timeScale = 1f;
    }
}
