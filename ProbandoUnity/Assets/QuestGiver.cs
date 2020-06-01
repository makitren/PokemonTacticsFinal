using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public MoverPersonaje moverPersonaje;
    public GameObject questWindows;
    public TextMeshProUGUI titletext;
    public TextMeshProUGUI descricionText;
    public TextMeshProUGUI oroTexto;
    public GameObject barreraBorrar;

    public void AbrirVentataQuest()
    {
        moverPersonaje.movimientoPersonaje = true;
        Debug.Log(moverPersonaje.movimientoPersonaje);
        moverPersonaje.animacion.SetBool("andando", false);
        questWindows.SetActive(true);
        titletext.text = quest.titulo;
        descricionText.text = quest.desc;
        oroTexto.text = quest.oroRecibido.ToString();
    }
    public void AceptarMision()
    {
        questWindows.SetActive(false);
        quest.activada = true;
        moverPersonaje.quest = quest;
        if (barreraBorrar)
        {
            Destroy(barreraBorrar);
        }
        
    }

}
