using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujon : MonoBehaviour
{
    [Header("FrameDño")]
    public Color flashcolor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D collision2D;
    public SpriteRenderer mySprite;

    public float thrust;
    public float empujon;
    public string target;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(target))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                collision.GetComponent<PokemonEnemigosDatos>().vida = collision.GetComponent<PokemonEnemigosDatos>().vida - this.GetComponent<PokemonsMios>().ataque;
                if (collision.GetComponent<PokemonEnemigosDatos>().vida <= 0)
                {
                    for (int c = 0; c < collision.GetComponent<PokemonEnemigosDatos>().pokemonsEnemigo.pokemons.Count; c++)
                    {
                        if (collision.GetComponent<PokemonEnemigosDatos>().pokemonsEnemigo.pokemons[c].nombre == collision.GetComponent<PokemonEnemigosDatos>().nombre)
                        {
                            collision.GetComponent<PokemonEnemigosDatos>().pokemonsEnemigo.pokemons.RemoveAt(c);
                            collision.gameObject.SetActive(false);
                        }
                    }


                }
                
            }
            Vector2 difference = enemy.transform.position - transform.position;
            difference = difference.normalized * thrust;
            enemy.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(EmpujonBicho(enemy));
        }
        else{
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    private IEnumerator EmpujonBicho(Rigidbody2D enemigo)
    {
        if (enemigo != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(empujon);
            enemigo.velocity = Vector2.zero;
            enemigo.isKinematic = true;
            StopCoroutine(this.EmpujonBicho(enemigo));
        }
    }
    private IEnumerator FlashCo()
    {
        int tem = 0;
        collision2D.enabled = false;
        while (tem < numberOfFlashes)
        {
            mySprite.color = flashcolor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            tem++;
        }
        collision2D.enabled = true;
    }
    private IEnumerator tiempo()
    {
        yield return new WaitForSeconds(1f);
    }
}

