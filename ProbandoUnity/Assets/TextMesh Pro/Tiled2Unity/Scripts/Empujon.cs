using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujon : MonoBehaviour
{
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
                enemy.isKinematic = false;
                Vector2 difference= enemy.transform.position-transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(EmpujonBicho(enemy));
            }
        }
    }
    private IEnumerator EmpujonBicho(Rigidbody2D enemigo)
    {
        if (enemigo != null)
        {
            yield return new WaitForSeconds(empujon);
            enemigo.velocity = Vector2.zero;
            enemigo.isKinematic = true;
        }
    }
}
