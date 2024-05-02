using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase PFBProjectile;

    public float timeBetweenShoot = .3f;
    public Transform playerSideReference;

    public Transform shootPos;
    private Coroutine _currentCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentCoroutine = StartCoroutine(StartShoot());

        }else if (Input.GetKeyUp(KeyCode.E))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }   
    }

    public void Shoot()
    {
        var projectile = Instantiate(PFBProjectile);
        projectile.transform.position = shootPos.position;
        projectile.Side = playerSideReference.transform.localScale.x;
    }

}
