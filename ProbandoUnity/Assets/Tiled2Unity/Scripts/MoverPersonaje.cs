using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velMovimiento = 20f;
    Animator animacion;
    Rigidbody2D rb2d;
    Vector2 movimiento;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        if(movimiento!= Vector2.zero)
        {
            animacion.SetFloat("movX", movimiento.x);
            animacion.SetFloat("movY", movimiento.y);
            animacion.SetBool("andando", true);
        }
        else
        {
            animacion.SetBool("andando", false);
        }


    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movimiento * velMovimiento * Time.deltaTime);
    }
}
