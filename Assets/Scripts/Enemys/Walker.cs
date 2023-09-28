using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walker : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    bool movingRight = true;

    bool playerInTrigger = false;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerInTrigger)
        {
            if (movingRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            if (transform.position.x >= pointB.position.x)
            {
                sprite.flipX = false;
                movingRight = false;
            }
            else if (transform.position.x <= pointA.position.x)
            {
                sprite.flipX = true;
                movingRight = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
