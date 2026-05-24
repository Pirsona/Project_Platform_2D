using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _pointAttack;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _radius;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _attackDuration = 0.3f;

    public bool IsAttacking => _isAttack;

    private float _nextAttackTime;
    private bool _isAttack;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_attackDuration);
    }


    public void Attack()
    {
        if (Time.time >= _nextAttackTime && !IsAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        Collider2D hit = Physics2D.OverlapCircle(_pointAttack.position, _radius, _layer);

        _isAttack = true;

        if (hit != null)
        {
            if (hit.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }

        _nextAttackTime = Time.time + _cooldown;

        yield return _wait;

        _isAttack = false;
    }
}