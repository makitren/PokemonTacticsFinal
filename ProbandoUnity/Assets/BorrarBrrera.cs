using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarBrrera : MonoBehaviour
{
    public QuestGiver quest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.quest.completada)
        {
            gameObject.SetActive(false);
        }
    }
}
