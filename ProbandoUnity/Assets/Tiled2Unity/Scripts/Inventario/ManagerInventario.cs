﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerInventario : MonoBehaviour
{
    [Header("Informacion Inventario")]
    public InventarioJugador inventarioJugador;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPane;
    [SerializeField] private TextMeshProUGUI desciptionItems;
    [SerializeField] private GameObject useButton;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        desciptionItems.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }
    void MakeInventorySlots()
    {
        if (inventarioJugador)
        {
            for(int i = 0; i < inventarioJugador.miInventario.Count; i++)
            {
                GameObject gameObject = Instantiate(blankInventorySlot,inventoryPane.transform.position,Quaternion.identity);
                gameObject.transform.SetParent(inventoryPane.transform);
                SlotInventario slotInventario = gameObject.GetComponent<SlotInventario>();
                if (slotInventario)
                {
                    slotInventario.Setup(inventarioJugador.miInventario[i], this);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("",false);
    }
    
    public void SetupDesctiptionAndButton(string newDescriptionText,bool isButtonUsable) 
    {
        desciptionItems.text = newDescriptionText;
        useButton.SetActive(isButtonUsable);
    }
}
