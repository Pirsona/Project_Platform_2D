using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _attackRange;

    private float _nextAttackTime;
                                                                                                                                                                                                                                                                                                                                                                                                                                    
    public float Range => _attackRange;
    public bool IsAttack {get; private set;}

    public void AttackObject(GameObject objectAttack)
    {
        if(Time.time >=  _nextAttackTime)
        {
            IsAttack = true;

            if (objectAttack.TryGetComponent(out Health heal))
            {
                heal.TakeDamage(_damage);
            }

            _nextAttackTime = Time.time + _cooldown;
        }
        else
        {
            IsAttack = false;
        }
    }
}
