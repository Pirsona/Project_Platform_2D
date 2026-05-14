using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private bool _isLookRight = true;
    private Quaternion _rightRotation;
    private Quaternion _leftRotation;

    public void Awake()
    {
        _rightRotation = Quaternion.Euler(0, 0, 0);
        _leftRotation = Quaternion.Euler(0, 180, 0);
    }
    public void Rotate(float horizontalInput)
    {
        if (horizontalInput > 0 && _isLookRight == false)
        {
            transform.rotation = _rightRotation;
            _isLookRight = true;
        }
        else if (horizontalInput < 0 && _isLookRight == true)
        {
            transform.rotation = _leftRotation;
            _isLookRight = false;
        }
    }
}
