using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GuardarInventario : MonoBehaviour
{
    [SerializeField] private InventarioJugador inventarioJugador;

    // Start is called before the first frame update
    private void OnEnable()
    {
        inventarioJugador.miInventario.Clear();
        LoadScriptable();
    }
    private void OnDisable()
    {
        
    }
    public void ResetScriptable()
    {
        int i = 0;
        while(File.Exists(Application.persistentDataPath + string.Format("/{0}.inv",i)))
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
                i++;
            }
        
    }
    public void SaveScriptable()
    {
        ResetScriptable();
        for(int i = 0; i < inventarioJugador.miInventario.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(inventarioJugador.miInventario[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }
    public void LoadScriptable()
    {
        int i = 0;
        while(File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            var temp = ScriptableObject.CreateInstance<Objeto>();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),temp);
            file.Close();
            inventarioJugador.miInventario.Add(temp);
            i++;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
