using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    int coins = 0;
    [SerializeField] Text coinsText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            coins++;
            coinsText.text = "Coins: " + coins;
            Destroy(gameObject);
        }
    }
}
