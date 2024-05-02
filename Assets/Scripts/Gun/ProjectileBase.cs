using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float Side;

    public int timeToDestroy = 2;
    public int damage = 1;

    public Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * Side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy != null)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
        }

    }

}
