using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private KeyCode _jumpButton = KeyCode.Space;
    private float _horizontalInput;
    private bool _isJumping;

    public float HorizontalInput => _horizontalInput;
    public bool IsJumping => _isJumping;

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        _horizontalInput = Input.GetAxis(Horizontal);
        if (Input.GetKeyDown(_jumpButton))
        {
            _isJumping = true;
        }

    }

    public void ConsumeJump()
    {
        _isJumping = false;
    }
}
