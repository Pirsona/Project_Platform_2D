using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotate _rotate;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private GroundDetector _detector;

    private void Update()
    {
        _animation.SetSpeed(_input.HorizontalInput);
        _animation.SetJump(_detector.IsGrounded);
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
    }
}