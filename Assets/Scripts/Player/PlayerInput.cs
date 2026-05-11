using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private float _horizontalInput;
    private bool _isJumping;

    public float HorizontalInput => _horizontalInput;
    public bool IsJumping => _isJumping;

    private void Update()
    {
        Controller();
    }

    private void Controller()
    {
        _horizontalInput = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
    }
}
