﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarArea : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public IEnumerator ShowArea(string name)
    {
        anim.Play("AreaShow");
        transform.GetChild(0).GetComponent<Text>().text = name;
        transform.GetChild(1).GetComponent<Text>().text = name;
        yield return new WaitForSeconds(1f);
        anim.Play("AreaFadeOut");
    }
}
