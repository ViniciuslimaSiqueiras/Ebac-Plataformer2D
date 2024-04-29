using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public float delayToKill;
    public bool destroyOnKill = false;

    private int _currentLife;

    [SerializeField]
    private FlashColor _flashColor;

    private bool _isAlive;
    private void Awake()
    {
        init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    private void init()
    {
        _currentLife = startLife;
        _isAlive = true;
    }

    public void Damage(int Damage)
    {
        if (!_isAlive) return;

        _currentLife -= Damage;
        if(_currentLife <= 0)
        {
            Kill();
        }
        if(_flashColor != null)
        {
            _flashColor.flash();
        }

    }
    private void Kill()
    {
        _isAlive = false;
        if (destroyOnKill)
        {
            Destroy(gameObject,delayToKill);
        }
    }

}
