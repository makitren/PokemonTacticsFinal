using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonsMios : Pokemon
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePositions;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("PokemonEnemigo").transform;
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance();
    }
    void checkDistance()
    {
        if (Vector3.Distance(target.position,transform.position)<=chaseRadius&&Vector3.Distance(target.position,transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.position,movimiento*Time.deltaTime);
        }
    }
}
