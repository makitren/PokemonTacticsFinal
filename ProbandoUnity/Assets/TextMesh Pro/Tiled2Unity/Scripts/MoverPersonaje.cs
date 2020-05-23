
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    
    
    
    public enum EstadoJugador
    {
        andando,
        interactuando,
        parado
    }
    public EstadoJugador estadoActual;
    public float velMovimiento = 20f;
    public int monedas = 0;
    public Quest quest;
    Animator animacion;
    Rigidbody2D rb2d;
    Vector2 movimiento;
    public Moneda moneda;
    public ValorVector posicionComienzo;
    public InventarioJugador inventarioJugador;
    public SpriteRenderer objetoRecibidoSprite;
    public bool movimientoPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        estadoActual = EstadoJugador.parado;
        animacion = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        animacion.SetFloat("movX", 0);
        animacion.SetFloat("movY", -1);
        transform.position = posicionComienzo.valorInicial;
    }
    public void levantarObjeto()
    {
        if (inventarioJugador.objetoActual != null)
        {
        if (estadoActual != EstadoJugador.interactuando)
        {
            animacion.SetBool("ObjetoConseguido", true);
            estadoActual = EstadoJugador.interactuando;
            objetoRecibidoSprite.sprite = inventarioJugador.objetoActual.item;
        }
        else
        {
            animacion.SetBool("ObjetoConseguido", false);
            estadoActual = EstadoJugador.parado;
            objetoRecibidoSprite.sprite = null;
            inventarioJugador.objetoActual = null;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!movimientoPersonaje)
        {
            movimiento = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
            if (movimiento != Vector2.zero)
            {
                animacion.SetFloat("movX", movimiento.x);
                animacion.SetFloat("movY", movimiento.y);
                animacion.SetBool("andando", true);
                estadoActual = EstadoJugador.andando;
            }
            else
            {
                animacion.SetBool("andando", false);
                estadoActual = EstadoJugador.parado;
            }
        }
        monedas = Moneda.moneda;
    }
    
    private void FixedUpdate()
    {
        movimiento.Normalize();
        rb2d.MovePosition(rb2d.position + movimiento * velMovimiento * Time.deltaTime);
    }
}
