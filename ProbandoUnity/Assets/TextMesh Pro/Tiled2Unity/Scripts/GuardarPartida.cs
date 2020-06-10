using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GuardarPartida : MonoBehaviour
{
    public Text cantidadOro;
    public int oro;
    public bool misionCompletada;
    //Ubicacion del archivo data
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/save.dat";
    }
    private void Start()
    {
        Cargar();
    }
    private void Update()
    {
        oro = Moneda.moneda;
        misionCompletada = Quest.completada;
        //Muestra la cantidad de oro
        if (cantidadOro != null)
        {
            cantidadOro.text = oro.ToString();
        }
    }
    public void Guardar()
    {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(filePath);
            DataSave data = new DataSave();

            //Datos a guardar
            data.oro = oro;
            data.questComp = misionCompletada;
            bf.Serialize(file, data);
            file.Close();
            Cargar();
    }
    public void Cargar()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            DataSave data = (DataSave)bf.Deserialize(file);
            oro = data.oro;
            misionCompletada = data.questComp;
            Moneda.moneda = oro;
            Quest.completada = misionCompletada;
            file.Close();
        }
    }
    public void BorrarDatos()
    {
        Debug.Log(filePath);
        File.Delete(filePath);
        gameObject.GetComponent<MenuPausa>().SalirAMenu();
    }
}
