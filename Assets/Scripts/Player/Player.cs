using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Setup")]
    public SOPlayerSetup setup;

    [Header("Privates")]
    private float _currentSpeed;
    private bool _isRunning;

    public float test;
    Rigidbody2D rb;

    //public Animator anim;
    public HealthBase _health;

    private Animator _currentPlayer;

    private void Awake()
    {
        if(_health != null)
        {
            _health.OnKill += OnPlayerDeath;
        }
        _currentPlayer = Instantiate(setup.player, transform);
        _currentPlayer.transform.localScale = new Vector3(.5f,.5f,0);
    }

    private void OnPlayerDeath()
    {
        _health.OnKill -= OnPlayerDeath;
        _currentPlayer.SetTrigger(setup.deathHash);

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _currentPlayer = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        jump();
        walk();
        test = rb.velocity.x;
    }

    private void walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = setup.speedRun;
            _currentPlayer.speed = 1.5f ;
        }
        else 
        {
            _currentSpeed = setup.speed;
            _currentPlayer.speed = 1;
        }

        _isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.A))
        {
            // rb.MovePosition(rb.position - velocity * Time.deltaTime);
            //rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            rb.velocity = new Vector2(_isRunning ? -setup.speedRun : -setup.speed, rb.velocity.y);
            if(rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-2, .4f);
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            // rb.MovePosition(rb.position + velocity * Time.deltaTime);
            rb.velocity = new Vector2(_isRunning ? setup.speedRun : setup.speed, rb.velocity.y);
            if(rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(2, .4f);
            }
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        if(rb.velocity.x > 0)
        {
            rb.velocity -= setup.friction;
        }else if(rb.velocity.x < 0)
        {
            rb.velocity += setup.friction;
        }
        if(rb.velocity.x != 0)
        {
            _currentPlayer.SetBool(setup.boolRun, true);
        }
        else
        {

            _currentPlayer.SetBool(setup.boolRun, false);
        }

    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * setup.forceJump;
           // rb.transform.localScale = new Vector2(2, 2);
            DOTween.Kill(rb.transform);
           // jumpAnimation();
            
        }
    }
    public void jumpAnimation()
    {
        rb.transform.DOScaleY(setup.jumpScaleY, setup.animationDuration).SetLoops(2,LoopType.Yoyo);
        rb.transform.DOScaleX(setup.jumpScaleX, setup.animationDuration).SetLoops(2,LoopType.Yoyo);
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
