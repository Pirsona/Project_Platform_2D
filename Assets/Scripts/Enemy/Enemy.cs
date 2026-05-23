using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemySearch _search;
    [SerializeField] private RotateObject _rotate;
    [SerializeField] private EnemyAttack _attack;
    [SerializeField] private EnemyAnimator _animator;

    private Vector2 _positionTarget;

    private void Update()
    {
        _animator.SetAttack(_attack.IsAttack);
    }

    private void FixedUpdate()
    {
        if(_search.TargetPosition != null)
        {
            _positionTarget = _search.TargetPosition.position;

            if (Vector3Extensions.IsEnoughClose(transform.position, _positionTarget, _attack.Range))
            {
                _attack.AttackObject(_search.TargetPosition.gameObject);
            }
            else
            {
                _mover.TravelToTarget(_positionTarget);
            }
        }
        else
        {
            _patroller.CheckPosition();

            _positionTarget = _patroller.PointPosition;
            _mover.TravelToTarget(_positionTarget);
        }

        _rotate.Rotate(_positionTarget.x - transform.position.x);
    }
}
