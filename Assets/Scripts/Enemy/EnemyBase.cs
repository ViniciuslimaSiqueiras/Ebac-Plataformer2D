using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator anim;
    public int hashTriggerAttack = Animator.StringToHash("Attack");

    public HealthBase health;

    private void Start()
    {
        health = GetComponent<HealthBase>();
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
    public void Damage(int amount)
    {
        health.Damage(amount);
    }

}
