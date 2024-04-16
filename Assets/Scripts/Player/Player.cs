using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
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
    }
}
