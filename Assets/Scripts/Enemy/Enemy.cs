using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Patroller _patroller;

    public Vector2 CurrentTarget => _patroller.TargetPosition;

    private void FixedUpdate()
    {
        _patroller.CheckPosition();
        _mover.TravelToTarget(CurrentTarget);
    }
}
