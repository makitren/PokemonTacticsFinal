using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager saveManager;
    public List<GameObject> objets = new List<GameObject>();
    private void Awake()
    {
        DontDestroyOnLoad(objets[0]);
    }
}
