using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator anim;
    public int hashTriggerAttack = Animator.StringToHash("Attack");

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

}
