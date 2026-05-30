using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Quaternion _rotation;

    private void Awake()
    {
        _rotation = transform.rotation;

    }

    private void LateUpdate()
    {
        transform.rotation = _rotation;
    }
}
