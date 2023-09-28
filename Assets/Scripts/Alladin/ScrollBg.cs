using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

public class ScrollBg : MonoBehaviour
{
    [SerializeField] float vel;
    [SerializeField] Renderer quad;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(vel * Time.deltaTime, 0);
        quad.material.mainTextureOffset += offset;
    }
}
