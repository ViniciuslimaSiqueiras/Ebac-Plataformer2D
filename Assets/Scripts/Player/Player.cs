using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Walk")]
    private float _currentSpeed;
    private bool _isRunning;
    public float speed;
    public float speedRun;

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
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else 
        {
            _currentSpeed = speed;
        }*/

        _isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.A))
        {
            // rb.MovePosition(rb.position - velocity * Time.deltaTime);
            //rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            rb.velocity = new Vector2(_isRunning ? -speedRun : -speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // rb.MovePosition(rb.position + velocity * Time.deltaTime);
            rb.velocity = new Vector2(_isRunning ? speedRun : speed, rb.velocity.y);
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
