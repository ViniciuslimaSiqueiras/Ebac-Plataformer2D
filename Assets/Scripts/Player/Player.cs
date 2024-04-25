using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Walk")]
    private float _currentSpeed;
    private bool _isRunning;
    public float speed;
    public float speedRun;
    public Vector2 friction = new Vector2(-.1f,0);

    [Header("WalkAnimation")]
    public float jumpScaleY = 2.5f;
    public float jumpScaleX = 1.5f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Player Animation")]
    private int boolRun = Animator.StringToHash("Run");
    public Animator anim;

    [Header("Jump")]
    public float forceJump; 


    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        jump();
        walk();
    }

    private void walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            anim.speed = 1.5f ;
        }
        else 
        {
            _currentSpeed = speed;
            anim.speed = 1;
        }

        _isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.A))
        {
            // rb.MovePosition(rb.position - velocity * Time.deltaTime);
            //rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            rb.velocity = new Vector2(_isRunning ? -speedRun : -speed, rb.velocity.y);
            if(rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-2, .4f);
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            // rb.MovePosition(rb.position + velocity * Time.deltaTime);
            rb.velocity = new Vector2(_isRunning ? speedRun : speed, rb.velocity.y);
            if(rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(2, .4f);
            }
        }
        if(rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }else if(rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
        if(rb.velocity.x != 0)
        {
            anim.SetBool(boolRun, true);
        }
        else
        {

            anim.SetBool(boolRun, false);
        }

    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceJump;
           // rb.transform.localScale = new Vector2(2, 2);
            DOTween.Kill(rb.transform);
           // jumpAnimation();
            
        }
    }
    public void jumpAnimation()
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo);
    }
}
