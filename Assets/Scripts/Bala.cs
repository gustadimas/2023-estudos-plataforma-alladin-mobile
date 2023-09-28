using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float velocidade;

    private void Update()
    {
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * velocidade);
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}