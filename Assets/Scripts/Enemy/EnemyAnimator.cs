using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private bool _isCharging = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAttack(bool isAttaking)
    {
        if (_isCharging != isAttaking)
        {
            _animator.SetBool(EnemyAnimatorData.Params.IsAttaking, isAttaking);
            _isCharging = isAttaking;
        }
    }
}
