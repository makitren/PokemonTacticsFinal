using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonEnemigosDatos : Pokemon
{
        public Transform target;
        public string enemigo;
        public float chaseRadius;
        public float attackRadius;
        public Transform homePositions;
        public Animator anm;
        public Sprite sprite;
        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindWithTag(enemigo).transform;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = anm.runtimeAnimatorController;
            anm = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            checkDistance();
        }
        void checkDistance()
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, movimiento * Time.deltaTime);
                Vector3 ventor = Vector3.MoveTowards(transform.position, target.position, movimiento * Time.deltaTime);
                chanageAnimation(ventor - transform.position);
                anm.SetBool("EmpezarBatalla", true);
            }
            else
            {
                anm.SetBool("EmpezarBatalla", false);
            }
        }
        private void SetAnimatorFloat(Vector2 vector)
        {
            anm.SetFloat("movX", vector.x);
            anm.SetFloat("movY", vector.y);
        }
        private void chanageAnimation(Vector2 direccion)
        {
            if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y))
            {
                if (direccion.x > 0)
                {
                    SetAnimatorFloat(Vector2.right);
                }
                else if (direccion.x < 0)
                {
                    SetAnimatorFloat(Vector2.left);
                }
            }
            else if (Mathf.Abs(direccion.x) < Mathf.Abs(direccion.y))
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

