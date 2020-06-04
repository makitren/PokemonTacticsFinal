using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PokemonsMios : Pokemon
{
    public Transform target;
    public string enemigo;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePositions;
    public Animator anim;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag(enemigo).transform;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = anim.runtimeAnimatorController;
        anim = gameObject.GetComponent<Animator>();

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
            Vector3 ventor = Vector3.MoveTowards(transform.position, target.position, movimiento * Time.deltaTime);
            chanageAnimation(ventor-transform.position);
            anim.SetBool("EmpezarBatalla",true);
        }
        else
        {
            anim.SetBool("EmpezarBatalla", false);
        }
    }
    private void SetAnimatorFloat(Vector2 vector)
    {
        anim.SetFloat("movX", vector.x);
        anim.SetFloat("movY", vector.y);
    }
    private void chanageAnimation(Vector2 direccion)
    {
        if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y))
        {
            if (direccion.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            }else if (direccion.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }
        }else if (Mathf.Abs(direccion.x) < Mathf.Abs(direccion.y))
        {
            if (direccion.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }
            else if (direccion.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }
    
}
