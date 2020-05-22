using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float tapForce = 10;
    public Vector3 startPos;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
    }
}
