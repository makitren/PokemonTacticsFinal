
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velMovimiento = 20f;
    Animator animacion;
    Rigidbody2D rb2d;
    Vector2 movimiento;
    public ValorVector posicionComienzo;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        animacion.SetFloat("movX", 0);
        animacion.SetFloat("movY", -1);
        transform.position = posicionComienzo.valorInicial;
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
        movimiento.Normalize();
        rb2d.MovePosition(rb2d.position + movimiento * velMovimiento * Time.deltaTime);
    }
}
