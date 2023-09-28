using UnityEngine;

public class Maca : MonoBehaviour
{
    int danoAtual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vaso"))
        {
            GameControllerAlladin.pontos++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}