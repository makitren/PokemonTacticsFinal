using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{

    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;

    [Header("Variables del item")]
    public Inventatio thisitem;
    public ManagerInventario thisManager;

    public void Setup(Inventatio newItem,ManagerInventario newManager)
    {
        thisitem = newItem;
        thisManager = newManager;
        if (thisitem)
        {
            itemImage.sprite = thisitem.item;
            itemNameText.text = "" + thisitem.idinv;
        }
    }

    public void ClickedOn()
    {
        if (thisitem)
        {
            thisManager.SetupDesctiptionAndButton(thisitem.descripcionItem, thisitem.usable);
        }
        else
        {
            itemNameText.text = "error";
        }

    }
}
