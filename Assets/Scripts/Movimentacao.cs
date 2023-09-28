using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;

    [SerializeField] LayerMask podePular;

    bool puloDuplo = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 5, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && noChao())
        {
            puloDuplo = false;
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }

        else if (Input.GetButtonDown("Jump") && !puloDuplo)
        {
            puloDuplo = true;
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        else if (Input.GetAxisRaw("Horizontal") < 0) transform.eulerAngles = new Vector3(0, 180, 0);
    }

    bool noChao()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, podePular);
    }
}
