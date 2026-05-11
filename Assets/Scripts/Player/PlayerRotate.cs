using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public void Rotate(float horizontalInput)
    {
        if (horizontalInput >= 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
