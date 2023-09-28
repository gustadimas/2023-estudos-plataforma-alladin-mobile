using UnityEngine;
using UnityEngine.UI;

public class Vaso_Maca_Dima : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    void Update()
    {
        if (transform.position.x < -10) Destroy(gameObject);
        transform.position += moveSpeed * Time.deltaTime * Vector3.left;
    }
}