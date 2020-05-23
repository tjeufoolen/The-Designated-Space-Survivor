using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float tapForce = 10;
    public Vector3 startPos;
    public Game game;
    
    Rigidbody2D rb;

    private int health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAlive())
        {
            game.Die();
            Destroy(gameObject);
            return;
        }

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
    }

    private bool isAlive()
    {
        return health > 0;
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }
}
