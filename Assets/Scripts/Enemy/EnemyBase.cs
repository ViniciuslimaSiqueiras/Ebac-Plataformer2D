using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator anim;
    public int hashTriggerAttack = Animator.StringToHash("Attack");
    public int hashTriggerDeath = Animator.StringToHash("Death");

    public HealthBase health;
    public int timeToDesroy = 1;

    private void Awake()
    {
        if(health != null)
        {
            health.OnKill += OnEnemyKill;
        }
    }

    private void OnValidate()
    {
        health = GetComponent<HealthBase>();
    }

    public void OnEnemyKill()
    {
        health.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, 1f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    public void PlayAttackAnimation()
    {
        anim.SetTrigger(hashTriggerAttack);

    }
    public void PlayDeathAnimation()
    {
        anim.SetTrigger(hashTriggerDeath);

    }
    public void Damage(int amount)
    {
        health.Damage(amount);
    }

}
