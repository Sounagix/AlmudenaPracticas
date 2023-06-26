using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    [SerializeField]
    private KeyCode movDer;

    [SerializeField]
    private KeyCode movIzq;

    [SerializeField]
    private KeyCode Salto;

    [SerializeField]
    private float vel;

    [SerializeField]
    private Animator animator;

    private Rigidbody2D rb;

    private SpriteRenderer sp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(movDer))
            {
                Move(Vector2.right);
                sp.flipX = true;
            }
            else if (Input.GetKey(movIzq))
            {
                Move(Vector2.left);
                sp.flipX = false;
            }

            if (Input.GetKeyDown(Salto))
            {
                SaltoMario();
            }
        }
    }

    private void SaltoMario()
    {
        rb.AddForce(transform.up * 20, ForceMode2D.Impulse);
        animator.SetTrigger("JumpEvent");
    }


    private void Move(Vector2 dir)
    {
        rb.AddForce(dir * vel, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        float vel = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Velocidad", vel);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("InAir",true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("InAir", false);
    }
}
