using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager saveManager;
    public List<ScriptableObject> objets = new List<ScriptableObject>();
    private void Awake()
    {
        if (saveManager == null)
        {
            saveManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
