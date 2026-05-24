using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private ObjectRotator _rotate;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private GroundDetector _detector;

    private void Update()
    {
        _animation.SetSpeed(_input.HorizontalInput);
        _animation.SetJump(_detector.IsGrounded);
        _animation.SetAttack(_attack.IsAttacking);
        _rotate.Rotate(_input.HorizontalInput);
    }

    private void FixedUpdate()
    {
        _mover.Move(_input.HorizontalInput);

        if (_input.IsJumping && _detector.IsGrounded)
        {
            _mover.Jump();
            _input.ConsumeJump();
        }
        if (_input.IsAttacking && _detector.IsGrounded)
        {
            _attack.Attack();
            _input.ConsumeAttack();
        }
    }
}