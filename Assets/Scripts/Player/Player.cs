using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Walk")]
    public float speed;
    public Vector2 friction = new Vector2(-.1f,0);

    [Header("Jump")]
    public float forceJump; 

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jump();
        walk();
    }

    private void walk()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // rb.MovePosition(rb.position - velocity * Time.deltaTime);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // rb.MovePosition(rb.position + velocity * Time.deltaTime);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if(rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }else if(rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }

    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceJump;
        }
    }
}
