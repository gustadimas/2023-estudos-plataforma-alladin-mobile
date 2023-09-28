using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
